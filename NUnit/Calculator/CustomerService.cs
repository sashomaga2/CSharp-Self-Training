using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public enum CustomerStatus
    {
        Normal,
        Platinum
    }

    public interface ICustomerRepository
    {
        void Save(Customer customer);
        void SaveSpecial(Customer customer);

        string LocalTimezone { get; set; }

        int? WorkstationId { get; set; }
    }

    public interface ICustomerAddressBuilder
    {
        string From(CustomerToCreate customer);
        bool TryParse(string addressToCreateFrom, out string mailingAddress);
    }

    public interface IIdFactory
    {
        int Create();
    }
    public interface IStatusFactory
    {
        CustomerStatus CreateFrom(CustomerToCreate customerToCreate);
    }

    public class CustomerToCreate
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string MailingAddress { get; set; }

        public CustomerStatus DesiredStatus { get; set; }
    }

    public class Customer : IEquatable<Customer>, IEquatable<CustomerToCreate>
    {
        public Customer(string Name, string City)
        {
            this.Name = Name;
            this.City = City;
        }

        public string Name { get; set; }
        public string City { get; set; }

        public string MailingAddress { get; set; }
        public int Id { get; set; }
        public CustomerStatus StatusLevel { get; set; }

        public bool Equals(Customer other)
        {
            return Name == other.Name && City == other.City;
        }

        public bool Equals(CustomerToCreate other)
        {
            return Name == other.Name && City == other.City;
        }
    }

    //////////////////////////////////////////////
    
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerAddressBuilder _customerAddressBuilder;
        private readonly IIdFactory _idFactory;
        private readonly IStatusFactory _statusFactory;

        public CustomerService(ICustomerRepository customerRepository, 
                        ICustomerAddressBuilder customerAddressBuilder, 
                        IIdFactory idFactory, 
                        IStatusFactory statusFactory)
        {
            _customerRepository = customerRepository;
            _customerAddressBuilder = customerAddressBuilder;
            _idFactory = idFactory;
            _statusFactory = statusFactory;
        }

        public void Create(CustomerToCreate customerToCreate)
        {
            try
            {
                var customer = BuildCustomerObjectFrom(customerToCreate);
                string mailingAddress;

                var isMailingAddressCreated = _customerAddressBuilder.TryParse(customerToCreate.MailingAddress, out mailingAddress);

                //if (mailingAddress == null)
                //{
                //    throw new InvalidCustomerMailingAddressException();
                //}

                _customerRepository.LocalTimezone = TimeZone.CurrentTimeZone.StandardName;

                if (!_customerRepository.WorkstationId.HasValue)
                {
                    //TODO make custom exception
                    throw new Exception("No value for WorkstationId");
                }

                customer.MailingAddress = mailingAddress;
                customer.Id = _idFactory.Create();
                customer.StatusLevel = _statusFactory.CreateFrom(customerToCreate);

                if (customer.StatusLevel == CustomerStatus.Platinum)
                {
                    _customerRepository.SaveSpecial(customer);
                }
                else
                {
                    _customerRepository.Save(customer);
                }

            }
            catch(InvalidCustomerMailingAddressException e)
            {
                throw new CustomerCreationException(e);
            }
            
        }
        public void Create(IEnumerable<CustomerToCreate> customersToCreate)
        {
            foreach (var customerToCreate in customersToCreate)
            {
                _customerRepository.Save(BuildCustomerObjectFrom(customerToCreate));
            }
        }

        private Customer BuildCustomerObjectFrom(CustomerToCreate customerToCreate)
        {
            return new Customer(customerToCreate.Name, customerToCreate.City);
        }
    }

    [Serializable]
    public class CustomerCreationException : Exception
    {
        private InvalidCustomerMailingAddressException e;

        public CustomerCreationException()
        {
        }

        public CustomerCreationException(string message) : base(message)
        {
        }

        public CustomerCreationException(InvalidCustomerMailingAddressException e)
        {
            this.e = e;
        }

        public CustomerCreationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerCreationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    public class InvalidCustomerMailingAddressException : Exception
    {
        public InvalidCustomerMailingAddressException()
        {

        }
        public InvalidCustomerMailingAddressException(string message = "User Mail Address is Invalid!") : base(message)
        {
        }

    }
}

using Calculator;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Tests
{
    [TestFixture]
    public class CustomerServiceTests
    {

        [Test]
        public void CreateShouldSetLocalTimezone()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
            var mockIdFactory = new Mock<IIdFactory>();
            var mockStatucFactory = new Mock<IStatusFactory>();

            mockRepository.Setup(x => x.WorkstationId).Returns(123);

            var customerToCreate = new CustomerToCreate { Name = "Goro", City = "Berkovica" };

            var customerService = new CustomerService(mockRepository.Object, mockAddressBuilder.Object, mockIdFactory.Object, mockStatucFactory.Object);

            //Act
            customerService.Create(customerToCreate);

            //Assert
            mockRepository.VerifySet(x => x.LocalTimezone = It.IsAny<string>());
        }

        [Test]
        public void CreateShouldGetWorkstationId()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
            var mockIdFactory = new Mock<IIdFactory>();
            var mockStatucFactory = new Mock<IStatusFactory>();

            //mockRepository.Setup(x => x.WorkstationId).Returns(123);
            mockRepository.SetupProperty(x => x.WorkstationId, 123);
            mockRepository.Object.WorkstationId = 234;

            var customerToCreate = new CustomerToCreate { Name = "Goro", City = "Berkovica" };

            var customerService = new CustomerService(mockRepository.Object, mockAddressBuilder.Object, mockIdFactory.Object, mockStatucFactory.Object);

            //Act
            customerService.Create(customerToCreate);

            //Assert
            mockRepository.VerifyGet(x => x.WorkstationId);
        }

        [Test]
        public void CustomerStatusPlatinumShouldInvokeSaveSpecial()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
            var mockIdFactory = new Mock<IIdFactory>();
            var mockStatucFactory = new Mock<IStatusFactory>();

            mockRepository.Setup(x => x.WorkstationId).Returns(123);

            var customerToCreate = new CustomerToCreate { DesiredStatus = CustomerStatus.Platinum, Name = "Goro", City = "Berkovica" };

            mockStatucFactory.Setup(x => x.CreateFrom(It.Is<CustomerToCreate>(y => y.DesiredStatus == CustomerStatus.Platinum))).Returns(CustomerStatus.Platinum);
            mockStatucFactory.Setup(x => x.CreateFrom(It.Is<CustomerToCreate>(y => y.DesiredStatus == CustomerStatus.Normal))).Returns(CustomerStatus.Normal);

            mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            var mailingAddress = "Fake address";
            mockAddressBuilder.Setup(x => x.From(It.IsAny<CustomerToCreate>())).Returns("Fake address");
            mockAddressBuilder.Setup(x => x.TryParse(It.IsAny<string>(), out mailingAddress)).Returns(true);

            var customerService = new CustomerService(mockRepository.Object, mockAddressBuilder.Object, mockIdFactory.Object, mockStatucFactory.Object);

            //Act
            customerService.Create(customerToCreate);

            //Assert
            mockRepository.Verify(x => x.SaveSpecial(It.IsAny<Customer>()));
        }

        [Test]
        public void CreateShouldInvokeSave()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
            var mockIdFactory = new Mock<IIdFactory>();
            var mockStatucFactory = new Mock<IStatusFactory>();

            mockRepository.Setup(x => x.WorkstationId).Returns(123);

            var mockCustomerToCreate = new Mock<CustomerToCreate>();

            mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            var mailingAddress = "Fake address";
            mockAddressBuilder.Setup(x => x.From(It.IsAny<CustomerToCreate>())).Returns("Fake address");
            mockAddressBuilder.Setup(x => x.TryParse(It.IsAny<string>(), out mailingAddress)).Returns(true);

            var customerService = new CustomerService(mockRepository.Object, mockAddressBuilder.Object, mockIdFactory.Object, mockStatucFactory.Object);

            //Act
            customerService.Create(mockCustomerToCreate.Object);

            //Assert
            mockRepository.VerifyAll();
        }

        [Test]
        public void CustomerShouldBeCreatedWithPassedData()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
            var mockIdFactory = new Mock<IIdFactory>();
            var mockStatucFactory = new Mock<IStatusFactory>();

            mockRepository.Setup(x => x.WorkstationId).Returns(123);

            var customerToCreate = new CustomerToCreate { City="Sofia", Name="Pesho" };

            mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            var mailingAddress = "Fake address";
            mockAddressBuilder.Setup(x => x.From(It.IsAny<CustomerToCreate>())).Returns("Fake address");
            mockAddressBuilder.Setup(x => x.TryParse(It.IsAny<string>(), out mailingAddress)).Returns(true);

            var customerService = new CustomerService(mockRepository.Object, mockAddressBuilder.Object, mockIdFactory.Object, mockStatucFactory.Object);

            //Act
            customerService.Create(customerToCreate);

            //Assert
            mockRepository.Verify(x => x.Save(It.Is<Customer>(fn => fn.Equals(customerToCreate))));
            mockRepository.Verify(x => x.Save(It.Is<Customer>(fn => fn.Name.Equals(customerToCreate.Name, StringComparison.InvariantCultureIgnoreCase) &&
                                                                    fn.City.Equals(customerToCreate.City, StringComparison.InvariantCultureIgnoreCase))));
        }



        [Test]
        public void EachCustomerShoudBeAssignedAnId()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
            var mockIdFactory = new Mock<IIdFactory>();
            var mockStatucFactory = new Mock<IStatusFactory>();

            mockRepository.Setup(x => x.WorkstationId).Returns(123);

            var i = 1;
            mockIdFactory.Setup(x => x.Create())
                .Returns(() => i)
                .Callback(() => i++);

            var mockCustomersToCreate = new List<CustomerToCreate> {
                new CustomerToCreate(),
                new CustomerToCreate(),
                new CustomerToCreate()
            };

            mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            var mailingAddress = "Fake address";
            mockAddressBuilder.Setup(x => x.From(It.IsAny<CustomerToCreate>())).Returns("Fake address");
            mockAddressBuilder.Setup(x => x.TryParse(It.IsAny<string>(), out mailingAddress)).Returns(true);

            var customerService = new CustomerService(mockRepository.Object, mockAddressBuilder.Object, mockIdFactory.Object, mockStatucFactory.Object);

            //Act
            mockCustomersToCreate.ForEach(c =>
            {
                customerService.Create(c);
            });

            //Assert
            mockIdFactory.Verify(x => x.Create(), Times.Exactly(3));   
        }



        
        [Ignore("Changed")]
        public void ExceptionShouldBeTrownIfAddressNotCreated_old()
        {
            var mockRepository = new Mock<ICustomerRepository>();
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
            var mockIdFactory = new Mock<IIdFactory>();
            var mockStatucFactory = new Mock<IStatusFactory>();

            mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            mockAddressBuilder.Setup(x => x.From(It.IsAny<CustomerToCreate>())).Returns(() => null);

            var customerService = new CustomerService(mockRepository.Object, mockAddressBuilder.Object, mockIdFactory.Object, mockStatucFactory.Object);

            Assert.That(() => customerService.Create(new CustomerToCreate { Name = "Sasho", City = "Moskow" }),
                Throws.TypeOf<InvalidCustomerMailingAddressException>());

        }

        [Test]
        public void ExceptionShouldBeTrownIfAddressNotCreated()
        {
            var mockRepository = new Mock<ICustomerRepository>();
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
            var mockIdFactory = new Mock<IIdFactory>();
            var mockStatucFactory = new Mock<IStatusFactory>();

            mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            string variable = null; 
            mockAddressBuilder.Setup(x => x.TryParse(It.IsAny<string>(), out variable)).Throws<InvalidCustomerMailingAddressException>();

            var customerService = new CustomerService(mockRepository.Object, mockAddressBuilder.Object, mockIdFactory.Object, mockStatucFactory.Object);

            Assert.That(() => customerService.Create(new CustomerToCreate { Name = "Sasho", City = "Moskow" }),
                Throws.TypeOf<CustomerCreationException>());

        }

        [Test]
        public void CreateShouldInvokeSaveForEveryCustover()
        {
            // Arrange
            var mockRepository = new Mock<ICustomerRepository>();
            var mockAddressBuilder = new Mock<ICustomerAddressBuilder>();
            var mockIdFactory = new Mock<IIdFactory>();
            var mockStatucFactory = new Mock<IStatusFactory>();

            var listOfCustomersToCreate = new List<CustomerToCreate>
            {
                new CustomerToCreate
                {
                    Name = "Name1",
                    City = "City1"
                },
                new CustomerToCreate
                {
                    Name = "Name2",
                    City = "City2"
                },
                new CustomerToCreate
                {
                    Name = "Name3",
                    City = "City3"
                }
            };

            //mockRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            var customerService = new CustomerService(mockRepository.Object, mockAddressBuilder.Object, mockIdFactory.Object, mockStatucFactory.Object);

            //Act
            customerService.Create(listOfCustomersToCreate);

            //Assert
            mockRepository.Verify(x => x.Save(It.IsAny<Customer>()), Times.Exactly(listOfCustomersToCreate.Count));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface IRepository
    {
        void Save(Customer customer);

        void FetchAll();
    }

    public class EmployeeService
    {
        private readonly IRepository _repository;

        public EmployeeService(IRepository repository)
        {
            _repository = repository;
        }
        public void Create(string name, string city)
        {
            var employee = new Customer(name, city);

            _repository.Save(employee);
            _repository.FetchAll();
        }
    }
}

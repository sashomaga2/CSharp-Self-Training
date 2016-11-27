using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt
{
    class Program
    {
        static void Main(string[] args)
        {
            // var repository = new Repository<Employee>();
            // AddEmployee(repository)
            // AddManager(repository)
            // CountEmployees(repository)
            // PrintAllPeople(repository)

            Database.SetInitializer(new DropCreateDatabaseAlways<EmployeeDb>());
            using (IRepository<Employee> employeeRepository = new SqlRepository<Employee>(new EmployeeDb()))
            {
                AddEmployee(employeeRepository);
                AddManagers(employeeRepository);
                CountEmployees(employeeRepository);
                QueryEmployees(employeeRepository);
                DumpPeople(employeeRepository);

                IEnumerable <Person> temp = employeeRepository.FindAll();
            }

        }

        private static void AddManagers(IWriteOnlyReporitory<Manager> employeeRepository)
        {
            employeeRepository.Add(new Manager { Name = "Alex the Manager" });
            employeeRepository.Commit();
        }

        private static void DumpPeople(IReadOnlyRepository<Person> employeeRepository)
        {
            var employees = employeeRepository.FindAll();
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.Name);
            }

        }

        private static void QueryEmployees(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.FindById(1);
            Console.WriteLine("Employee: {0}", employee.Name);
        }

        private static void CountEmployees(IRepository<Employee> employeeRepository)
        {
            Console.WriteLine(employeeRepository.FindAll().Count()); 
        }

        private static void AddEmployee(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { Name = "Scott" });
            employeeRepository.Add(new Employee { Name = "Alex" });
            employeeRepository.Commit();
        }
    }
}

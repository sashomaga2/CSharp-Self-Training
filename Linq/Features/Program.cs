using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Employee, bool> test = (Employee e) => { return e.Name.StartsWith("S"); };

            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Scott" },
                new Employee { Id = 2, Name = "Chris" },
                new Employee { Id = 3, Name = "Ina" },
            };

            IEnumerable<Employee> sales = new List<Employee>()
            {
                new Employee { Id = 3 , Name = "Alex" }
            };

            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while(enumerator.MoveNext())
            {
                //Console.WriteLine(enumerator.Current);
            }

            var query = from developer in developers
                        where developer.Name.Length == 5
                        orderby developer.Name
                        select developer;

            var query2 = developers.Where(e => e.Name.Length == 5).OrderBy(e => e.Name).Select(e => e);

            foreach (var developer in query)
            {
                Console.WriteLine(developer.Name);
            }



        }

        private static bool NameStartsWithS(Employee employee)
        {
            return employee.Name.StartsWith("S");
        }
    }
}

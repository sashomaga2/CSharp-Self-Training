using Datastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures
{
    public class EmployeeComparer : IEqualityComparer<Employee>, IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return String.Compare(x.Name, y.Name);
        }

        public bool Equals(Employee x, Employee y)
        {
            return String.Equals(x.Name, y.Name);
        }

        public int GetHashCode(Employee obj)
        {
            return obj.Name.GetHashCode();
        }
    }

    public class DepartmentCollection : SortedDictionary<string, SortedSet<Employee>>
    {
        public DepartmentCollection Add(string departmentName, Employee employee)
        {
            if (!ContainsKey(departmentName))
            {
                Add(departmentName, new SortedSet<Employee>(new EmployeeComparer()));
            }

            this[departmentName].Add(employee);
            return this;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //TestDepartments();

            var buffer = new CircularBuffer<double>(capacity: 3);
            buffer.ItemDiscarded += Buffer_ItemDiscarded;
            buffer.ItemDiscarded += (object sender, ItemDiscardedEventArgs<double> e) => Console.WriteLine("Discarded: " + e.ItemDiscarded + " , " + e.NewItem); ;

            buffer.Write(1.4);
            buffer.Write(2.4);
            buffer.Write(3.5);
            buffer.Write(4.0);

            //var consoleOut = new Printer<double>(ConsoleWrite);

            Action<double> print = ConsoleWrite;

            /**** anonymous method ****/
            Action<double> print2 = delegate (double data)
            {
                Console.WriteLine(data);
            };

            /**** lambda expression ****/
            Action<double> print_lambda = (double d) => Console.WriteLine(d);

            /**** Func delegate always return value last param ****/
            Func<double, double> fn = d => d;
            Func<double, double, double> func = (a, b) => a*b;

            /**** Predicate delegate ****/
            Predicate<double> pred = d => Convert.ToBoolean(d);

            /**** Converter delegate ****/
            Converter<double, string> converter = d => d.ToString();
            Converter<double, DateTime> converter_date = d => new DateTime(2010, 1, 1).AddDays(d);

            


            var asDates = buffer.Map(d => new DateTime(2010, 1, 1).AddDays(d));
            foreach (var date in asDates)
            {
                Console.WriteLine(date);
            }


            //buffer.Dump(ConsoleWrite);
            buffer.Dump(print_lambda);

            //var asDouble = buffer.AsEnumerable<double ,double>();



            //Console.WriteLine(buffer.IsEmpty());

            //foreach (var item in asDouble)
            //{
            //    Console.WriteLine(item);
            //}

            ProcessBuffer(buffer);

        }

        private static void Buffer_ItemDiscarded(object sender, ItemDiscardedEventArgs<double> e)
        {
            Console.WriteLine("Discarded:");
            Console.WriteLine(e.ItemDiscarded);
            Console.WriteLine(e.NewItem);
        }

        static void ConsoleWrite(double data)
        {
            Console.WriteLine(data);
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer:");
            while (!buffer.IsEmpty())
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
        }

        private static void TestDepartments()
        {
            var departments = new DepartmentCollection();

            departments.Add("Sales", new Employee { Name = "Joy" })
                        .Add("Sales", new Employee { Name = "Joy" })
                        .Add("Sales", new Employee { Name = "Pesho" });

            departments.Add("Engineering", new Employee { Name = "Pesho" })
                        .Add("Engineering", new Employee { Name = "Alex" })
                        .Add("Engineering", new Employee { Name = "Pesho" })
                        .Add("Engineering", new Employee { Name = "Gogo" });

            foreach (var department in departments)
            {
                Console.WriteLine(department.Key);
                foreach (var employee in department.Value)
                {
                    Console.WriteLine("\t" + employee.Name);
                }
            }
        }

    }
}

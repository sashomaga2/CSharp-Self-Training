using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //var employeeList = CreateCollection(typeof(List<>), typeof(List<Employee>));
            //Console.Write(employeeList.GetType().Name);
            //var genericArgs = employeeList.GetType().GenericTypeArguments;
            //foreach (var arg in genericArgs)
            //{
            //    Console.Write("[{0}]", arg.Name);
            //}
            //Console.WriteLine();
            //////////////////
            var employee = new Employee();
            var employeeType = typeof(Employee);
            var methodInfo = employeeType.GetMethod("Speak");
            methodInfo = methodInfo.MakeGenericMethod(typeof(DateTime));
            methodInfo.Invoke(employee, null);
        }

        private static object CreateCollection(Type collectionType, Type itemType)
        {
            var closedType = collectionType.MakeGenericType(itemType); 
            return Activator.CreateInstance(collectionType);
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public void Speak<T>()
        {
            Console.WriteLine(typeof(T));
        }

    }
}

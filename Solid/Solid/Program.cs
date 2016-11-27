using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadOnlyCollection<int> numbers = new ReadOnlyCollection<int>(new List<int>() { 1,2,3,4,23, 56 } );
            numbers.Count();
            Console.WriteLine( "Contains 23 {0}", numbers.Contains(23));

            var second = numbers[2];

            Console.WriteLine("\nreadOnlyDinosaurs[3]: {0}", second);
        }
    }
}

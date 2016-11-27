using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public enum Genre
    {
        NonFiction,
        Romance,
        Action,
        ScienceFiction
    }
    public class Program
    {
        static void Main(string[] args)
        {
            //var values = Enum.GetValues(typeof(Genre)).Cast<int>();
            var values = new int[] { 1, 2, 3 };
            //var casted = values.Cast<string>();
            
            var single = (string)cont;
            foreach (var item in casted)
            {
                Console.WriteLine("Type: {0}, Value: {1}", item.GetType(), item);
            }
        }
    }

    

}



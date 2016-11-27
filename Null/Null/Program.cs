using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Null
{
    class Program
    {
        static void Main(string[] args)
        {
            var sarah = new Player(new DiamondDefence());
            var pesho = new Player(NullDefence.Null);
            var sasho = new Player(NullDefence.Null);

            sarah.Hit(10);
            pesho.Hit(10);
            sasho.Hit(10);

            Console.ReadKey();
        }
    }
}

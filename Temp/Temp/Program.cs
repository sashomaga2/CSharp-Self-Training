using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp
{
    class Program
    {
        static void Main(string[] args)
        {
            Test.g();

        }
    }

    public static class Test
    {
        public static async void f()
        {
            await h();
        }

        public static async Task g()
        {
            await h();
        }

        public static async Task h()
        {
            throw new NotImplementedException();
        }

    }
}

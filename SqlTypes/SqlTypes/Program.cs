using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace SqlTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var decimalinstance = new Decimal(0);
            var sqlDecimal = new SqlDecimal(1);

            var intInt = (int)1;
            var sqlInt = new SqlInt32(1);

            var size1 = System.Runtime.InteropServices.Marshal.SizeOf(intInt); 
            var size2 = System.Runtime.InteropServices.Marshal.SizeOf(sqlInt); 
        }
    }
}

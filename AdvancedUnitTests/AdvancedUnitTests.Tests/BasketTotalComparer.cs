using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedUnitTests.Tests
{
    public class BasketTotalComparer : IEqualityComparer<BasketTotal>
    {
        public bool Equals(BasketTotal x, BasketTotal y)
        {
            // object equals deal with null values if any
            return object.Equals(x.TotalAmount, y.TotalAmount);
        }

        public int GetHashCode(BasketTotal obj)
        {
            // if more prop1.GethashCode() ^ prop2.GethashCode() ........
            return obj.TotalAmount.GetHashCode();
        }
    }
}

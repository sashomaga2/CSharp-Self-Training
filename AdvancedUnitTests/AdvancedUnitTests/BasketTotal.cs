using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace AdvancedUnitTests
{
   
    public class BasketTotal : IEquatable<BasketTotal>
    {
        private readonly int totalAmount;

        /* implicit conversion basket -> int */
        public static implicit operator int(BasketTotal basketTotal)
        {
            return basketTotal.totalAmount;
        }

        public int TotalAmount
        {
            get { return totalAmount; }
        }

        public BasketTotal(int totalAmount)
        {
            this.totalAmount = totalAmount;
        }

        public bool Equals(BasketTotal other)
        {
            if(other == null)
            {
                return false;
            }

            return totalAmount.Equals(other.totalAmount);
        }

        public override bool Equals(Object obj)
        {
            var basketTotalObj = obj as BasketTotal;
            if (basketTotalObj == null)
            {
                return false;
            }

            return totalAmount.Equals(basketTotalObj.totalAmount);
        }

        public override int GetHashCode()
        {
            return this.totalAmount.GetHashCode();
        }
    }
}
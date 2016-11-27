using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedUnitTests
{
    public interface IBasket
    {
        void ToBasket();
    }

    public class Discount : IBasket
    {
        private readonly decimal amount;

        public Discount(decimal amount)
        {
            this.amount = amount;
        }

        public IBasketVisitor Accept(IBasketVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public decimal Amount
        {
            get { return amount; }
        }

        public void ToBasket()
        {
            // Do something
        }
    }

    public interface IBasketVisitor
    {
        IBasketVisitor Visit(Discount discount);
    }

    
}
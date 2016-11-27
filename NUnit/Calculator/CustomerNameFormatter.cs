using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CustomerNameFormatter : BaseFormater
    {
        public string From(Customer customer)
        {
            var name = ParseBadWordsFrom(customer.Name);
            name = ParseBadWordsFrom(customer.Name);

            return name;
        }
    }

    public class BaseFormater
    {
        public virtual string ParseBadWordsFrom(string name)
        {
            //TODO parse
            return name; 
        }
    }
}

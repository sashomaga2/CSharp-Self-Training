using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class SimpleCalculator
    {

        public int Value { get; private set; } = 0;

        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public double AddDoubles(double a, double b)
        {
            return a + b;
        }

        /***************/

        public void AddToValue(int amount)
        {
            Value += amount;
        }

        public void SubtractFromValue(int amount)
        {
            Value -= amount;
        }
    }
}

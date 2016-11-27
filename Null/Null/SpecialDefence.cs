using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Null
{
    public abstract class SpecialDefence
    {
        public abstract int CalculateDamageReduction(int totalDamage);

        public static SpecialDefence Null { get; } = new NullDefence();

        private class NullSpecialDefence : SpecialDefence
        {
            public override int CalculateDamageReduction(int totalDamage)
            {
                return 0; // Do nothing behaviour
            }
        }
    }
}

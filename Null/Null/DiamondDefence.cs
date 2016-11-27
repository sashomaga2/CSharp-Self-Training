using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Null
{
    public class DiamondDefence : SpecialDefence
    {
        public override int CalculateDamageReduction(int totalDamage)
        {
            return 1;
        }
    }
}

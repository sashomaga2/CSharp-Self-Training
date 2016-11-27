using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Null
{
    class Player
    {
        private readonly SpecialDefence _specialDefence;
        public Player(SpecialDefence specialDefence)
        {
            _specialDefence = specialDefence;
        }

        public void Hit(int damage)
        {
            //int damageReduction = 0;

            ////if (_specialDefence != null)
            //{
            //    damageReduction = _specialDefence.CalculateDamageReduction(damage);
            //}

            //int totalDamageTaken = damage - damageReduction;

            int totalDamageTaken = damage - _specialDefence.CalculateDamageReduction(damage);

            Health -= totalDamageTaken;

            Console.WriteLine($"{Name}'s health has been reduced by {totalDamageTaken} to {Health}");
        }

        public string Name { get; set; }
        public int? DaysSinceLastLogin { get; set; } // null never has logged in
        public DateTime? DateOfBirth { get; set; }
        public bool? IsNoob { get; set; }

        public int Health { get; set; } = 100;

    }
}

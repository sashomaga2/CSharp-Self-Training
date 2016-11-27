using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Null
{
    class PlayerDisplayer
    {
        public static void Write(Player player)
        {

            if(string.IsNullOrWhiteSpace(player.Name))
            {
                Console.WriteLine("Player name not set");
            }
            else
            {
                Console.WriteLine(player.Name);
            }
            
            if(player.DaysSinceLastLogin.HasValue)
            {
                Console.WriteLine(player.DaysSinceLastLogin.Value);
            }
            else
            {
                Console.WriteLine("Player has never logged in");
                
            }


            //int days = player.DaysSinceLastLogin ?? -1;
            int days = player.DaysSinceLastLogin.GetValueOrDefault(-1);

            Console.WriteLine($"{days} since last login");



            if(player.IsNoob == null)
            {
                Console.WriteLine("Player status unknown");
            }
            else if(player.IsNoob == true)
            {
                Console.WriteLine("Player is newbie");
            }
            else
            {
                Console.WriteLine("Player is experienced");
            }
        }
    }
}

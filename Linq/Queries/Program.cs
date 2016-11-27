using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            //IEnumerable<Movie> test;

            var numbers = MyLinq.Random().Where(r => r > 0.5).Take(10);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            var movies = new List<Movie>
            {
                new Movie { Title = "The Dark knight", Rating = 8.9f, Year = 2008 },
                new Movie { Title = "The King Speech", Rating = 8.0f, Year = 2010 },
                new Movie { Title = "Casablanca", Rating = 8.5f, Year = 1942 },
                new Movie { Title = "Star Wars V", Rating = 8.7f, Year = 1980 }
            };

            //IEnumerable<Movie> query;
            var query = Enumerable.Empty<Movie>();

            try
            {
                query = movies.Where(m => m.Year >= 2000).OrderByDescending(m => m.Rating);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



            //Console.WriteLine(query.Count());
            var enumerator = query.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Title);
            }


        }
    }
}

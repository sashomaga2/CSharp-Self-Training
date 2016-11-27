using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cars
{

    interface ICovariant<in R> { };

    class Sample<R> : ICovariant<R> { }

    class Program
    {
        static void Main(string[] args)
        {
            //CreateXml();
            //QueryXml();

            //Func<int, int, int> add = (x, y) => x + y;
            Expression<Func<int, int, int>> add = (x, y) => x + y;
            var result = add.Compile()(1,2);

            Console.WriteLine(result);
            Console.WriteLine(add);


            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDb>());
            InsertData();
            QueryData();
        }

        private static void QueryData()
        {
            var db = new CarDb();
            db.Database.Log = Console.WriteLine;
            var query = db.Cars
                    .GroupBy(c => c.Manufacturer)
                    .Select(g => new
                    {
                        Name = g.Key,
                        Cars = g.OrderByDescending(c => c.Combined).Take(2)
                    });

            var query2 = from car in db.Cars
                         group car by car.Manufacturer into g
                         select new
                         {
                             Name = g.Key,
                             Cars = (from car in g
                                     orderby car.Combined descending
                                     select car).Take(2)
                         };

            foreach (var group in query2)
            {
                Console.WriteLine(group.Name);
                foreach (var car in group.Cars)
                {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
            }

            
        }

        private static void InsertData()
        {
            var db = new CarDb();
            db.Database.Log = Console.WriteLine;
            if (!db.Cars.Any()) {
                db.Cars.AddRange(ProcessCars("fuel.csv"));
                db.SaveChanges();
            }
        }

        private static void QueryXml()
        {
            var ns = (XNamespace)"http://pluralsight.com/cars/2016";
            var ex = (XNamespace)"http://pluralsight.com/cars/2016/ex";
            var document = XDocument.Load("fuel.xml");



            var query =
                from element in document.Element(ns +"Cars")?.Elements(ex + "Car") ?? Enumerable.Empty<XElement>()
                where element.Attribute("Manufacturer")?.Value == "BMW"
                select element.Attribute("Name").Value;

            foreach (var name in query)
            {
                Console.WriteLine(name);
            }


        }

        private static void CreateXml()
        {
            var records = ProcessCars("fuel.csv");

            var ns = (XNamespace)"http://pluralsight.com/cars/2016";
            var ex = (XNamespace)"http://pluralsight.com/cars/2016/ex";
            var document = new XDocument();
            var cars = new XElement(ns + "Cars");

            cars.Add(records.Select(r => new XElement(ex + "Car",
                    new XAttribute("Name", r.Name),
                    new XAttribute("Combined", r.Combined),
                    new XAttribute("Manufacturer", r.Manufacturer)
                )));

            cars.Add(new XAttribute(XNamespace.Xmlns + "ex", ex));

            document.Add(cars);
            document.Save("fuel.xml");
        }

        private static void Aggregate()
        {
            var cars = ProcessCars("fuel.csv");
            var manufacturers = processManufacturers("manufacturers.csv");

            var query =
                from car in cars
                group car by car.Manufacturer
                into g
                select new
                {
                    Manufacturer = g.Key,
                    Min = g.Min(c => c.Combined),
                    Max = g.Max(c => c.Combined),
                    Average = g.Average(c => c.Combined)
                } into result
                orderby result.Max descending
                select result;

            var query2 = cars.GroupBy(c => c.Manufacturer).Select(g =>
            {
                var result = g.Aggregate(new CarStatistics(), (acc, c) => acc.Accumulate(c), acc => acc.Compute());
                return new
                {
                    Name = g.Key,
                    Max = result.Max,
                    Min = result.Min,
                    Average = result.Average
                };
            }).OrderByDescending(r => r.Max);

            foreach (var group in query2)
            {
                Console.WriteLine(group.Name);
                Console.WriteLine($"\tMin: {group.Min}");
                Console.WriteLine($"\tMax: {group.Max}");
                Console.WriteLine($"\tAverage: {group.Average}");
            }
        }

        private static void GroupJoinCountry()
        {
            var cars = ProcessCars("fuel.csv");
            var manufacturers = processManufacturers("manufacturers.csv");

            var query2 =
                    from manufacturer in manufacturers
                    join car in cars
                    on manufacturer.Name equals car.Manufacturer
                    group car by manufacturer.Headquarters into carGroup
                    orderby carGroup.Key
                    select carGroup;

            var query =
                from manufacturer in manufacturers
                join car in cars
                on manufacturer.Name equals car.Manufacturer
                into carGroup
                orderby manufacturer.Headquarters
                select new
                {
                    Manufacturer = manufacturer,
                    Cars = carGroup
                } into result
                group result by result.Manufacturer.Headquarters;

            var query3 = manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, (m, g) => new { Manufacturer = m, Cars = g })
                .OrderBy(m => m.Manufacturer.Headquarters)
                .GroupBy(m => m.Manufacturer.Headquarters);

            foreach (var group in query3)
            {
                Console.WriteLine($"{group.Key}");
                foreach (var car in group.SelectMany(g => g.Cars).OrderByDescending(c => c.Combined).Take(3))
                {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
            }
        }

        private static void GroupJoin(List<Car> cars, IList<Manufacturer> manufacturers)
        {
            var query =
                from manufacturer in manufacturers
                join car in cars
                on manufacturer.Name equals car.Manufacturer
                into carGroup
                orderby manufacturer.Name
                select new
                {
                    Country = manufacturer,
                    Cars = carGroup
                };

            var query2 = manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, (m, g) => new { Manufacturer = m, Cars = g }).OrderBy(m => m.Manufacturer.Name);
        }

        private static IOrderedEnumerable<IGrouping<string, Car>> GroupAndOrder(List<Car> cars)
        {
            var query =
                                from car in cars
                                group car by car.Manufacturer.ToUpper() into m
                                orderby m.Key
                                select m;

            var query2 = cars.GroupBy(c => c.Manufacturer.ToUpper())
                                .OrderBy(m => m.Key);
            return query;
        }

        private static void JoinQueries(List<Car> cars, IList<Manufacturer> manufacurers)
        {
            var query = from car in cars
                        join manufacturer in manufacurers
                        on new { car.Manufacturer, car.Year } equals new { Manufacturer = manufacturer.Name, manufacturer.Year }
                        orderby car.Combined descending, car.Name
                        select new
                        {
                            car.Combined,
                            car.Name,
                            manufacturer.Headquarters
                        };

            var query2 = cars.Join(manufacurers,
                                    c => new { c.Manufacturer, c.Year },
                                    m => new { Manufacturer = m.Name, m.Year },
                                    (c, m) => new
                                    {
                                        c.Combined,
                                        c.Name,
                                        m.Headquarters
                                    }).OrderByDescending(c => c.Combined).ThenBy(c => c.Name);


            foreach (var car in query2.Take(10))
            {
                Console.WriteLine($"{car.Name} : {car.Headquarters} => {car.Combined}");
            }
        }

        private static IList<Manufacturer> processManufacturers(string path)
        {
            return File.ReadAllLines(path).Where(l => l.Length > 1).Select(Manufacturer.ParseFromCsv).ToList();
        }

        private static List<Car> ProcessCars(string path)
        {
            return File.ReadAllLines(path)
                        .Skip(1)
                        .Where(line => line.Length > 1)
                        .ToCar()
                        .ToList();
        }

    }

    public static class CarExtensions
    {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                yield return Car.ParseFromCsv(line);
            }
        }
    }

    public class CarStatistics
    {

        public CarStatistics()
        {
            Max = Int32.MinValue;
            Min = Int32.MaxValue;
        }

        public int Max { get; set; }
        public int Min { get; set; }
        public double Average { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }

        public CarStatistics Accumulate(Car car)
        {
            var combined = car.Combined;
            Max = Math.Max(Max, combined);
            Min = Math.Min(Min, combined);
            Total += combined;
            Count += 1;

            return this;
        }

        public CarStatistics Compute()
        {
            Average = Total / Count;
            return this;
        }
    }
}


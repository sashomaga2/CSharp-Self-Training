using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTips
{
    public enum Steps
    {
        Step1,
        Step2,
        Step3
    }

    public static class StringExtensions
    {
        public static TEnum ParceEnum<TEnum>(this string value) where TEnum: struct
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var input = "Step1";
            //Steps value = (Steps)Enum.Parse(typeof(Steps), input);
            //var value = input.ParceEnum<Steps>();

            //var numbers = new double[] { 1, 2, 3, 4, 5, 6 };
            //var result = SampleAverage(numbers);
            //Console.WriteLine(result);

            //var list = new List<Item>();
            //list.Add(new Item<int>());
            //list.Add(new Item<double>());

            var i1 = new Item<int>();
            var i2 = new Item<int>();
            var i3 = new Item<string>();

            Console.WriteLine(Item<int>.InstanceCount);
            Console.WriteLine(Item<string>.InstanceCount);
        }



        //private static T SampleAverage<T>(T[] numbers)
        //{
        //    var count = 0;
        //    var sum = 0.0;
        //    for (int i = 0; i < numbers.Length; i+=2)
        //    {
        //        sum += numbers[i];
        //        count++;
        //    }
        //    return sum / count;
        //}
    }

    //public class Item<T> : Item
    //{

    //}

    public class Item<T>
    {
        public Item()
        {
            InstanceCount += 1;
        }

        public static int InstanceCount;
    }
}

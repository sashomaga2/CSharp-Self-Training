using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace Grade
{
    class Program
    {

        public static float MIN = 0;
        public static float MAX = 100;
       
        static void Main(string[] args)
        {
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello this is simple book program!");

            IGradeTracker g1 = CreateGradeBook();

            foreach (float grade in g1)
            {
                Console.WriteLine("Grade: " + grade);
            }

            AttachSubscribers(g1);
            NameBook(g1, "Pesho");
            AddGrades(g1);
            WriteGrades(g1);
            ShowGrades(g1);

            //Console.ReadLine();

        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void ShowGrades(IGradeTracker g1)
        {
            GradeStatistics stats = g1.ComputeStatistics();
            WriteResult("Average", stats.average);
            WriteResult("Min", (int)stats.lowest);
            WriteResult("Max", stats.highest);
            WriteResult("Letter", g1.LetterGrade);
            WriteResult("Description", g1.Description);
        }

        private static void WriteGrades(IGradeTracker g1)
        {
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                g1.WriteGrades(outputFile);
            }

            g1.WriteGrades(Console.Out);
        }

        private static void AttachSubscribers(IGradeTracker g1)
        {
            g1.NameChanged += new NameChangedDelegate(OnNameChanged);
            g1.NameChanged += new NameChangedDelegate(OnNameChanged2);
        }

        private static void AddGrades(IGradeTracker g1)
        {
            g1.AddGrade(45);
            g1.AddGrade(45.5f);
            g1.AddGrade((float)20.4);
        }

        private static void NameBook(IGradeTracker g1, string name)
        {
            try
            {
                g1.Name = name;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"old: {args.existingName}, new: {args.newName}");
        }static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"****old: {args.existingName}, new: {args.newName}");
        }

        static void Test(params int[] data)
        {

        }

        static void WriteResult(string desc, float result)
        {
            //Console.WriteLine(desc + ": " + result);
            //Console.WriteLine("{0}: {1:F2}", desc, result);
            Console.WriteLine($"{desc}: {result:F2}");
        }static void WriteResult(string desc, string result)
        {
            Console.WriteLine(desc + ": " + result);
        }


    }
}

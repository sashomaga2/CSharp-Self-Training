using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade
{
    public enum PayrollType
    {
        Contractor = 1,
        Salaried,
        Executive,
        Hourly
    }
    public class GradeBook : GradeTracker
    {
        protected List<float> grades;

        // raw delegate
        //public NameChangedDelegate NameChanged;   

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine($"grade: {grades[i]}");
            }
        }

        /* auto implemented property */
        public string test
        {
            get;
            set;
        }

        public GradeBook()
        {
            grades = new List<float>();
            _name = "Empty";
        }

        public override void AddGrade(float grade)
        {
            grades.Add(grade);

        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("****Invoke bace compute statistics");
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;

            foreach (float grade in grades)
            {
                sum += grade;
            }

            _average = stats.average = sum / grades.Count;
            stats.lowest = grades.Min();
            stats.highest = grades.Max();

            return stats;
        }
    }
}

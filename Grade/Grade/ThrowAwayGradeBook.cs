using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade
{
    class ThrowAwayGradeBook : GradeBook
    {
        public override GradeStatistics ComputeStatistics()
        {
            //float min = 
            Console.WriteLine("****Invoke inherited compute statistics");
            grades.Remove(grades.Min());

            return base.ComputeStatistics();
        }
    }
}

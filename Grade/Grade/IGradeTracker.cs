using System.Collections;
using System.IO;

namespace Grade
{
    internal interface IGradeTracker : IEnumerable
    {
        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();
        void WriteGrades(TextWriter destitnation);
        string Name { get; set; }
        string Description { get; }        
        string LetterGrade { get; }
        event NameChangedDelegate NameChanged;
    }
}
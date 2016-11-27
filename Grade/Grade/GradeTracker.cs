using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade
{
    public abstract class GradeTracker : IGradeTracker
    {
        // I dont know where grade will be stored just give ability to add grades
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destitnation);

        protected string _name;
        // event
        public event NameChangedDelegate NameChanged;

        public abstract IEnumerator GetEnumerator();

        protected float _average;
        public string Description
        {
            get
            {
                string desc;
                switch (LetterGrade)
                {
                    case "A":
                        desc = "Very good";
                        break;
                    case "B":
                    case "C":
                        desc = "Not that good";
                        break;
                    default:
                        desc = "bad";
                        break;
                }
                return desc;
            }
        }
        public string LetterGrade
        {
            get
            {
                //GradeStatistics stats = this.ComputeStatistics();
                string result;
                if (_average >= 90)
                {
                    result = "A";
                }
                else if (_average >= 80)
                {
                    result = "B";
                }
                else
                {
                    result = "C";
                }

                return result;
            }
        }
        public string Name
        {
            get
            {
                return _name;
                // can return _name.toupperCase ....
            }
            set
            {

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("can't be null or empty");
                }

                if (_name != value && NameChanged != null)
                {
                    //call delagate
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.existingName = _name;
                    args.newName = value;
                    NameChanged(this, args);
                }

                _name = value;

            }
        }

    }
}

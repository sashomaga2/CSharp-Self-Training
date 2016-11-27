using Grade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.types
{
    [TestClass]
    public class TypesTests
    {
        [TestMethod]
        public void DateTimeIncrement()
        {
            DateTime date = new DateTime(1975, 10, 20);

            date.AddDays(1);

            //Assert.AreEqual(DateTime.Compare(date, new DateTime(1975, 10, 20)), 0);
            //Assert.AreEqual(date.Hour, 1);
            Assert.AreEqual(date.Minute, 0);
        }

        [TestMethod]
        public void Arrays()
        {
            const int numberOfStudents = 4;

            int[] scores = new int[numberOfStudents];

            //scores[0] = 1;
            //scores[1] = 1;
            //scores[2] = 1;
            //scores[3] = 2;

            //int sum = 0;

            //foreach(int score in scores)
            //{
            //    sum += score;
            //}

            Assert.AreEqual(scores.Length, numberOfStudents);
            //Assert.AreEqual(sum, 5);
            Assert.AreEqual(scores[0], 0);
        }

        [TestMethod]
        public void ValueTypesPassedByValue()
        {
            int x = 0;

            IncrementNumber(ref x);

            Assert.AreEqual(x, 1);
        }

        private void IncrementNumber(ref int num)
        {
            num += 1;
        }

        [TestMethod]
        public void ReferenceTypesPassedByValue()
        {
            GradeBook book = new GradeBook();
            book.Name = "Pesho";
            GiveBookAName(book, "Sasho");

            Assert.IsTrue(String.Equals(book.Name, "Sasho"));
        }
 
        private void GiveBookAName(GradeBook book, string name)
        {
            book.Name = name;
        }

        [TestMethod]
        public void MyTestMethod()
        {
            int x1 = 100;
            int x2 = 4;

            x1 = 4;
            Assert.AreEqual(x1, x2);
        }

        [TestMethod]
        public void StringComparison()
        {
            string name1 = "Sasho";
            string name2 = "sasho";

            bool result = String.Equals(name1, name2, System.StringComparison.InvariantCultureIgnoreCase);


            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ReferenceVariables()
        {

            GradeBook b1 = new GradeBook();
            GradeBook b2 = new GradeBook();

            b2 = b1;

            b1.Name = "Pesho";

            Assert.AreEqual(b1.Name, b2.Name);
        }
    
    }
}

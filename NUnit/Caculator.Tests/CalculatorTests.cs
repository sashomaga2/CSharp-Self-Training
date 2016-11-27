using Calculator;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCaculator.Tests
{
    [TestFixture]
    public class SimpleCalculatorTests
    {
        private SimpleCalculator sut;

        [Test]
        public void ShouldAddInts()
        {
            Assert.That(sut.Add(2, 3), Is.EqualTo(5));
        
        }

        [Test]
        public void ShouldAddDoubles_WithTolerance()
        {
            Assert.That(sut.AddDoubles(1d, 2.2), Is.EqualTo(3.2).Within(0.01));
        }

        #region Fixture

        [TestFixtureSetUp]
        public void BeforeAnyTestStarted()
        {
            Console.WriteLine("Before all");
        }

        [TestFixtureTearDown]
        public void AfterAllTestFinished()
        {
            Console.WriteLine("After all");
        }

        #endregion

        [Test]
        public void ShouldMultiplyTwoNumbers()
        {
            Assert.That(sut.Multiply(2, 3), Is.EqualTo(6));
        }

        [Test]
        public void ShouldAddToValue()
        {
            sut.AddToValue(5);
            sut.AddToValue(10);
            Assert.That(sut.Value, Is.EqualTo(15));
        }

        [Test]
        public void ShouldSubtractFromValue()
        {
            sut.SubtractFromValue(5);
            Assert.That(sut.Value, Is.EqualTo(-5));
        }

        [TestCaseSource(typeof(ExampleTestCaseData))]
        public void ShouldSubtractTwoNegativeNumbers(int firstNum, int secondNum, int expectedNum)
        {
            sut.SubtractFromValue(firstNum);
            sut.SubtractFromValue(secondNum);
            Assert.That(sut.Value, Is.EqualTo(expectedNum));
        }

        [SetUp]
        public void BeforeEachTest()
        { 
            sut = new SimpleCalculator();
        }

        [TearDown]
        public void AfterEachTest()
        {
            sut = null;
        }


    }

    public class ExampleTestCaseData : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new[] { -5, -10, 15 };
            yield return new[] { -1, -2, 3 };
            yield return new[] { 0, 0, 0 };
        }
    }
}

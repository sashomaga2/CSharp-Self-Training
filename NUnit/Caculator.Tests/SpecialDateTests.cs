using Calculator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Tests
{
    [TestFixture]
    public class SpecialDateTests
    {
        [Test]
        public void ShoudHaveCorrectMilleniumDate()
        {
            var sut = new SpecialDateStore();

            var result = sut.DateOf(SpecialDates.NewMillennium);

            Assert.That(result, Is.EqualTo(new DateTime(2000, 1, 1, 0, 0, 0, 0)));
        }
    }
}

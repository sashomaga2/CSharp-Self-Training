using Caculator.Tests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    [TestFixture]
    public class NameJoinerTests
    {
        [Test]
        public void ShouldJoinNames()
        {
            var sut = new NameJoiner();
            var fullName = sut.Join("Sarah", "Smith");

            Assert.That(fullName, Is.EqualTo("Sarah Smith").IgnoreCase);
        }
    }
}

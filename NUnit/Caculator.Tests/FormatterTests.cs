using Calculator;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caculator.Tests
{
    public interface IReadable
    {
        string Read();
    }

    [TestFixture]
    public class FormatterTests
    {

        [Test]
        public void FormatterShoudCallBaseParseBadWOrds()
        {
            //Arrange
            var mockNameFormatter = new Mock<CustomerNameFormatter>();

            //Act
            mockNameFormatter.Object.From(new Customer("Pesho", "Lom"));

            //Assert
            mockNameFormatter.Verify(x => x.ParseBadWordsFrom(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        [TestCase("first", "second", "third")]
        public void Test(params string[] data)
        {
            var obj = new Mock<IReadable>();
            obj.SetupSequence(o => o.Read()).Returns(data[0]).Returns(data[1]).Returns(data[2]);

            Assert.AreEqual(obj.Object.Read(), data[0]);
            Assert.AreEqual(obj.Object.Read(), data[1]);
            Assert.AreEqual(obj.Object.Read(), data[2]);
        }
    }
}

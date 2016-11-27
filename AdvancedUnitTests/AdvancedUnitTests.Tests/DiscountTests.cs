using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedUnitTests.Tests
{
    [TestFixture]
    public class DiscountTests
    {
        [Test]
        [TestCase(0.41)]
        [TestCase(12.49)]
        [TestCase(1000.88)]
        public void AmountIsCorrect(decimal amount)
        {
            // Arrange
            var sut = new Discount(amount);


            //Assert
            /* TDD expose given properties */
            Assert.AreEqual(expected: amount, actual: sut.Amount);
        }

        //[Test]
        //public void SutIsBasketElement()
        //{
        //    var sut = new Discount(3);

        //    Assert.IsAssignableFrom<IBasket>(sut);
        //}

        [Test]
        public void AcceptReturnsCorrectResponse()
        {
            var expected = new Mock<IBasketVisitor>().Object;
            var sut = new Discount(12);

            var visitorStub = new Mock<IBasketVisitor>();
            visitorStub.Setup(v => v.Visit(sut)).Returns(expected);

            var actual = sut.Accept(visitorStub.Object);

            Assert.AreSame(expected, actual);
        }

        [Test]
        [TestCase(1, 1, true)]
        [TestCase(1, 2, false)]
        [TestCase(2, 2, true)]
        public void EqualsOtherBasketTotal(int totalAmount, int otherAmount, bool expected)
        {
            var sut = new BasketTotal(totalAmount);
            var other = new BasketTotal(otherAmount);

            var actual = sut.BothEquals(other);

            // Available due to implicit conversion
            //int a = sut;

            //Assert.True(actual.All(expected.Equals));
            Assert.True(actual.All(e => e.Equals(expected)));
        }
    }
}

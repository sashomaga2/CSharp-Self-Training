using AdvancedUnitTests.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace AdvancedUnitTests.Tests
{
    [TestFixture]
    public class ShopControllerTests
    {
        [Test]
        public void ShouldSetShopName()
        {
            // Arrange
            ShopController sut = new ShopControllerBuilder().WithShopName("Metro");

            //Assert
            Assert.AreEqual(expected:"Metro", actual:sut.ShopName);
        }

        [Test]
        public void ShouldSetEmployeeCount()
        {
            // Arrange
            var sut = new ShopControllerBuilder().WithEmploeeCount(3).Build();

            //Assert
            Assert.AreEqual(expected: 3, actual: sut.EmployeeCount);
        }

        //private ShopController CreateShopController()
        //{
        //    return new ShopController("Metro", 3);
        //}
    }
}

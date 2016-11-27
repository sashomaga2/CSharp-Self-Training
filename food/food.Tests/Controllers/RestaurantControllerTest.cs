using food.Controllers;
using food.Models;
using food.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace food.Tests.Controllers
{
    [TestClass]
    public class RestaurantControllerTest
    {
        [TestMethod]
        public void Create_Saves_Restaurant_When_Valid()
        {
            var db = new FakeFoodDb();
            var controller = new RestaurantController();

            controller.Create(new Restaurant());

            Assert.AreEqual(1, db.Added.Count);
            Assert.AreEqual(true, db.Saved);
        }

        [TestMethod]
        public void Create_Does_Not_Save_Restaurant_When_Invalid()
        {
            var db = new FakeFoodDb();
            var controller = new RestaurantController();
            controller.ModelState.AddModelError("", "Invalid");

            controller.Create(new Restaurant());

            Assert.AreEqual(0, db.Added.Count);
        }

    }
}

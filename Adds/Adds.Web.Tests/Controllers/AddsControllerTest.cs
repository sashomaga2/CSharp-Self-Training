using Adds.Entities;
using Adds.Web.Controllers;
using Adds.Web.Tests.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Adds.Web.Tests.Controllers
{
    [TestClass]
    public class AddsControllerTest
    {
        [TestMethod]
        public void Index_ShouldReturnAllAdds()
        {
            var context = new TestStoreAppContext();
            context.Adds.Add(new Add { Id = 1, Title = "Title1", Context = "Context1" });
            context.Adds.Add(new Add { Id = 2, Title = "Title2", Context = "Context2" });
            context.Adds.Add(new Add { Id = 3, Title = "Title3", Context = "Context3" });

            var AddsController = new AddsController(context);
            var result = AddsController.Index() as ViewResult;

            Assert.IsNotNull(result);

            var resultList = result.ViewData.Model as IList<Add>;

            Assert.AreEqual(3, resultList.Count());
        }

        [TestMethod]
        public void DeleteAdd_ShouldReturnSelectedItem()
        {
            var context = new TestStoreAppContext();
            var add = GetTestAdd();
            context.Adds.Add(add);            
            var controller = new AddsController(context);
            
            var result = controller.Delete(add.Id) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.ViewData.Model, add);
        }

        [TestMethod]
        public void Details()
        {
            var context = new TestStoreAppContext();
            var add = GetTestAdd();

            context.Adds.Add(add);

            var AddsController = new AddsController(context);
            var result = AddsController.Details(3) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Model, add);
        }


        private Add GetTestAdd()
        {
            return new Add() { Id = 3, Title = "Demo title", Context = "Demo context" };
        }
    }
}

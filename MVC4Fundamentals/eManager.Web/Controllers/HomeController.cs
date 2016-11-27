using eManager.Domain;
using eManager.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    public class HomeController : Controller
    {

        private IDepartmentDataSource _db;

        public HomeController(IDepartmentDataSource db)
        {
            _db = db;
        }

        //public HomeController()
        //{
        //    _db = new DepartmentDb();
        //}

        public ActionResult SayHello()
        {
            return Content("Raboti");
        }

        public ActionResult Index()
        {
            var allDepartments = _db.Departments;
            return View(allDepartments);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
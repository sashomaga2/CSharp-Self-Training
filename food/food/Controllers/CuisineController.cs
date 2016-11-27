using food.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace food.Controllers
{
    public class CuisineController : Controller
    {
        // GET: Cuisine
        [HttpGet] 
        //[Authorize]
        [Log]
        public ActionResult Search(string name = "french")
        {
            //throw new Exception("Something terrible has happned!");
            var message = Server.HtmlEncode(name);

            return Content("Hello! " + message);

            
            //return View();

            //return new HttpNotFoundResult();
            //return RedirectToAction("Index", "Home");
            //return File(Server.MapPath("~/Content/site.css"), "text/css"); 
            //return Json(new { Message=message, Name = "Sasho" }, JsonRequestBehavior.AllowGet); 
        }
    }
}
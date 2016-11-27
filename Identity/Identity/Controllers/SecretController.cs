using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    public class SecretController : Controller
    {
        // GET: Secret
        [Authorize]
        public ContentResult Index()
        {
            return Content("This is Secret!");
        }

        public ContentResult Overt()
        {
            return Content("Not Secret");
        }
    }
}
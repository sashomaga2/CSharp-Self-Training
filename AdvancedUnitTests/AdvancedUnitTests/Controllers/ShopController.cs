using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AdvancedUnitTests.Controllers
{
    public class ShopController : ApiController
    {
        public string ShopName { get; private set; }
        public int EmployeeCount { get; private set; }
        public int Area { get; private set; }
        public int Floors { get; private set; }

        public ShopController(string shopName, int employeeCount, int area, int floors)
        {
            ShopName = shopName;
            EmployeeCount = employeeCount;
            Area = area;
            Floors = floors;
        }
        
               
    }
}
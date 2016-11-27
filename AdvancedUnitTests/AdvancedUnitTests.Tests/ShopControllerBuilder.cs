using AdvancedUnitTests.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedUnitTests.Tests
{
    public class ShopControllerBuilder
    {
        private string shopName;
        private int employeeCount;
        private int area;
        private int floors;

        // using the constructor to provide default values
        internal ShopControllerBuilder()
        {
            shopName = "Metro";
            employeeCount = 10;
            area = 100;
            floors = 1;
        }

        /// <summary>
        /// User defined conversion from ShopControllerBuilder to ShopController
        /// </summary>
        /// <param name="builder"></param>
        public static implicit operator ShopController(ShopControllerBuilder builder)
        {
            return builder.Build();
        }

        #region Field setters

        internal ShopControllerBuilder WithShopName(string shopName)
        {
            this.shopName = shopName;
            return this;
        }

        internal ShopControllerBuilder WithEmploeeCount(int employeeCount)
        {
            this.employeeCount = employeeCount;
            return this;
        }

        #endregion


        #region Helper methods

        internal ShopControllerBuilder LargeShop()
        {
            employeeCount = 100;
            area = 1000;
            floors = 1;

            return this;
        }

        internal ShopControllerBuilder WithManyFloors()
        {
            floors = 5;

            return this;
        }

        internal ShopControllerBuilder WithLittleFloors()
        {
            floors = 1;

            return this;
        }


        internal ShopController Build()
        {
            return new ShopController(shopName, employeeCount, area, floors);
        }

        #endregion
    }
}

using Bellatrix.Assertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellatrix.Web.GettingStarted._20._Add_Custom_WebDriver_Capabilities_and_Options
{
    public partial class CartPageVic
    {
        public void AssertCouponAddedSuccessfuly()
        {
            Assert.AreEqual("Coupon code applied successfully.", MessageAlertDiv.InnerText);
        }

        public void AssertCartUpdated()
        {
            Assert.AreEqual("Cart updated.", MessageAlertDiv.InnerText);
        }

        public void AssertCorrectTotalPrice(string expectedTotalPrice)
        {
            Assert.AreEqual(expectedTotalPrice, TotalPriceSpan.InnerText);
        }
    }
}

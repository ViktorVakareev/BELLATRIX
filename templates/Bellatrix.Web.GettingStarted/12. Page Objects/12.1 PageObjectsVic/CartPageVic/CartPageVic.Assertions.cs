using Bellatrix.Assertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellatrix.Web.GettingStarted._12._1_PageObjectsVic.CartPageVic
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

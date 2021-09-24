using Bellatrix.Web.GettingStarted._12._1_PageObjectsVic.CartPageVic;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

////1. Purchase random Rocket using Page Object Model
////2.Turn on the HTTP capturing
////3. Add proxy service assertions
////4. Redirect some of the requests made

namespace Bellatrix.Web.GettingStarted
{
    [TestFixture]
    [Browser(BrowserType.Chrome, Lifecycle.RestartEveryTime)]////, shouldCaptureHttpTraffic: true)]
    public class PageObjectTestsVic : NUnit.WebTest
    {
        [Test]
        public void PurchaseRocketUsingPageObjectsModel()
        {
            var homePage = App.GoTo<HomePageVic>();

            homePage.AddProductByName("Falcon 9");
            homePage.ClickViewCartButton();

            var cartPage = App.GoTo<CartPageVic>();

            cartPage.ApplyCoupon("happybirthday");
            cartPage.AssertCouponAddedSuccessfuly();

            cartPage.UpdateProductQuantityByName("Falcon 9", 3);
            cartPage.AssertCartUpdated();
            cartPage.AssertCorrectTotalPrice("174.00€");
            cartPage.ProceedToCheckoutButtton.Click();

            var billingData = new BillingDataVic
            {
                FirstName = "John",
                LastName = "Whick",
                Company = "Automate The Planet Ltd.",
                Country = "Colombia",
                Address1 = "5th Avenue",
                Address2 = "6th Avenue",
                City = "New York",
                State = "New York",
                Zip = "08751",
                Phone = "+0035989999999",
                Email = "john@wick.wbs",
                ShouldCreateAccount = true,
                OrderComments = "John's account",
            };

            var checkoutPage = App.GoTo<CheckoutPageVic>();

            checkoutPage.FillBillingData(billingData);
            checkoutPage.ChoosePaymentMethod("Check Payments");

            ////App.ProxyService.AssertNoLargeImagesRequested();
            ////App.ProxyService.AssertNoErrorCodes();
            ////App.ProxyService.AssertRequestNotMade("http://demos.bellatrix.solutions/welcome");

            checkoutPage.PlaceOrderButton.Click();
        }
    }
}

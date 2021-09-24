using Bellatrix.Web.GettingStarted._12._1_PageObjectsVic.CartPageVic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

////0. Purchase random Rocket using Page Object Model
////1. Open the tests that you made in the page objects section
////2. Use the Browser attribute to control the driver creation
////3. Use Firefox for browser
////4. Add custom FirefoxOptions and set the logging level to verbose

namespace Bellatrix.Web.GettingStarted._20._Add_Custom_WebDriver_Capabilities_and_Options
{
    [TestFixture]
    [Browser(BrowserType.Firefox, Lifecycle.RestartEveryTime)]
    public class PageObjectTestsVic : NUnit.WebTest
    {
        public override void TestsArrange()
        {
            var firefoxOptions = new FirefoxOptions
            {
                AcceptInsecureCertificates = true,
                UnhandledPromptBehavior = UnhandledPromptBehavior.Accept,
                PageLoadStrategy = PageLoadStrategy.Eager,
            };

            // 2. Add custom WebDriver options.
            App.AddWebDriverOptions(firefoxOptions);

            // 3. Add custom WebDriver capability.
            App.AddAdditionalCapability("disable-popup-blocking", true);

            // 4. Add an existing Firefox profile. You may want to test your application in together with some specific browser extension.
            var profileManager = new FirefoxProfileManager();
            FirefoxProfile profile = profileManager.GetProfile("Bellatrix");

            App.AddWebDriverBrowserProfile(profile);
        }

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
            checkoutPage.PlaceOrderButton.Click();
        }
    }
}

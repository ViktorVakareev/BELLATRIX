using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

////1. Create a new MSTest test class
////2. Use the BELLATRIX Browser attribute so that you execute all tests in Firefox and restart the browser every time.
////3. Navigate to http://demos.bellatrix.solutions/
////4. Create a test where you search for the product Saturn V (upper right corner)
////5. Add the product to the cart and navigate to it
////6. Navigate to checkout, do not fill the date and click proceed
////7. Verify all validation messages
////8. Verify Your Order Data
////Note: Use regular Assert methods

namespace Bellatrix.Web.GettingStarted
{
    [TestFixture]
    [Browser(BrowserType.Chrome, Lifecycle.RestartEveryTime)]
    public class NormalAssertionsVic : NUnit.WebTest
    {
        public override void TestInit() => App.Navigation.Navigate("https://demos.bellatrix.solutions");

        [Test]
        public void AddRocketToCart_Then_NavigateToCheckout_VerifyValidationMessages_VerifyOrderData()
        {
            string rocketName1 = "Saturn V";
            var searchTextBox = App.Components.CreateByXpath<TextField>("(//input[@type='search'])[1]").ToBeClickable().ToExists();
            var viewCartLink = App.Components.CreateByXpath<Button>("//a[@class='added_to_cart wc-forward']").ToBeVisible().ToExists();
            var addToCartButton = App.Components.CreateByInnerTextContaining<Button>("Add to cart");
            var proceedToCheckoutButton = App.Components.CreateByInnerTextContaining<Button>("Proceed to checkout");
            var placeOrderButton = App.Components.CreateByInnerTextContaining<Button>("Place order").ToBeClickable().ToBeClickable();
            var validationMessages = App.Components.CreateByClass<Div>("woocommerce-error");
            var totalPrice = App.Components.CreateByXpath<Span>("//*[@class='order-total']//span");

            searchTextBox.SetText(rocketName1 + Keys.Enter);
            addToCartButton.Click();
            viewCartLink.Click();
            App.Browser.WaitUntilReady();

            Assert.AreEqual("120.00€", totalPrice.InnerText);

            proceedToCheckoutButton.Click();
            App.Browser.WaitForAjax();
            placeOrderButton.ScrollToVisible();
            placeOrderButton.Click();

            Assert.IsTrue(validationMessages.IsVisible);
            var validationMessagesList = App.Components.CreateAllByXpath<Div>("//ul[@class='woocommerce-error']/li").ToList();
            Bellatrix.Assertions.Assert.Multiple(
                () => Assert.AreEqual("Billing First name is a required field.", validationMessagesList[0].InnerText),
                () => Assert.AreEqual("Billing Last name is a required field.", validationMessagesList[1].InnerText),
                () => Assert.AreEqual("Billing Street address is a required field.", validationMessagesList[2].InnerText),
                () => Assert.AreEqual("Billing Town / City is a required field.", validationMessagesList[3].InnerText),
                () => Assert.AreEqual("Billing Postcode / ZIP is a required field.", validationMessagesList[4].InnerText),
                () => Assert.AreEqual("Billing Phone is a required field.", validationMessagesList[5].InnerText),
                () => Assert.AreEqual("Billing Email address is a required field.", validationMessagesList[6].InnerText));
        }
    }
}
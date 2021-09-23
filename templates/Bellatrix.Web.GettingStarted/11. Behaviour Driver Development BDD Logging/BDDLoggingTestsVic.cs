using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
//// 1. Execute some of your already written tests
//// 2. Open the test's output and check the BDD log
//// 3. Open the tests' DLLs folder and locate the log.txt file
//// 4. Locate the testFrameworkSettings file and change some of the logs settings
//// 5. Change the outputTemplate following the official documentation and rerun your tests
/// </summary>
namespace Bellatrix.Web.GettingStarted
{
    [TestFixture]
    [Browser(BrowserType.Chrome, Lifecycle.RestartEveryTime)]
    public class BDDLoggingTestsVic : NUnit.WebTest
    {
        public override void TestInit() => App.Navigation.Navigate("https://demos.bellatrix.solutions");

        [Test]
        public void AddRocketToCart_Then_NavigateToCheckout_VerifyValidationMessages_VerifyOrderData_BDDLogging()
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

            totalPrice.ValidateInnerTextIs("120.00€");

            proceedToCheckoutButton.Click();
            App.Browser.WaitForAjax();
            placeOrderButton.ScrollToVisible();
            placeOrderButton.Click();

            validationMessages.ValidateIsVisible();

            var validationMessagesList = App.Components.CreateAllByXpath<Div>("//ul[@class='woocommerce-error']/li").ToList();

            Bellatrix.Assertions.Assert.Multiple(
                () => validationMessagesList[0].ValidateInnerTextIs("Billing First name is a required field."),
                () => validationMessagesList[1].ValidateInnerTextIs("Billing Last name is a required field."),
                () => validationMessagesList[2].ValidateInnerTextIs("Billing Street address is a required field."),
                () => validationMessagesList[3].ValidateInnerTextIs("Billing Town / City is a required field."),
                () => validationMessagesList[4].ValidateInnerTextIs("Billing Postcode / ZIP is a required field."),
                () => validationMessagesList[5].ValidateInnerTextIs("Billing Phone is a required field."),
                () => validationMessagesList[6].ValidateInnerTextIs("Billing Email address is a required field."));
        }
    }
}
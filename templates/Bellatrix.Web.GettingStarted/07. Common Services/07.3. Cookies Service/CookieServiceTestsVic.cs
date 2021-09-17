using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellatrix.Web.GettingStarted
{
    ////1. Create a new MSTest test class
    ////2. Use the BELLATRIX Browser attribute so that you execute all tests in Firefox and restart the browser every time.
    ////3. Navigate to http://demos.bellatrix.solutions for each test but don't navigate in the tests body.
    ////4. Create a test where you add the Proton Rocket to your cart.
    ////5. Verify that the correct cookie is created. 
    ////6. Delete all cookies
    ////7. Verify that the cart is empty.

    [TestFixture]
    [Browser(BrowserType.Chrome, Lifecycle.RestartEveryTime)]
    public class CookieServiceTestsVic : NUnit.WebTest
    {
        public override void TestInit() => App.Navigation.Navigate("http://demos.bellatrix.solutions");

        [Test]
        public void AddRocketToCart()
        {
            string rocketName = "Proton Rocket";
            var protonRocketAddToCartButton = App.Components.CreateByXpath<Button>($"(//h2[text()='{rocketName}']/following::a)[1]");
            var viewCartButton = App.Components.CreateByXpath<Button>("//a[@class='added_to_cart wc-forward']").ToBeVisible();
            var lastAddedToCartProduct = App.Components.CreateByXpath<Anchor>("(//td[@class='product-name'])[1]");

            protonRocketAddToCartButton.Click();
            viewCartButton.Click();

            Assert.AreEqual(rocketName, lastAddedToCartProduct.InnerText);
        }

        [Test]
        public void AddProtonRocketToCartThen_DeleteAllCookies_ThenVerifyCartIsEmpty()
        {
            string rocketName = "Proton Rocket";
            var protonRocketAddToCartButton = App.Components.CreateAllByInnerTextContaining<Anchor>("Add to cart")[1];
            var itemsInCartCount = App.Components.CreateByClass<Span>("count");

            protonRocketAddToCartButton.Click();

            var allCookies = App.Cookies.GetAllCookies();

            Assert.IsTrue(allCookies.Count > 0);

            App.Cookies.DeleteAllCookies();
            App.Browser.Refresh();            

            Assert.AreEqual("0 items", itemsInCartCount.InnerText);
        }

        [Test]
        public void AddNewCookie_Then_VerifyCorrectCookieIsCreated()
        {
            App.Cookies.AddCookie("woocommerce_items_in_cart", "3");

            var itemsInCartCookie = App.Cookies.GetCookie("woocommerce_items_in_cart");

            Assert.AreEqual("3", itemsInCartCookie);
        }
    }
}
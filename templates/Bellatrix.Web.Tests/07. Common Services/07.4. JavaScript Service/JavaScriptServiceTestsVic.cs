using Bellatrix.Web.NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellatrix.Web
{
    ////1. Create a new MSTest test class
    ////2. Use the BELLATRIX Browser attribute so that you execute all tests in Firefox and restart the browser every time.
    ////3. Create a test where you add the Proton Rocket to your cart.
    ////4. Navigate to http://demos.bellatrix.solutions/
    ////5. Locate the footer element at the bottom.
    ////6. Use a JavaScript code to scroll down till the footer is visible.

    [TestFixture]
        [Browser(BrowserType.Firefox, Lifecycle.RestartEveryTime)]
        public class JavaScriptServiceTestsVic : WebTest
    {
        public override void TestInit() => App.Navigation.Navigate("https://demos.bellatrix.solutions");
        
        [Test]
        public void AddRocketToCart_Then_ScrollDownToFooterElementUntilItBecomesVisible()
        {
            string rocketName = "Proton Rocket";
            var protonRocketAddToCartButton = App.Components.CreateByXpath<Button>($"(//h2[text()='{rocketName}']/following::a)[1]");
            var viewCartButton = App.Components.CreateByXpath<Button>("//a[@class='added_to_cart wc-forward']").ToBeVisible();
            var lastAddedToCartProduct = App.Components.CreateByXpath<Anchor>("(//td[@class='product-name'])[1]");
            var footerElements = App.Components.CreateByClass<Div>("site-info").ToBeVisible();

            protonRocketAddToCartButton.Click();
            viewCartButton.Click();
            // js to scroll down to footer element
            //App.JavaScript.Execute("document.getElementsByClass('site-info')[0].scrollIntoView();");
            //App.JavaScript.Execute("document.querySelector('.site-info').scrollIntoView();");
            App.JavaScript.Execute("arguments[0].scrollIntoView();", footerElements);
            //App.JavaScript.Execute("window.scrollTo(0,document.body.scrollHeight);");

            Assert.AreEqual(rocketName, lastAddedToCartProduct.InnerText);
            Assert.AreEqual("© Bellatrix Demos 2021Built with Storefront & WooCommerce", footerElements.InnerText);
        }

        [Test]
        [Category(Categories.CI)]
        public void FillUpAllFields()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/my-account/");

            // 2. Execute a JavaScript code on the page. Here we find an element with id = 'firstName' and sets its value to 'Bellatrix'.
            App.JavaScript.Execute("document.geTComponentById('username').value = 'Bellatrix';");

            App.Components.CreateById<Password>("password").SetPassword("Gorgeous");
            var button = App.Components.CreateByClassContaining<Button>("woocommerce-Button button");

            // 3. It is possible to pass an element, and the script executes on it.
            App.JavaScript.Execute("arguments[0].click();", button);
        }

        [Test]
        [Ignore("no need to run")]
        public void GeTComponentStyle()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/");

            var resultsCount = App.Components.CreateByClassContaining<Component>("woocommerce-result-count");

            // 4. Get the results from a script. After that, get the value for a specific style and assert it.
            string fontSize = App.JavaScript.Execute("return arguments[0].style.font-size", resultsCount.WrappedElement.Text);

            Assert.AreEqual("14px", fontSize);
        }      
    }
}

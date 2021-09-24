using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
// 1. Create a new MSTest test class
//2.Use the BELLATRIX Browser attribute so that you execute all tests in Firefox and restart the browser every time.
//3. Create a test where you add the Proton Rocket to your cart. 
//4. Navigate to http://demos.bellatrix.solutions/
//5.Locate Rocket anchor and open it via double click
//6. Navigate to next page through click and hold
//7. Perform all operations in single chain
/// </summary>
namespace Bellatrix.Web.GettingStarted
{
    [TestFixture]
    [Browser(BrowserType.Chrome, Lifecycle.RestartEveryTime)]
    public class InteractionServiceTestsVic : NUnit.WebTest
    {
        public override void TestInit() => App.Navigation.Navigate("https://demos.bellatrix.solutions");

        [Test]
        public void AddRocketToCart_Then_DoubleClickRocketAnchorAndNavigateToNextPageWithClickAndHold()
        {
            string rocketName = "Proton Rocket";
            var protonRocketAddToCartButton = App.Components.CreateByInnerTextContaining<Button>("Add to cart");
            var protonRocketAnchor = App.Components.CreateByAttributesContaining<Anchor>("href", "/proton-rocket/");
            var viewCartLink = App.Components.CreateByXpath<Anchor>("(//a[@class='button wc-forward'])[2]").ToBeVisible().ToExists().ToBeClickable();
            var lastAddedToCartProduct = App.Components.CreateByXpath<Anchor>("(//td[@class='product-name'])[1]");

            App.Interactions.MoveToElement(protonRocketAnchor).DoubleClick().Perform();
            App.Interactions.MoveToElement(protonRocketAddToCartButton).DoubleClick().Perform();
            App.Browser.WaitUntilReady();
            App.Interactions.MoveToElement(viewCartLink).Click().Perform();

            //App.Interactions.MoveToElement(protonRocketAnchor).DoubleClick()
            //.MoveToElement(protonRocketAddToCartButton).DoubleClick()
            //.MoveToElement(viewCartLink).Click().Perform();

            App.Navigation.WaitForPartialUrl("/cart/");

            Assert.AreEqual(rocketName, lastAddedToCartProduct.InnerText);
        }
    }
}

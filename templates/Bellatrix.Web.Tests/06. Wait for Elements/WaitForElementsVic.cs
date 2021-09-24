using Bellatrix.Web.NUnit;
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
    ////3. Navigate to http://demos.bellatrix.solutions/welcome/ for each test but don't navigate in the tests body.
    ////4. Create a test where you click on the Saturn V Sale! Button. Before clicking the button wait for the Huge Rockets link to be visible.

    [TestFixture]
    [Browser(BrowserType.Firefox, Lifecycle.RestartEveryTime)]
    public class WaitForElementsVic : NUnit.WebTest
    {
        public override void TestInit() => App.Navigation.Navigate("https://demos.bellatrix.solutions/welcome/");

        [Test]
        public void SaturnVPageOpened_When_SaleButtonClicked()
        {
            var hugeRocketsLink = App.Components.CreateByInnerTextContaining<Anchor>("Huge Rockets");
            hugeRocketsLink.ToBeVisible();
            var productsColumn = App.Components.CreateByClassContaining<Option>("products columns-4");

            ////var saturnVSaleButton = productsColumn.CreateByClassContaining<Anchor>("woocommerce-LoopProduct-link woocommerce-loop-product__link")
                ////.CreateByInnerTextContaining<Anchor>("Saturn V").CreateByInnerTextContaining<Button>("Sale!");
            ////var saturnVSaleButton = App.Components.CreateByInnerTextContaining<Anchor>("Saturn V").CreateByXpath<Button>("//span[@class='onsale']");
            var saturnVSaleButton = App.Components.CreateByXpath<Anchor>("//h2[(contains(text(),'Saturn V'))]/following::span[1]");
            saturnVSaleButton.ToHasContent();
            var saturnVPageHeader = App.Components.CreateByXpath<Anchor>("//h1");

            saturnVSaleButton.Click();

            App.Navigation.WaitForPartialUrl("/saturn-v/");

            Assert.AreEqual("Saturn V", saturnVPageHeader.InnerText);
        }
    }
}

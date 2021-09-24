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
    ////4. Create a test where you click on the Saturn V Sale! Button via locating the element by inner text, wait for the button to has content.
    ////5. Create a test where you find all Add to cart buttons, wait for all buttons to be visible.
    [TestFixture]
    [Browser(BrowserType.Firefox, Lifecycle.RestartEveryTime)]
    public class LocateAndWaitElementsVic : NUnit.WebTest
    {
        public override void TestInit() => App.Navigation.Navigate("https://demos.bellatrix.solutions/welcome/");

        [Test]
        public void SaturnVPageOpened_When_SaleButtonnClicked()
        {
            var saturnVSaleButton = App.Components.CreateByXpath<Anchor>("//h2[(contains(text(),'Saturn V'))]/following::span[1]").ToHasContent();
            var saturnVPageHeader = App.Components.CreateByXpath<Anchor>("//h1");

            saturnVSaleButton.Click();

            App.Navigation.WaitForPartialUrl("/saturn-v/");

            Assert.AreEqual("Saturn V", saturnVPageHeader.InnerText);
        }

        [Test]
        public void FindAllAddToCartButtons_When_OnWelcomePage()
        {
            var addToCartAllButtons = App.Components.CreateAllByXpath<Button>("//a[(contains(text(),'Add to cart'))]").ToList();
            for (int i = 0; i < addToCartAllButtons.Count; i++)
            {
                addToCartAllButtons[i].ToBeVisible();
            }

            Assert.AreEqual(14, addToCartAllButtons.Count);
        }
    }
}

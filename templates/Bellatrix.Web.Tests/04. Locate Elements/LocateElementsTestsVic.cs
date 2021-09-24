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
    ////3. Navigate to http://demos.bellatrix.solutions/welcome/ for each test but don't navigate in the tests body.
    ////5. Create a test where you click on the Saturn V Sale! Button via locating the element by inner text.
    ////6. Create a test where you find all Add to cart buttons
    ////7. Create a test where you locate all images inside the Best Sellers section. Use chain locators.
    [TestFixture]
    [Browser(BrowserType.Chrome, Lifecycle.RestartEveryTime)]
    public class LocateElementsTestsVic : NUnit.WebTest
    {
        public override void TestInit() => App.Navigation.Navigate("https://demos.bellatrix.solutions/welcome/");

        [Test]
        public void SaturnVPageOpened_When_SaleButtonnClicked()
        {
            var saturnVSaleButton = App.Components.CreateByXpath<Anchor>("//h2[(contains(text(),'Saturn V'))]/following::span[1]");
            var saturnVPageHeader = App.Components.CreateByXpath<Anchor>("//h1");

            saturnVSaleButton.Click();

            App.Navigation.WaitForPartialUrl("/saturn-v/");

            Assert.AreEqual("Saturn V", saturnVPageHeader.InnerText);
        }

        [Test]
        public void FindAllAddToCartButtons_When_OnWelcomePage()
        {
            var addToCartAllButtons = App.Components.CreateAllByXpath<Button>("//a[(contains(text(),'Add to cart'))]").ToList();

            Assert.AreEqual(13, addToCartAllButtons.Count);
        }

        [Test]
        public void LocateAllImages_InsideBestSellerSection_UsingXpath()
        {
            var bestSellerSectionImages = App.Components.CreateAllByXpath<Anchor>("//h2[(contains(text(),'Best Sellers'))]/following::div//img").ToList();

            Assert.AreEqual(4, bestSellerSectionImages.Count);
        }

        [Test]
        public void LocateAllImages_InsideBestSellerSection_UsingChainedLocators()
        {
            var bestSellerSection = App.Components.CreateByXpath<Option>("//h2[text()='Best Sellers']/following-sibling::div");
            var bestSellerSectionImages = bestSellerSection.CreateAllByXpath<Anchor>(".//img").ToList();

            Assert.AreEqual(4, bestSellerSectionImages.Count);
        }
    }
}

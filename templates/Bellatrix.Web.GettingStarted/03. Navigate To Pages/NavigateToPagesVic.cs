using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellatrix.Web.GettingStarted
{
    ////    . Create a new MSTest test class
    ////2. Use the BELLATRIX Browser attribute so that you execute all tests in Chrome and reuse the browser.
    ////3. Navigate to http://demos.bellatrix.solutions/welcome/ for each test but don't navigate in the tests body.
    ////5. Create a test where you open the Big Rockets page by clicking the link.
    ////6. Create a test where you open the Small Rockets page by clicking the image.
    [TestFixture]
    [Browser(BrowserType.Chrome, Lifecycle.ReuseIfStarted)]
    public class NavigateToPagesVic : NUnit.WebTest
    {
        public override void TestInit() => App.Navigation.Navigate("https://demos.bellatrix.solutions/welcome/");

        [Test]
        public void BigRocketsPageOpened_When_LinkClicked()
        {
            var bigRocketsLink = App.Components.CreateByXpath<Anchor>("//h2[(contains(text(),'Big Rockets'))]");
            var bigRocketsPageHeader = App.Components.CreateByXpath<Anchor>("//h1");

            bigRocketsLink.Click();

            App.Navigation.WaitForPartialUrl("/big-rockets/");

            Assert.AreEqual("Big Rockets", bigRocketsPageHeader.InnerText);
        }

        [Test]
        public void SmallRocketsPageOpened_When_ImageClicked()
        {
            var smallRocketsImg = App.Components.CreateByXpath<Anchor>("//img[@alt='Small Rockets']");
            var smallRocketsPageHeader = App.Components.CreateByXpath<Anchor>("//h1");

            smallRocketsImg.Click();

            App.Navigation.WaitForPartialUrl("/small-rockets/");

            Assert.AreEqual("Small Rockets", smallRocketsPageHeader.InnerText);
        }
    }
}

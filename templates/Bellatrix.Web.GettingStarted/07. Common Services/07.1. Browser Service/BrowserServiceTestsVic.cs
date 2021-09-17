using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellatrix.Web.GettingStarted
{
    ////1. Create a new MSTest test class
    ////2. Use the BELLATRIX Browser attribute so that you execute all tests in Firefox and restart the browser every time.
    ////3. Navigate to http://demos.bellatrix.solutions for each test but don't navigate in the tests body.
    ////4. Create a test where you click on Proton Rocket product. Click on customer reviews. Then go back twice and refresh the page. Assert that the title of the page is the correct one.
    [TestFixture]
    [Browser(BrowserType.Firefox, Lifecycle.RestartEveryTime)]
    public class BrowserServiceTestsVic : NUnit.WebTest
    {
        public override void TestInit() => App.Navigation.Navigate("https://demos.bellatrix.solutions");

        [Test]
        [Category(Categories.CI)]
        public void GetCorrectPageTitle_When_ClickOnProtonRocket_GoBackTwiceAndRefreshPage()
        {
            var protonRocketLink = App.Components.CreateByInnerTextContaining<Anchor>("Proton Rocket").ToBeVisible();
            var reviewsLink = App.Components.CreateByInnerTextContaining<Anchor>("Reviews").ToBeVisible();
            protonRocketLink.Click();

            App.Navigation.WaitForPartialUrl("/proton-rocket/");            
            reviewsLink.Click();

            App.Browser.Back();
            App.Browser.WaitUntilReady();
            App.Browser.Back();
            App.Browser.WaitUntilReady();
            App.Browser.Refresh();

            Assert.AreEqual("Bellatrix Demos – Bellatrix is a cross-platform, easily customizable and extendable .NET test automation framework that increases tests’ reliability.", App.Browser.Title);
        }        
    }
}

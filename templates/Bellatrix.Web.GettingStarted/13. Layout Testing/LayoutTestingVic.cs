using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bellatrix.Layout;

/// <summary>
//1.Create a new MSTest test class
//2. Use the BELLATRIX Browser attribute so that you execute all tests in Firefox and restart the browser every time.
//3. Navigate to http://demos.bellatrix.solutions/
//4. Open the browser in a mobile resolution so that the rocket links are aligned vertically.
//5. Assert all rocket boxes are aligned vertically
//6. Assert Footer menu items are aligned horizontally
//7. Assert search icon is left of the cart icon
/// </summary>
namespace Bellatrix.Web.GettingStarted
{
    [TestFixture]
    [Browser(BrowserType.Chrome, MobileWindowSize._360_640, Lifecycle.RestartEveryTime)]
    public class LayoutTestingVic : NUnit.WebTest
    {
        public override void TestInit() => App.Navigation.Navigate("https://demos.bellatrix.solutions");

        [Test]
        public void CheckPageElementsAllignments()
        {
            var searchButton = App.Components.CreateByClass<Button>("search").ToBeVisible();
            var cartButton = App.Components.CreateByClass<Button>("footer-cart-contents").ToBeVisible();
            var menuButton = App.Components.CreateByClass<Button>("menu-toggle").ToBeVisible();
            var myAccountButton = App.Components.CreateByClass<Button>("my-account").ToBeVisible();
            var bellatrixLogo = App.Components.CreateByClass<Image>("custom-logo").ToBeVisible();
            var falcon9Anchor = App.Components.CreateByClassContaining<Anchor>("product type-product post-28").ToBeVisible();
            var protonRocketAnchor = App.Components.CreateByClassContaining<Anchor>("product type-product post-12").ToBeVisible();
            var protonMAnchor = App.Components.CreateByClassContaining<Anchor>("product type-product post-14").ToBeVisible();
            var saturnVAnchor = App.Components.CreateByClassContaining<Anchor>("product type-product post-31").ToBeVisible();

            myAccountButton.Click();
            App.Browser.Back();
            cartButton.Click();
            App.Browser.Back();
            searchButton.Click();
                   

        }   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bellatrix.Web.NUnit;
using NUnit.Framework;

namespace Bellatrix.Web.Tests
{
    [TestFixture]
    [Browser(BrowserType.Chrome, Lifecycle.ReuseIfStarted)]
    public class BellatrixBrowserLifecycleTests : WebTest
    {
        [Test]
        [Browser(BrowserType.Firefox, Lifecycle.RestartEveryTime)]
        public void PromotionsPageOpened_When_PromotionsButtonClicked()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/");

            var promotionsLink = App.Components.CreateByLinkText<Anchor>("Promotions");
            var browser = new BrowserAttribute(BrowserType.Firefox, Lifecycle.RestartEveryTime);

            promotionsLink.Click();

            Assert.AreEqual(BrowserType.Firefox, browser.Browser);
        }

        [Test]
        public void BlogPageOpened_When_PromotionsButtonClicked()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/");

            var blogLink = App.Components.CreateByLinkText<Anchor>("Blog");
            var browser = new BrowserAttribute(BrowserType.Chrome, Lifecycle.ReuseIfStarted);

            blogLink.Click();

            Assert.AreEqual(BrowserType.Chrome, browser.Browser);
        }

        [Test]
        [Browser(BrowserType.Edge, Lifecycle.RestartOnFail)]
        public void BlogPageOpened_When_PromotionsButtonClicked_Edge()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/");

            var blogLink = App.Components.CreateByLinkText<Anchor>("Blog");
            var browser = new BrowserAttribute(BrowserType.Edge, Lifecycle.RestartOnFail);

            blogLink.Click();
            Assert.AreEqual(BrowserType.Edge, browser.Browser);
        }
    }
}

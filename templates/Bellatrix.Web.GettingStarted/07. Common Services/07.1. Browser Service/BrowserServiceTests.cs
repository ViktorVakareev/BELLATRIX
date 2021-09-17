﻿using System.Diagnostics;
using Bellatrix.Web.MSTest;
using NUnit.Framework;

namespace Bellatrix.Web.GettingStarted
{
    [TestFixture]
    [Browser(BrowserType.Firefox,Lifecycle.RestartEveryTime)]
    public class BrowserServiceTests : NUnit.WebTest
    {
       
        [Test]
        [Category(Categories.CI)]
        public void GetCurrentUri()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/");

            // 2. Get the current tab URL.
            Debug.WriteLine(App.Browser.Url);
        }             

        [Test]
        [Category(Categories.CI)]
        public void ControlBrowser()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/");

            // 3. Maximizes the browser.
            App.Browser.Maximize();

            // 4. Simulates clicking the browser's Back button.
            App.Browser.Back();

            // 5. Simulates clicking the browser's Forward button.
            App.Browser.Forward();

            // 6. Simulates clicking the browser's Refresh button.
            App.Browser.Refresh();
        }

        [Test]
        [Category(Categories.CI)]
        public void GetTabTitle()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/");

            // 7. Get the current tab Title.
            Assert.AreEqual("Bellatrix Demos – Bellatrix is a cross-platform, easily customizable and extendable .NET test automation framework that increases tests’ reliability.", App.Browser.Title);
        }

        [Test]
        [Category(Categories.CI)]
        public void PrintCurrentPageHtml()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/");

            // 8. Get the current page HTML.
            Debug.WriteLine(App.Browser.HtmlSource);
        }

        [Test]
        [Ignore("no need to run")]
        public void SwitchToFrame()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/");

            // 9. To work with elements inside a frame, you should switch to it first.
            var frame = App.Components.CreateById<Frame>("myFrameId");
            App.Browser.SwitchToFrame(frame);

            // Search for the button inside the frame ComponentCreateService. Of course, once you switched to frame, you can create the element through ComponentCreateService too.
            var myButton = frame.CreateById<Button>("purchaseBtnId");

            myButton.Click();

            // 10. To continue searching in the whole page, you need to switch to default again. It is the same process of how you work with WebDriver.
            App.Browser.SwitchToDefault();
        }
    }
}
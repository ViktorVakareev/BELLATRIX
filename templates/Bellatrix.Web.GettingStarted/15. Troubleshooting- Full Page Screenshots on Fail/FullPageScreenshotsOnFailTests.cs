﻿using NUnit.Framework;

namespace Bellatrix.Web.GettingStarted
{
    // If you open the testFrameworkSettings file, you find the screenshotsSettings section that controls this lifecycle.
    // "screenshotsSettings": {
    //     "isEnabled": "true",
    //     "filePath": "ApplicationData\\Troubleshooting\\Screenshots"
    // }
    //
    // You can turn off the making of screenshots for all tests and specify where the screenshots to be saved.
    // In the extensibility chapters read more about how you can create different screenshots engine or change the saving strategy.
    [TestFixture]
    public class FullPageScreenshotsOnFailTests : NUnit.WebTest
    {
        [Test]
        [Category(Categories.CI)]
        public void PromotionsPageOpened_When_PromotionsButtonClicked()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/");
            var promotionsLink = App.Components.CreateByLinkText<Anchor>("Promotions");
            promotionsLink.Click();
            App.Browser.WaitForAjax();
        }
    }
}
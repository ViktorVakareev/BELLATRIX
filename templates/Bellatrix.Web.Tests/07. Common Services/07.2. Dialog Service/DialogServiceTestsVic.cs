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
    ////4. Create a test where you click on the Promotions menu item.Click on the 'Do you want 5% off for your BD?'. Verify that the correct is displayed in the box and close the alert.

    [TestFixture]
    [Browser(BrowserType.Firefox, Lifecycle.RestartEveryTime)]
    public class DialogServiceTestsVic : NUnit.WebTest
    {
        public override void TestInit() => App.Navigation.Navigate("http://demos.bellatrix.solutions");

        [Test]
        public void CorrectMessageDisplyedInDialogBox_When_ApplyingBirthdayDiscountCoupon()
        {
            var promotionsLink = App.Components.CreateByInnerTextContaining<Anchor>("Promotions");
            var couponButton = App.Components.CreateById<Button>("couponBtn").ToBeVisible();

            promotionsLink.Click();
            couponButton.Click();

            App.Dialogs.Handle((a) => Assert.AreEqual("Try the coupon- happybirthday", a.Text));
        }

        [Test]
        [Ignore("no need to run")]
        public void DismissDialogAlert()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/welcome/");

            var couponButton = App.Components.CreateById<Button>("couponBtn");
            couponButton.Click();

            // 4. You can tell the dialog service to click a different button.
            App.Dialogs.Handle(dialogButton: DialogButton.Cancel);
            ////App.Dialogs.Handle((a) => Assert.AreEqual("Try the coupon- happybirthday", a.Text));
        }
    }
}
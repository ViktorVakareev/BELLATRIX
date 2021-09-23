
using Bellatrix.Web.GettingStarted._12._1_PageObjectsVic.CartPageVic;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
//1. Purchase random Rocket using Page Object Model 
/// </summary>
namespace Bellatrix.Web.GettingStarted
{
    [TestFixture]
    [Browser(BrowserType.Chrome, Lifecycle.RestartEveryTime)]
    public class PageObjectTestsVic : NUnit.WebTest
    {
        [Test]
        public void PurchaseRocketUsingPageObjectsModel()
        {
            var homePage = App.GoTo<HomePageVic>();

            homePage.AddProductByName("Falcon 9");            
            homePage.ClickViewCartButton();

            var cartPage = App.GoTo<CartPageVic>();

            cartPage.ApplyCoupon("happybirthday");
            cartPage.AssertCouponAddedSuccessfuly();

            cartPage.UpdateProductQuantityByName("Falcon 9", 3);            
            cartPage.AssertCartUpdated();
            cartPage.AssertCorrectTotalPrice("174.00€");
            cartPage.ProceedToCheckoutButtton.Click();

            var checkoutPage = App.GoTo<CheckoutPageVic>();

            checkoutPage.ChoosePaymentMethod("Direct bank transfer");
        }
    }
}

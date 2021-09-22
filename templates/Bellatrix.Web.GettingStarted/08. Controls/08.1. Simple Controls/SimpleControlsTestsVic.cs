using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
//1.Create a new MSTest test class
//2.Use the BELLATRIX Browser attribute so that you execute all tests in Firefox and restart the browser every time.
//3. Navigate to http://demos.bellatrix.solutions/

//4.Create a test where you search for the product Saturn V (upper right corner)
//5.Add the product to the cart and navigate to it
//6. Add one more product and verify that the prices are updated correctly
//7. Delete one of the products and verify that the prices are updated accordingly
//8. Undo the operation and verify that the prices are updated again
//9. Apply the coupon 99%
//10. Verify prices updated
/// </summary>
namespace Bellatrix.Web.GettingStarted
{
    [TestFixture]
    [Browser(BrowserType.Chrome, Lifecycle.RestartEveryTime)]
    public class SimpleControlsTestsVic : NUnit.WebTest
    {
        public override void TestInit() => App.Navigation.Navigate("https://demos.bellatrix.solutions");

        [Test]
        public void AddRocketToCart_Then_ScrollDownToFooterElementUntilItBecomesVisible()
        {
            string rocketName1 = "Saturn V";
            string rocketName2 = "Proton Rocket";
            var searchTextBox = App.Components.CreateByXpath<TextArea>("(//input[@type='search'])[1]").ToBeClickable().ToExists();            
            var searchButton = App.Components.CreateByXpath<Button>("(//button[text()='Search'])[1]");
            var addToCartButton = App.Components.CreateByInnerTextContaining<Button>("Add to cart");
            var addToCartButtonRocketScreen = App.Components.CreateByXpath<Button>("//button[text()='Add to cart']");
            var rocketAnchor1 = currentRocketAnchor(rocketName1);
            var rocketAnchor2 = currentRocketAnchor(rocketName2);
            var viewCartLink = App.Components.CreateByXpath<Button>("(//a[@class='button wc-forward'])[2]").ToBeVisible().ToExists();
            var lastAddedToCartProduct = App.Components.CreateByXpath<TextField>("(//td[@class='product-name'])[1]");
            var totalPriceField = App.Components.CreateByXpath<TextField>("//th[text()='Total']/following::bdi").ToExists().ToBeVisible();            
            var deleteFirstItemButton = App.Components.CreateByXpath<Button>("(//a[@class='remove'])[1]");
            var undoDeleteFromCartButton = App.Components.CreateByInnerTextContaining<Button>("Undo?").ToExists().ToBeClickable();
            var couponCodeTextField = App.Components.CreateByNameEndingWith<TextField>("coupon_code").ToBeVisible();
            var couponCodeApplyButton = App.Components.CreateByNameEndingWith<Button>("apply_coupon").ToBeVisible();
            var updateCart = App.Components.CreateByValueContaining<Button>("Update cart").ToBeClickable();            
                       
            searchTextBox.SetText(rocketName1 + Keys.Enter);
            addToCartButton.Click();
            App.Browser.WaitUntilReady();
            searchTextBox = App.Components.CreateByXpath<TextArea>("(//input[@type='search'])[1]").ToBeClickable().ToExists();
            searchTextBox.ToExists().WaitToBe();
            searchTextBox.SetText(rocketName2 + Keys.Enter);
            addToCartButtonRocketScreen.Click();
            viewCartLink.Click();

            var valueField1 = getPriceValue(rocketName1);
            var valueField2 = getPriceValue(rocketName2);

            Assert.AreEqual(valueField1 + valueField2, getTotalPriceValue(totalPriceField));

            deleteFirstItemButton.Click();
            App.Browser.WaitForAjax();
            totalPriceField = App.Components.CreateByXpath<TextField>("//th[text()='Total']/following::bdi").ToExists().ToBeVisible();

            Assert.AreEqual((valueField1 + valueField2) - valueField1, getTotalPriceValue(totalPriceField));
            
            undoDeleteFromCartButton.Click();           
            totalPriceField = App.Components.CreateByXpath<TextField>("//th[text()='Total']/following::bdi").ToExists().ToBeVisible();
            App.Browser.WaitForAjax();            

            Assert.AreEqual(valueField1 + valueField2, getTotalPriceValue(totalPriceField));                     

            couponCodeTextField.SetText("99%");
            couponCodeApplyButton.Click();
            var messageAlert = App.Components.CreateByClassContaining<Div>("woocommerce-message");

            messageAlert.ToHasContent().ToBeVisible().WaitToBe();
            messageAlert.ValidateInnerTextIs("Coupon code applied successfully.");
            var sumAfterCoupon = (valueField1 + valueField2) * 0.01;  // coupon = "99 %"
            
            totalPriceField = App.Components.CreateByXpath<TextField>("//th[text()='Total']/following::bdi").ToExists().ToBeVisible();
            App.Browser.WaitForAjax();

            Assert.AreEqual(sumAfterCoupon, getTotalPriceValue(totalPriceField), 1);
        }

        private double getPriceValue(string rocketName)
        {
            var priceField = App.Components.CreateByXpath<TextField>($"(//a[text()='{rocketName}']/following::td/span/bdi)[1]").ToExists().ToBeVisible();
            var priceArray = priceField.InnerText.Split(".");
            double price = Double.Parse(priceArray[0].Replace(",", string.Empty));
            return price;
        }

        private double getTotalPriceValue(TextField totalPrice)
        {
            var priceArray = totalPrice.InnerText.Split(".");
            double price = Double.Parse(priceArray[0].Replace(",", string.Empty));
            return price;
        }

        public Anchor currentRocketAnchor(string rocketName)
        {
            return App.Components.CreateByXpath<Anchor>($"//h2[text()='{rocketName}']");
        }
    }
}

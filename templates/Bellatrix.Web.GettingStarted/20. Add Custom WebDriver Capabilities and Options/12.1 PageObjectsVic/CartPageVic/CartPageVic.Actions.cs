using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellatrix.Web.GettingStarted._20._Add_Custom_WebDriver_Capabilities_and_Options
{
    public partial class CartPageVic : WebPage
    {
        public override string Url => "http://demos.bellatrix.solutions/cart/";

        public void ApplyCoupon(string couponName)
        {
            CouponField.SetText(couponName);
            ApplyCouponButtton.Click();

            MessageAlertDiv.ToBeVisible().ToHasContent().WaitToBe();
        }

        public void UpdateProductQuantityByName(string rocketName, int newQuantity)
        {
            App.Browser.WaitForAjax();
            QuantityTextBox(rocketName).SetText(newQuantity.ToString());
            UpdateCartButtton.Click();
            App.Browser.WaitForAjax();
        }
    }
}

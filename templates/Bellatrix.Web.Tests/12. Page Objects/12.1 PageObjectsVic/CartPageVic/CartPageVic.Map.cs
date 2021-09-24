using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellatrix.Web.GettingStarted._12._1_PageObjectsVic.CartPageVic
{
    public partial class CartPageVic
    {
        public TextField CouponField => App.Components.CreateByIdEndingWith<TextField>("coupon_code");

        public Button ApplyCouponButtton => App.Components.CreateByNameEndingWith<Button>("apply_coupon");

        public Div MessageAlertDiv => App.Components.CreateByClassContaining<Div>("woocommerce-notices-wrapper");

        public Button ProceedToCheckoutButtton => App.Components.CreateByClassContaining<Button>("checkout-button button alt wc-forward").ToBeVisible();

        public Span TotalPriceSpan => App.Components.CreateByXpath<Span>("//td[@data-title='Total']//span");

        public Button UpdateCartButtton => App.Components.CreateByNameEndingWith<Button>("update_cart").ToBeClickable();

        public TextField QuantityTextBox(string rocketName)
        {
        return App.Components.CreateByXpath<TextField>($"//a[text()='{rocketName}']/following::input[1]");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellatrix.Web.GettingStarted._20._Add_Custom_WebDriver_Capabilities_and_Options
{
    public partial class CheckoutPageVic
    {
        public Button PlaceOrderButton => App.Components.CreateByIdEndingWith<Button>("place_order");

        public CheckBox CreateAccountCheckBox => App.Components.CreateByIdEndingWith<CheckBox>("createaccount");

        public TextField BillingFirstName => App.Components.CreateByIdEndingWith<TextField>("billing_first_name");

        public TextField BillingLastName => App.Components.CreateByIdEndingWith<TextField>("billing_last_name");

        public TextField BillingCompany => App.Components.CreateByIdEndingWith<TextField>("billing_company");

        public Select BillingCountry => App.Components.CreateById<Select>("billing_country");

        public TextField BillingAddress1 => App.Components.CreateByIdEndingWith<TextField>("billing_address_1");

        public TextField BillingAddress2 => App.Components.CreateByIdEndingWith<TextField>("billing_address_2");

        public TextField BillingCity => App.Components.CreateByIdEndingWith<TextField>("billing_city");

        public TextField BillingState => App.Components.CreateById<TextField>("billing_state");

        public TextField BillingZip => App.Components.CreateByIdEndingWith<TextField>("billing_postcode");

        public Phone BillingPhone => App.Components.CreateByIdEndingWith<Phone>("billing_phone");

        public Email BillingEmail => App.Components.CreateByIdEndingWith<Email>("billing_email");

        public TextArea OrderComments => App.Components.CreateByIdEndingWith<TextArea>("order_comments");

        public RadioButton PaymentMethodButtonByName(string paymentMethod)
        {
            return App.Components.CreateByXpath<RadioButton>($"//label[@for='payment_method_{paymentMethod}']").ToBeVisible();
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellatrix.Web.GettingStarted
{
    public partial class CheckoutPageVic : WebPage
    {
        public override string Url => "https://demos.bellatrix.solutions/checkout/";

        public void ChoosePaymentMethod(string paymentMethod)
        {
            if (paymentMethod.Equals("Check payments"))
            {
                paymentMethod = "cheque";
            }
            else
            {
                paymentMethod = "bacs";
            }
            PaymentMethodButtonByName(paymentMethod).Click();
        }

        public void FillBillingData(BillingDataVic billingData)
        {
            OrderComments.SetText(billingData.OrderComments);
            BillingFirstName.SetText(billingData.FirstName);
            BillingLastName.SetText(billingData.LastName);
            BillingCompany.SetText(billingData.Company);
            BillingCountry.SelectByText(billingData.Country);
            BillingAddress1.SetText(billingData.Address1);
            BillingAddress2.SetText(billingData.Address2);
            BillingCity.SetText(billingData.City);
            BillingState.SetText(billingData.State);
            BillingZip.SetText(billingData.Zip);
            BillingPhone.SetPhone(billingData.Phone);
            BillingEmail.SetEmail(billingData.Email);

            if (billingData.ShouldCreateAccount)
            {
                CreateAccountCheckBox.Check();
            }
        }
    }
}

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
    }
}

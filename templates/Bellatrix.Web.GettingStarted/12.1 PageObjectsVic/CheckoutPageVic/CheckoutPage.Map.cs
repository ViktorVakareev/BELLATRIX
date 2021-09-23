using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellatrix.Web.GettingStarted
{
    public partial class CheckoutPageVic
    {
        public RadioButton PaymentMethodButtonByName(string paymentMethod)
        {            
            return App.Components.CreateByXpath<RadioButton>($"//label[@for='payment_method_{paymentMethod}']").ToBeVisible();            
        }
    }
}

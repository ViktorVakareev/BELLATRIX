using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellatrix.Web.GettingStarted._20._Add_Custom_WebDriver_Capabilities_and_Options
{
    public partial class HomePageVic
    {
        public Select SortDropDown => App.Components.CreateByClass<Select>("orderby");

        public Button AddToCartButton => App.Components.CreateByInnerTextContaining<Button>("Add to cart").ToBeClickable();

        public Button ViewCartButton => App.Components.CreateByClassContaining<Button>("button wc-forward").ToBeVisible().ToBeClickable();

        public Anchor RocketByName(string rocketName)
        {
            return App.Components.CreateByXpath<Anchor>($"//h2[text()='{rocketName}']");
        }
    }
}

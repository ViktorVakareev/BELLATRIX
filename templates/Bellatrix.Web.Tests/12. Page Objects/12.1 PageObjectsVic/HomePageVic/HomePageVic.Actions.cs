using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellatrix.Web.GettingStarted
{
    public partial class HomePageVic : WebPage
    {
        public override string Url => "http://demos.bellatrix.solutions/";

        public void FilterProducts(string filterCategory)
        {
            switch (filterCategory)
            {
                case "Popularity":
                    SortDropDown.SelectByText("Sort by popularity");
                    break;
                case "Rating":
                    SortDropDown.SelectByText("Sort by popularity");
                    break;
                case "Date":
                    SortDropDown.SelectByText("Sort by popularity");
                    break;
                case "PriceAscending":
                    SortDropDown.SelectByText("Sort by popularity");
                    break;
                case "PriceDescending":
                    SortDropDown.SelectByText("Sort by popularity");
                    break;
            }
        }

        public void AddProductByName(string rocketName)
        {
            RocketByName(rocketName).Click();
            AddToCartButton.Click();
        }

        public void ClickViewCartButton()
        {
            ViewCartButton.Focus();
            ViewCartButton.Click();
        }
    }
}

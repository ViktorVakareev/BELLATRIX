using Bellatrix.Web.NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellatrix.Web.GettingStarted
{
    [TestFixture]
    [Browser(BrowserType.Chrome, Lifecycle.RestartOnFail)]
    public class ControlBrowserExercise : WebTest
    {
        [Test]
        public void SortByPopularityChosen_When_SortByDropDownClicked()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/");

            var sortByDropdownList = App.Components.CreateByXpath<Select>("(//select[@name='orderby'])[1]");
            sortByDropdownList.SelectByText("Sort by popularity");
            var optionCurrent = sortByDropdownList.GetSelected().InnerText;

            Assert.AreEqual(optionCurrent, "Sort by popularity");  ////- How to get Select current value???
        }

        [Test]
        public void SortByPriceHighToLowChosen_When_SortByDropDownClicked()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/");

            var sortByDropdownList = App.Components.CreateByXpath<Select>("(//select[@name='orderby'])[1]");

            sortByDropdownList.SelectByText("Sort by price: high to low");
        }

        [Test]
        public void SortByPriceLowToHighChosen_When_SortByDropDownClicked()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/");

            var sortByDropdownList = App.Components.CreateByXpath<Select>("(//select[@name='orderby'])[1]");

            sortByDropdownList.SelectByText("Sort by price: low to high");
        }

        [Test]
        [Browser(BrowserType.Firefox, Lifecycle.RestartOnFail)]
        public void SortByPriceLowToHighChosen_When_SortByDropDownClicked_Firefox()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/");

            var browser = new BrowserAttribute(BrowserType.Firefox, Lifecycle.RestartEveryTime);
            var sortByDropdownList = App.Components.CreateByXpath<Select>("(//select[@name='orderby'])[1]");

            sortByDropdownList.SelectByText("Sort by price: low to high");

            Assert.AreEqual(BrowserType.Firefox, browser.Browser);  //// Assert the correct browser is used
        }
    }
}

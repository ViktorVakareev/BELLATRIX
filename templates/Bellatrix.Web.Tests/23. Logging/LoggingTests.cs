﻿using NUnit.Framework;

namespace Bellatrix.Web.GettingStarted
{
    [TestFixture]
    public class LoggingTests : NUnit.WebTest
    {
        [Test]
        [Category(Categories.CI)]
        public void AddCustomMessagesToLog()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/");

            Select sortDropDown = App.Components.CreateByNameEndingWith<Select>("orderby");
            Anchor protonMReadMoreButton = App.Components.CreateByInnerTextContaining<Anchor>("Read more");
            Anchor addToCartFalcon9 = App.Components.CreateByAttributesContaining<Anchor>("data-product_id", "28").ToBeClickable();
            Anchor viewCartButton = App.Components.CreateByClassContaining<Anchor>("added_to_cart wc-forward").ToBeClickable();

            sortDropDown.SelectByText("Sort by price: low to high");
            protonMReadMoreButton.Hover();

            // 1. Sometimes is useful to add information to the generated test log.
            // To do it you can use the BELLATRIX built-in logger through accessing it via App service.
            Logger.LogInformation("Before adding Falcon 9 rocket to cart.");

            addToCartFalcon9.Focus();
            addToCartFalcon9.Click();
            viewCartButton.Click();

            // Generated Log, as you can see the above custom message is added to the log.
            // #### Start Chrome on PORT = 53153
            // Start Test
            //     Class = LoggingTests Name = AddCustomMessagesToLog
            // Select 'Sort by price: low to high' from control (Name ending with orderby)
            // Hover control (InnerText containing Read more)
            // Before adding Falcon 9 rocket to cart.
            // Focus control (data-product_id = 28)
            // Click control (data-product_id = 28)
            // Click control (Class = added_to_cart wc-forward)
        }
    }
}
/////1. Open the tests that you made in the page objects section
//2.Add some debug logging information
//3. Customize the logs to include the current date and time
//4. Execute your tests
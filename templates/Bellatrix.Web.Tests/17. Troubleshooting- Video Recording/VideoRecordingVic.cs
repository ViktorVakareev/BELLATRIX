using Bellatrix.Web.Assertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bellatrix.Web.GettingStarted._17._Troubleshooting__Video_Recording
{
    [Browser(BrowserType.Chrome, DesktopWindowSize._1280_1024, Lifecycle.RestartEveryTime)]
    [TestFixture]
    public class VideoRecordingVic : NUnit.WebTest
    {
        [Test]
        public void TestStyles()
        {
            App.Navigation.Navigate("http://demos.bellatrix.solutions/");

            Select sortDropDown = App.Components.CreateByNameEndingWith<Select>("orderby"); 
            Anchor protonRocketAnchor = App.Components.CreateByAttributesContaining<Anchor>("href", "/proton-rocket/");
            Anchor saturnVAnchor = App.Components.CreateByAttributesContaining<Anchor>("href", "/saturn-v/");

            sortDropDown.AssertFontSize("16px"); ////14px --> fails and records screenshot
            sortDropDown.AssertFontWeight("400");
            sortDropDown.AssertFontFamily("\"Source Sans Pro\", HelveticaNeue-Light, \"Helvetica Neue Light\", \"Helvetica Neue\", Helvetica, Arial, \"Lucida Grande\", sans-serif");

            protonRocketAnchor.AssertColor("rgba(150, 88, 138, 1)");
            protonRocketAnchor.AssertBackgroundColor("rgba(0, 0, 0, 0)");
            protonRocketAnchor.AssertBorderColor("rgb(150, 88, 138)");

            protonRocketAnchor.AssertTextAlign("center");
            protonRocketAnchor.AssertVerticalAlign("baseline");
        }
    }
}

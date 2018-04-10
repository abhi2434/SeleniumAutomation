using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using Automation.AutoTests.Common;
using Automation.AutoTests.PageModels.Mobile;

namespace Automation.AutoTests.Tests.MobileTests
{
    [TestClass]
    public class IdeaCreationTest : MobileTestBase
    { 
        IdeaCreation idea = null; 
        //[TestMethod]
        public void Check_Idea_Creation_Android_Correct()
        {
            //idea = new IdeaCreation(this.Driver);
            //var data = this.Settings.Data.Split(',');

            //idea.CreateIdea(data[0], data[1], data[2], data[3], data[4]); 

        }

    }
}

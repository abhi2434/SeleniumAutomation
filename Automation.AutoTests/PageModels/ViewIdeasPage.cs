using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.AutoTests.Common;
using AventStack.ExtentReports;

namespace Automation.AutoTests.PageModels
{
    public class ViewIdeasPage : PageObjectBase
    {
        [FindsBy(How = How.Id, Using = "lblselectRole")]
        public IWebElement lblIdeasPgeHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"btnShareIdea\"]/input")]
        public IWebElement btnSubmitIdea { get; set; }

        [FindsBy(How= How.Id, Using = "lnkNotifications")]
        public IWebElement btnNotification { get; set; }

        public ViewIdeasPage(IWebDriver driver, ExtentTest test)
            :base(driver, test)
        {
            
        }

        public String GetIdeasPageHeader()
        {
            this.TestInfo("Getting ideas page header");
            this.CurrentDriver.Wait(120);
            return lblIdeasPgeHeader.Text;
        }

        public void ClickSubmitIdea()
        {
            btnSubmitIdea.Click();
        }

        public void ClickNotification()
        {
            this.btnNotification.Click();
        }

        public bool CheckforNotificationPage()
        {
            var element = this.CurrentDriver.FindElement(By.TagName("h1"), 20);
            return element.Text.Trim() == "Notifications";
        }

        public void CheckforSubmitPage()
        {
            this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_h3IdeaHeader"), 20);
        }
    }
}

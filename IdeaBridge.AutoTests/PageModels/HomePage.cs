using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using Automation.AutoTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Automation.AutoTests.PageModels
{
    public class HomePage : PageObjectBase
    {
        [FindsBy(How = How.Id, Using = "lblUserName")]
        public IWebElement lblHomePageUserId { get; set; }
        [FindsBy(How = How.Id, Using = "ImageProfile")]
        public IWebElement imgProfile { get; set; }
        [FindsBy(How = How.Id, Using = "lnkbtnLogout")]
        public IWebElement logOutMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"banner_right_column\"]/li[2]/a")]
        public IWebElement ideasMenu { get; set; }

        [FindsBy(How= How.Id, Using = "ddlRoles")]
        public IWebElement RoleDropdown { get; set; }
        public HomePage(IWebDriver driver, ExtentTest test)
            : base(driver, test)
        {
        }

        public string GetHomePageDashboardUserName()
        {
            this.TestInfo("Checking UserName of home page");
            //this.CurrentDriver.FindElement(By.Id("btnShareIdea"), 50);
            var script = "return document.getElementById('lblUserName').innerText;";
            var value = ((IJavaScriptExecutor)this.CurrentDriver).ExecuteScript(script).ToString();
            return value;
        }

        public void GetUserLoggedOut()
        {
            this.TestInfo("Logging out");
            Actions action = new Actions(this.CurrentDriver);
            action.MoveToElement(imgProfile).Build().Perform();
            action.MoveToElement(logOutMenu).Click().Build().Perform();
        }
        public void CheckForLoginPage()
        {
            this.CurrentDriver.FindElement(By.Id("btnLogin"), 50);
        }
        public void ClickIdeasMenu()
        {
            this.TestInfo("Clicking on Ideas menu");
            Thread.Sleep(1000);
            this.CurrentDriver.FindElement(By.Id("menuButton"), 50).Click();
            var ideasMenu = this.CurrentDriver.FindElement(By.Id("lnkbtnIdeas"), 50);
            Actions action = new Actions(this.CurrentDriver);
            action.MoveToElement(ideasMenu).Click().Build().Perform();
        }

        public void CheckforViewPage()
        {
            this.CurrentDriver.FindElement(By.Id("lblselectRole"), 50);
        }

        public void ChangeToCategory(string category)
        {
            SelectElement select = new SelectElement(this.RoleDropdown);
            select.SelectByText(category);
        }

        public string ChangeToAdmin(string category)
        {
            this.ChangeToCategory(category);
            this.WaitForReady();
            var element = this.CurrentDriver.FindElement(By.Id("AdminAct"), 50);
            Actions action = new Actions(this.CurrentDriver);
            action.MoveToElement(element).MoveToElement(this.CurrentDriver.FindElement(By.Id("LinkButton3"))).Click().Build().Perform();
            return this.CurrentDriver.FindElement(By.Id("UserManagementID"), 50).GetAttribute("class");
        }
    }
}

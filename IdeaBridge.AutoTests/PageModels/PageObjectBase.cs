using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.AutoTests.PageModels
{
    public class PageObjectBase
    {
        public readonly IWebDriver CurrentDriver;
        public readonly ExtentTest CurrentTest;
        public PageObjectBase(IWebDriver driver, ExtentTest currentTest)
        {
            this.CurrentDriver = driver;
            this.CurrentTest = currentTest;
            PageFactory.InitElements(driver, this);
        }

        protected void TestFail(Exception ex)
        {
            var markup = MarkupHelper.CreateLabel(ex.Message, ExtentColor.Red);
            if (this.CurrentTest != null)
                this.CurrentTest.Fail(markup);
        }
        protected void TestPassed(string msg)
        {
            var markup = MarkupHelper.CreateLabel(msg, ExtentColor.Green);
            if (this.CurrentTest != null)
                this.CurrentTest.Pass(markup);
        }

        protected void TestInfo(string msg)
        {
            var markup = MarkupHelper.CreateLabel(msg, ExtentColor.Blue);
            if (this.CurrentTest != null)
                this.CurrentTest.Info(markup);
        }

        private string baseUrl;

        public string BaseUrl
        {
            get
            {
                if(string.IsNullOrEmpty(baseUrl))
                {
                    string url = this.CurrentDriver.Url;
                    var currentUri = new Uri(url);
                    baseUrl = currentUri.Authority;
                }
                return baseUrl;
            }
        }

        public void WaitForReady()
        {
            new WebDriverWait(this.CurrentDriver, TimeSpan.FromSeconds(15)).Until(
                   d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}

using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Automation.Mobile.PageModels
{
    public class PageObjectBase
    {
        public readonly AppiumDriver<IWebElement> CurrentDriver;
        public readonly ExtentTest CurrentTest;
        public PageObjectBase(AppiumDriver<IWebElement> driver, ExtentTest currentTest)
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
                if (string.IsNullOrEmpty(baseUrl))
                {
                    string url = this.CurrentDriver.Url;
                    var currentUri = new Uri(url);
                    baseUrl = currentUri.Authority;
                }
                return baseUrl;
            }
        }

        public IWebElement WaitForReady(string resourceId)
        {
            WebDriverWait wait = new WebDriverWait(this.CurrentDriver, TimeSpan.FromSeconds(180));
            var result = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id(resourceId)));

            if(result.Count > 0)
            {
                return this.CurrentDriver.FindElement(By.Id(resourceId));
            }
            return null;
        }
        public IWebElement WaitForClick(string resourceId)
        {
            WebDriverWait wait = new WebDriverWait(this.CurrentDriver, TimeSpan.FromSeconds(60));
            return wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(resourceId)));

            
        }
        public IWebElement WaitForClick(By by)
        {
            WebDriverWait wait = new WebDriverWait(this.CurrentDriver, TimeSpan.FromSeconds(60));
            return wait.Until(ExpectedConditions.ElementToBeClickable(by));


        }
        public IWebElement WaitForReady(By by)
        {
            WebDriverWait wait = new WebDriverWait(this.CurrentDriver, TimeSpan.FromSeconds(60));
            var result = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));

            if (result.Count > 0)
            {
                return this.CurrentDriver.FindElement(by);
            }
            return null;
        }
        public bool WaitForInvisibility(By by)
        {
            WebDriverWait wait = new WebDriverWait(this.CurrentDriver, TimeSpan.FromSeconds(60));
            var result = wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));

            
            return result;
        }
    }
}

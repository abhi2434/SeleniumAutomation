using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.AutoTests.Common
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                var expectation = ExpectedConditions.ElementIsVisible(by);
                wait.Until(expectation);
                return driver.FindElement(by);
            }
            return driver.FindElement(by);
        }
        public static SelectElement FindSelectElementWhenPopulated(this IWebDriver driver, By by, int delayInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(delayInSeconds));
            return wait.Until<SelectElement>(drv =>
            {
                SelectElement element = new SelectElement(drv.FindElement(by));
                if (element.Options.Count > 1)
                {
                    return element;
                }

                return null;
            }
            );
        }
        public static IWebElement FindElementEnabled(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                var expectation = ExpectedConditions.ElementToBeClickable(by);
                wait.Until(expectation);
                return driver.FindElement(by);
            }
            return driver.FindElement(by);
        }
        
        public static IWebElement LoseElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                var expectation = ExpectedConditions.InvisibilityOfElementLocated(by);
                wait.Until(expectation);
                return driver.FindElement(by);
            }
            return driver.FindElement(by);
        }
        public static void Click(this IWebElement element, int timeoutinseconds)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutinseconds);
            element.Click();
        }
        public static void Click(this IWebElement element, IWebDriver driver, int timeoutinseconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutinseconds);
            element.Click();
        }
        public static IWebElement Click(this IWebElement element, int timeoutinseconds, By filter)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutinseconds));
            element.Click();
            return wait.Until(e => e.FindElement(filter));

        }

        public static void Wait(this IWebDriver driver, double time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(time);
        }

        public static void WaitForAjax(this IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(150));
            wait.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0"));
        }
    }
}

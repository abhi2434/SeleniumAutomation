using Automation.AutoTests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.AutoTests.Tests.MobileTests
{
    public class MobileTestBase
    {
        public IWebDriver Driver { get; set; } = null;

        protected MobileSettings Settings { get; set; }
        [TestInitialize]
        public void SetupTest()
        {

            Settings = new MobileSettings();
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("app", Settings.App);
            capabilities.SetCapability("deviceName", Settings.DeviceName);
            capabilities.SetCapability("platformName", Settings.PlatformName);
            capabilities.SetCapability("platformVersion", Settings.PlatformVersion);

            this.Driver = new RemoteWebDriver(new Uri(Settings.Url), capabilities, TimeSpan.FromSeconds(180));
            this.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            

        }


        [TestCleanup]
        public void CleanUpTest()
        {
            this.Driver.Dispose();
        }
    }
}

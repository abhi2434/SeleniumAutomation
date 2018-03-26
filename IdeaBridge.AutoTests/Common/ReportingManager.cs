using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Automation.Common;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Automation.AutoTests.Common
{

    public class WebReportingManager: IReportingManager
    {
        public WebReportingManager(string fileName)
        {
            this.Settings = AppSettings.Default;
            this.Report = new ExtentReports();
            this.CreateReport(fileName);
            
        }
        internal AppSettings Settings { get; set; }

        internal ExtentReports Report { get; set; }

        private void CreateReport(string fileName)
        {
            var htmlReporter = new ExtentHtmlReporter(Path.Combine(this.Settings.DirectoryPath, "Report", fileName + ".html"));
            this.AddSystemInformation(this.Report);
            this.Report.AttachReporter(htmlReporter);
        }

        private void AddSystemInformation(ExtentReports report)
        {
            try
            {
                report.AddSystemInfo("Base Url", this.Settings.BaseUrl);
                report.AddSystemInfo("Browser", this.Settings.Browser);
                report.AddSystemInfo("BrowserVersion", this.GetBrowserVersion(this.Settings.Browser));
                report.AddSystemInfo("Operation System", Environment.OSVersion.ToString());

                var bit = "32 Bit (x86) Operating System";
                report.AddSystemInfo("Operation System", Environment.OSVersion.ToString());
                if (Environment.Is64BitOperatingSystem)
                    bit = "64 Bit Operating System";
                report.AddSystemInfo("Type", bit);
                report.AddSystemInfo("SystemDirectory", Environment.SystemDirectory);
                report.AddSystemInfo("ProcessorCount", Environment.ProcessorCount.ToString());
                report.AddSystemInfo("UserDomainName", Environment.UserDomainName);
                report.AddSystemInfo("UserName", Environment.UserName);


                foreach (DriveInfo DriveInfo1 in DriveInfo.GetDrives())
                {


                    try
                    {
                        report.AddSystemInfo("Logical Drives", string.Format("Drive: {0}, VolumeLabel: {1}, DriveType: {2}, DriveFormat: {3}, Total Size: {4}, Available Size: {5}", DriveInfo1.Name, DriveInfo1.VolumeLabel, DriveInfo1.DriveType,
                          DriveInfo1.DriveFormat, DriveInfo1.TotalSize, DriveInfo1.AvailableFreeSpace));
                    }
                    catch
                    {
                    }
                }
                report.AddSystemInfo("SystemPageSize", Environment.SystemPageSize.ToString());
                report.AddSystemInfo("Version", Environment.Version.ToString());

            }
            catch
            {
            }
        }

        private string GetBrowserVersion(string browser)
        {
            var directoryPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Drivers");
            RemoteWebDriver driver;
            switch (browser)
            {
                case "chrome":
                    driver = new ChromeDriver(directoryPath);
                    break;
                case "firefox":
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(directoryPath, "geckodriver.exe");
                    service.Port = 64444;

                    var options = new FirefoxOptions();
                    options.SetPreference("browser.private.browsing.autostart", true);
                    driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(30));
                    break;
                case "ie":
                    driver = new InternetExplorerDriver(directoryPath);
                    break;
                case "edge":
                    driver = new EdgeDriver(directoryPath);
                    break;
                case "opera":
                    driver = new OperaDriver(directoryPath);
                    break;
                case "safari":
                    driver = new SafariDriver(directoryPath);
                    break;
                case "phantomjs":
                    driver = new PhantomJSDriver(directoryPath);
                    break;
                default:
                    driver = new ChromeDriver(directoryPath);
                    break;
            }

            var capability = driver.Capabilities;
            driver.Quit();
            return capability.Version;
        }

        public ExtentTest CreateTest(string testName, List<string> categories)
        {
            var test = this.Report.CreateTest(testName);
            test.AssignAuthor(Environment.UserName);

            test.AssignCategory(categories.ToArray());

            return test;
        }

        public void FlushTest()
        {
            this.Report.Flush();
        }
    }
}

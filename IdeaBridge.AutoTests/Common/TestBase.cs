using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
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
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using Automation.Common;

namespace Automation.AutoTests.Common
{
    public abstract class TestBase : ISupportReporting
    {
        public IWebDriver Driver { get; set; } = null;
        internal AppSettings Settings { get; set; }
      
        internal ExtentTest CurrentTest { get; set; }

        protected DataTable CurrentData { get; set; }

        public WebReportingManager Report { get; set; }

        public void Initialize()
        {
            this.Settings = AppSettings.Default;
            
            this.Driver = this.GetDriver(); 
        } 

        [TestInitialize]
        public void SetupTest()
        {
            this.Initialize();
            this.Driver.Navigate().GoToUrl(this.Settings.BaseUrl);
            var driverSettings = this.GetDriverManager();
            driverSettings.Window.Maximize(); 
        }

        protected List<DataModel> GetCurrentData([CallerMemberName]string currentFunction = "")
        {
           
            if (this.Report != null)
            {
                var category = this.GetType().GetMethod(currentFunction).GetCustomAttribute<TestCategoryAttribute>();
                List<string> categorylst = new List<string>(new[] { "General" });
                if (category != null)
                {
                    categorylst.Clear();
                    categorylst.AddRange(category.TestCategories);
                }
                this.CurrentTest = this.Report.CreateTest(currentFunction, categorylst);
            }
            var dataTable = this.ReadCurrentDataTable(currentFunction);
            if (dataTable == null)
            {
                Assert.Fail("Cannot find data file.");
                return null;
            }
            else
            {
                var lstModels = new List<DataModel>();
                foreach (DataRow row in dataTable.Rows)
                {
                    lstModels.Add(new DataModel(row));
                }
                return lstModels;
            }
            
        }

        private string ExcelConnection(string fileName)
        {
            return @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                   @"Data Source=" + fileName + ";" +
                   @"Extended Properties=" + Convert.ToChar(34).ToString() +
                   @"Excel 8.0" + Convert.ToChar(34).ToString() + ";";
        }

        private DataTable ReadCurrentDataTable(string functionName)
        {
            try
            {
                var className = this.GetType().Name;
                //if (this.CurrentData != null && this.CurrentData.TableName.Equals(className))
                //    return;

                string cmdText = $"SELECT * FROM [{className}$] where casename='{functionName}'";
                var connectionString = this.ExcelConnection(this.Settings.DataFile);
                using (var conObj = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand cmd = new OleDbCommand(cmdText, conObj))
                    {
                        OleDbDataAdapter adpt = new OleDbDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adpt.Fill(ds, className);

                        this.TestPassed("Data loaded correctly");
                        return ds.Tables[0]; 
                    }
                }
            }
            catch(Exception ex)
            {
                this.TestError(ex);
                return null;
            }
        }
        protected void TestFail(Exception ex)
        {
            if (this.CurrentTest != null)
                this.CurrentTest.Fail(ex);
        }

        protected void TestError(Exception ex)
        {
           
            if (this.CurrentTest != null)
            {
                var markup = MarkupHelper.CreateLabel(ex.Message, ExtentColor.Red);
                var stack = MarkupHelper.CreateCodeBlock(ex.StackTrace);
                this.CurrentTest.Error(markup);
                this.CurrentTest.Fatal(stack);
            }
        }

        protected void TestPassed(string msg)
        {
            var markup = MarkupHelper.CreateLabel(msg, ExtentColor.Green);
            if(this.CurrentTest != null)
                this.CurrentTest.Pass(markup);
        }

        protected IWebDriver GetDriver()
        {
            var directoryPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Drivers");
            switch (this.Settings.Browser)
            {
                case "chrome":
                    return new ChromeDriver(directoryPath);
                case "firefox":
                    FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(directoryPath, "geckodriver.exe");
                    service.Port = 64444;
                    
                    var options = new FirefoxOptions();
                    options.SetPreference("browser.private.browsing.autostart", true);
                    return new FirefoxDriver(service, options, TimeSpan.FromSeconds(30));
                case "ie": 
                    return new InternetExplorerDriver(directoryPath);
                case "edge":
                    return new EdgeDriver(directoryPath);
                case "opera":
                    return new OperaDriver(directoryPath);
                case "safari":
                    return new SafariDriver(directoryPath);
                case "phantomjs":
                    return new PhantomJSDriver(directoryPath);
                default:
                    return new ChromeDriver(directoryPath);
            }
        }

        public IOptions GetDriverManager()
        {
            return this.Driver.Manage();
        }
        public void LogException(Exception ex, [CallerMemberName]string memberName = "")
        {
            if (this.CurrentTest != null)
            {
                var errorMessage = MarkupHelper.CreateLabel($"Test case for {memberName} is failed. Actual Error : {ex.Message}", ExtentColor.Red);
                var errorStack = MarkupHelper.CreateCodeBlock(ex.StackTrace);

                if (ex is AssertFailedException)
                {
                    this.CurrentTest.Fail(errorMessage);
                    this.CurrentTest.Fatal(errorStack);
                }
                else
                {
                    this.CurrentTest.Error(errorMessage);
                    this.CurrentTest.Fatal(errorStack);
                }
            }
            this.GetScreenshot(memberName);
        }
        public void GetScreenshot(string memberName)
        {
            try
            {
                var path = this.Settings.DirectoryPath;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);

                }

                string filePath = Path.Combine(path, "Screenshots", string.Format("{0}-{1}.jpg", memberName, DateTime.Now.ToFileTime()));
                Screenshot screenShot = ((ITakesScreenshot)this.Driver).GetScreenshot();
                screenShot.SaveAsFile(filePath, ScreenshotImageFormat.Jpeg);

                this.CurrentTest.AddScreenCaptureFromPath(filePath.Replace(this.Settings.DirectoryPath, "../"));
            }
            catch(Exception ex)
            {
                this.TestError(ex);
            }
        }

        #region ElementSelection

        public IWebElement Find(string id)
        {
            return this.Find(By.Id(id));
        }
        public IWebElement FindByAttribute(string tagname, string attributename, string attributevalue)
        {
            return this.Find(By.XPath($"//{tagname}[@{attributename}='{attributevalue}']"));
        }
        public IWebElement Find(By filter)
        {
            return this.Driver.FindElement(filter);
        }

        public IWebElement Find(By filter, int timeoutinseconds)
        {
            return this.Driver.FindElement(filter, timeoutinseconds);
        }
        public void Assign(string id, string value)
        {
            this.Assign(By.Id(id), value);
        }
        public void Assign(By filter, string value)
        {
            this.Find(filter).SendKeys(value);
        }

        #endregion

        public object ExecuteScript(string functionName)
        {
            return ((IJavaScriptExecutor)this.Driver).ExecuteScript(functionName);
        }

        public void Destroy()
        {
            if (this.Driver != null)
            {
                this.Driver.Quit();
                this.Driver.Dispose();
            }
        }

        [TestCleanup]
        public void CleanUpTest()
        {
            this.Destroy();
        }

        public void SetReport(IReportingManager manager)
        {
            this.Report = manager as WebReportingManager;
        }
        public void WaitForReady()
        {
            new WebDriverWait(this.Driver, TimeSpan.FromSeconds(15)).Until(
                   d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
       
    }
}

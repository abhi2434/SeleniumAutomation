using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Mobile.Common
{
    public class MobileBase
    {
        internal ExtentTest CurrentTest { get; set; }
        protected DataTable CurrentData { get; set; }
        internal MobileSettings Settings { get; set; }
        public ReportingManager Report { get; set; }
        public AppiumDriver<IWebElement> CurrentDriver { get; set; }
        [TestInitialize]
        public void SetupTest()
        {
            DesiredCapabilities cap = new DesiredCapabilities();

            cap.SetCapability(MobileCapabilityType.PlatformVersion, "4.4.2");
            cap.SetCapability(AndroidMobileCapabilityType.AppPackage, "Automation.www");
            cap.SetCapability(AndroidMobileCapabilityType.AppActivity, "Automation.www.MainActivity");
            cap.SetCapability(MobileCapabilityType.DeviceName, "emulator-5554");
            CurrentDriver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap, TimeSpan.FromMinutes(5));
            this.Settings = MobileSettings.Default;
            
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
            catch (Exception ex)
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
            if (this.CurrentTest != null)
                this.CurrentTest.Pass(markup);
        }

    }

}

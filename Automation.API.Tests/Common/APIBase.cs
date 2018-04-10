using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using Automation.Common;
using Automation.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Automation.API.Tests.Common
{
    public class APIBase :ISupportReporting
    {

        internal APISettings Settings
        {
            get
            {
                return APISettings.Default;
            }
        }

        DatabaseManager _dbBridge;
        public DatabaseManager DbBridge
        {
            get
            {
                this._dbBridge = this._dbBridge ?? new DatabaseManager(this.Settings.DbConnectionString);
                return this._dbBridge;
            }
        }
        internal ExtentTest CurrentTest { get; set; }

        private APIReportingManager _report;
        internal APIReportingManager Report { get
            {
                this._report = this._report ?? new APIReportingManager($"{Guid.NewGuid()}");
                return this._report;
            }
            set
            {
                this._report = value;
            }
        }

        public APIBase()
        {
            
        }
        protected List<DataModel> GetCurrentData(string currentFunction)
        {
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

                string cmdText = $"SELECT * FROM [{className}$] where CaseName='{functionName}'";
                var connectionString = this.ExcelConnection(this.Settings.DataFile);
                using (var conObj = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand cmd = new OleDbCommand(cmdText, conObj))
                    {
                        OleDbDataAdapter adpt = new OleDbDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        adpt.Fill(ds, className);

                        return ds.Tables[0];
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        [TestInitialize]
        public void Initialize()
        {
            //this.Report = new APIReportingManager($"{Guid.NewGuid()}");
        }
        public async Task<Dictionary<string, string>> ProcessRequest([CallerMemberName]string currentFunction = "")
        {
            var currentData = this.GetCurrentData(currentFunction);
            var utility = new HttpUtility(this.Settings.UserId,
                            this.Settings.Password,
                            this.Settings.BaseURL);
            this.CurrentTest = this.Report.CreateTest(currentFunction);
            var dict = new Dictionary<string, string>();
            foreach (var item in currentData)
            {
                this.CurrentTest.Info($"Starting executing: {item.CaseName}, Method : {item.Method}.");
                ReturnMessage<string> result = new ReturnMessage<string>();
                switch (item.Method)
                {
                    case "GET":
                        result = await utility.GetRequest(item.CaseName, item.QueryString);
                        break;
                    case "POST":
                        result = await utility.PostRequest(item.CaseName, item.Method, item.Body, item.QueryString);
                        break;
                    case "PUT":
                    case "DELETE":
                        result = await utility.PostRequest(item.CaseName, item.Method, item.Body, string.Empty);
                        break;
                    default:
                        result = await utility.GetRequest(item.CaseName);
                        break;
                }
                this.CurrentTest.Info($"Finished executing request for: {item.CaseName}, Method : {item.Method}.");
                if (result.Status)
                {
                    if (((int)result.HttpStatusCode) == Convert.ToInt32(item.ExpectedResult.Trim()))
                    {
                        this.CurrentTest.Pass($"API is executed : {result.Message}, HttpStatus : {Enum.GetName(typeof(HttpStatusCode), result.HttpStatusCode)}");
                        this.CurrentTest.Debug(result.Value);
                    }
                    else
                    {
                        this.CurrentTest.Fail($"API is executed : {result.Message}, HttpStatus : {Enum.GetName(typeof(HttpStatusCode), result.HttpStatusCode)}");
                    }
                }
                else
                {
                    if (((int)result.HttpStatusCode) == Convert.ToInt32(item.ExpectedResult.Trim()))
                    {
                        this.CurrentTest.Pass($"API is executed : {result.Message}, HttpStatus : {Enum.GetName(typeof(HttpStatusCode), result.HttpStatusCode)}");
                        this.CurrentTest.Debug(result.Value);
                    }
                    else
                    {
                        this.CurrentTest.Fail($"API is executed : {result.Message}, HttpStatus : {Enum.GetName(typeof(HttpStatusCode), result.HttpStatusCode)}");
                    }
                }

                if (!string.IsNullOrEmpty(result.Value))
                    dict.Add(item.CaseName, result.Value);
            }
            return dict;
        }
        private void GenerateReport(DataModel item, ReturnMessage<string> result)
        {
            if (result.Status)
            {
                if (((int)result.HttpStatusCode) == Convert.ToInt32(item.ExpectedResult.Trim()))
                {
                    if (!string.IsNullOrWhiteSpace(item.ExpectedResult2))
                    {
                        var command = this.DbBridge.DbBridge.GetCommand(item.ExpectedResult2, true);
                        var reader = command.ExecuteScalar();
                        var dataCount = reader.ToString();

                        //result.Value;
                        this.CurrentTest.Pass($"API is executed : {result.Message}, HttpStatus : {Enum.GetName(typeof(HttpStatusCode), result.HttpStatusCode)}");
                        this.CurrentTest.Debug(result.Value);
                    }
                }
                else
                {
                    this.CurrentTest.Fail($"API is executed : {result.Message}, HttpStatus : {Enum.GetName(typeof(HttpStatusCode), result.HttpStatusCode)}");
                }
            }
            else
            {
                if (((int)result.HttpStatusCode) == Convert.ToInt32(item.ExpectedResult.Trim()))
                {
                    this.CurrentTest.Pass($"API is executed : {result.Message}, HttpStatus : {Enum.GetName(typeof(HttpStatusCode), result.HttpStatusCode)}");
                    this.CurrentTest.Debug(result.Value);
                }
                else
                {
                    this.CurrentTest.Fail($"API is executed : {result.Message}, HttpStatus : {Enum.GetName(typeof(HttpStatusCode), result.HttpStatusCode)}");
                }
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

        }
        public void SetReport(IReportingManager manager)
        {
            this.Report = manager as APIReportingManager;
        }
        public void Destroy()
        {
            this.Report.FlushTest();
        }
        [TestCleanup]
        public void CleanUpTest()
        {
            this.Destroy();
        }
    }
}

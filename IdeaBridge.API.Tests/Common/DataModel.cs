using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.API.Tests.Common
{
    public class DataModel
    {
        public DataModel(DataRow row)
        {
            if (row != null)
            {
                this.CaseName = this.GetData(row, "TestName");
                this.Method = this.GetData(row, "HttpMethod");
                this.Body = this.GetData(row, "RequestBody");
                this.QueryString = this.GetData(row, "QueryString");
                this.ExpectedResult = this.GetData(row, "ExpectedResult");
                this.ExpectedResult2 = this.GetData(row, "ExpectedResult2");
                this.Dependency = this.GetData(row, "Dependency");

            }
        }
        public string CaseName { get; set; }

        public string Body { get; set; }

        public string QueryString { get; set; }

        public string ExpectedResult { get; set; }

        public string ExpectedResult2 { get; set; }

        public string Dependency { get; set; }


        public string Method { get; private set; }

        private string GetData(DataRow row, string columnName)
        {
            try
            {
                return row[columnName].ToString();
            }
            catch
            {
                return string.Empty;
            }
        }

    }
}
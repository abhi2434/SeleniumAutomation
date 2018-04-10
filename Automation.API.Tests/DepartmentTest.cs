using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automation.API.Tests.Common;

namespace Automation.API.Tests
{
    [TestClass]
    public class DepartmentTest: APIBase
    {
        [TestMethod]
        public void GetAllDepartments()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
    }
}

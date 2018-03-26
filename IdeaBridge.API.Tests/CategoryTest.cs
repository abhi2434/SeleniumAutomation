using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automation.API.Tests.Common;

namespace Automation.API.Tests
{
    [TestClass]
    public class CategoryTest : APIBase
    {
        [TestMethod]
        public void GetAllCategories()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetAllSubCategories()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
    }
}

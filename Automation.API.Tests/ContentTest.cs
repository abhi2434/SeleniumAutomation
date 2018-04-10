using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automation.API.Tests.Common;

namespace Automation.API.Tests
{
    [TestClass]
    public class ContentTest: APIBase
    {
        [TestMethod]
        public void CreateContent()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetContentStartForm()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetContentForm()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetPendingTasks()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }

        //Created by saurav
        [TestMethod]
        public void GetContentDetails()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetContentDetails_InvalidNumber()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetContentDetails_IdMissing()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
    }
}

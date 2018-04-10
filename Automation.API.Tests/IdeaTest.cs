using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automation.API.Tests.Common;

namespace Automation.API.Tests
{
    [TestClass]
    public class IdeaTest : APIBase
    {
        [TestMethod]
        public void GetAllIdeaTags()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetIdeaTagDetailsByTagName()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }

        //Created by saurav
        [TestMethod]
        public void TestGetMyIdeas()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestGetMyIdeas_InvalidNumber()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestGetMyIdeas_IdMissing()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestGetAllIdeas()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestPostCommentDetailId_Number()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestPostCommentDetailId_AlphanumericCharacter()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestPostCommentDetailId_Number_WithRequestBody()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestPostCommentDetailId_AlphanumericCharacter_WithRequestBody()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestGetLikeIdea_WithValidIdeaId()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestGetIdeaGetContentDetails_WithValidIdeaId()
        {
            var tResult = this.ProcessRequest();
            var result = tResult.Result;

            Assert.IsNotNull(result);
        }
    }
}

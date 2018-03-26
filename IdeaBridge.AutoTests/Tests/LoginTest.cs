using Automation.AutoTests.Common;
using Automation.AutoTests.PageModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.AutoTests.Tests
{
    [TestClass]
    public class LoginTest : TestBase
    {
        
        LoginPage Login { get; set; } 
        HomePage Home { get; set; }

        [TestCategory("Success")] 
        [TestMethod]
        public void Check_HomePage_Appears_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    this.Login = new LoginPage(this.Driver, this.CurrentTest);

                    //Verify login page title
                    string loginPageTitle = this.Login.GetLoginTitle();
                    var p1 = firstRow.P1;
                    var p2 = firstRow.P2;
                    
                    var p3 = firstRow.P3;
                    Assert.AreEqual(p3, loginPageTitle.ToLower());

                    //login to application
                    this.Login.LoginToHome(p1, p2);

                    this.Login.CheckForHome();

                    // go the next page
                    Home = new HomePage(this.Driver, this.CurrentTest); 

                    var p4 = firstRow.P4;
                    //var actual = this.Home.GetHomePageDashboardUserName();
                    ////Verify home page
                    //Assert.AreEqual(p4, actual);
                    this.TestPassed("Test passed");
                }
            }
            catch(Exception ex)
            {
                this.LogException(ex); 
                throw;
            }
        }

        [TestCategory("Failure")] 
        [TestMethod]
        public void Check_HomePage_Appears_InCorrect()
        {
            var models = this.GetCurrentData();
            if (models.Count > 0)
            {
                var firstRow = models[0];
                this.Login = new LoginPage(this.Driver, this.CurrentTest);

                //Verify login page title
                string loginPageTitle = this.Login.GetLoginTitle();

                var p3 = firstRow.P3;
                
                Assert.AreEqual(p3, loginPageTitle.ToLower());

                var p1 = firstRow.P1;
                var p2 = firstRow.P2;

                //login to application
                this.Login.LoginToHome(p1, p2);

                this.Login.CheckForError();
                var p4 = firstRow.P4;
                // verify invalid login error		
                Assert.AreEqual(p4, this.Login.GetInvalidLoginTitle().ToLower());

                this.TestPassed("Test passed");
            }

        }
    }
}

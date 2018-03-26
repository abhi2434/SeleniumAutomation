using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automation.AutoTests.Common;
using Automation.AutoTests.PageModels;

namespace Automation.AutoTests.Tests
{
    [TestClass]
    public class HomeTest : TestBase
    {
        LoginPage loginPage;
        HomePage homePage;
        ViewIdeasPage ideasPage;

        [TestCategory("Success")]
        [TestMethod]
        public void Check_HomePage_Logout_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    //Create Login Page object
                    loginPage = new LoginPage(this.Driver, this.CurrentTest);
                    string loginPageTitle = loginPage.GetLoginTitle();
                    //Verify login page title
                    Assert.AreEqual(loginPageTitle.ToLower(), firstRow.P3);

                    //login to application
                    loginPage.LoginToHome(firstRow.P1, firstRow.P2);

                    loginPage.CheckForHome();

                    // go the next page
                    homePage = new HomePage(this.Driver, this.CurrentTest);

                    //Verify home page
                    //Assert.AreEqual(homePage.GetHomePageDashboardUserName(), firstRow.P4);

                    homePage.GetUserLoggedOut();
                    Assert.AreEqual(loginPageTitle.ToLower(), firstRow.P5);
                    this.TestPassed("Test passed");
                }
            }
            catch(Exception ex)
            {
                this.LogException(ex);
                throw;
            }

        }
        [TestCategory("Success")]
        [TestMethod]
        public void Check_HomePage_IdeasMenuClick_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    //Create Login Page object
                    loginPage = new LoginPage(this.Driver, this.CurrentTest);

                    //Verify login page title
                    string loginPageTitle = loginPage.GetLoginTitle();

                    Assert.AreEqual(firstRow.P3, loginPageTitle.ToLower());

                    //login to application
                    loginPage.LoginToHome(firstRow.P1, firstRow.P2);

                    loginPage.CheckForHome();

                    // go the next page
                    homePage = new HomePage(this.Driver, this.CurrentTest);

                    //Verify home page
                    //Assert.AreEqual(firstRow.P4, homePage.GetHomePageDashboardUserName());

                    homePage.ClickIdeasMenu();
                    homePage.CheckforViewPage();

                    ideasPage = new ViewIdeasPage(this.Driver, this.CurrentTest);
                    Assert.AreEqual(firstRow.P5, ideasPage.GetIdeasPageHeader());
                    this.TestPassed("Test passed");
                }
            }
            catch(Exception ex)
            {
                this.LogException(ex);
                throw;
            }
        }

    }
}

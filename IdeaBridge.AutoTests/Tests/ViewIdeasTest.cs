using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automation.AutoTests.PageModels;
using Automation.AutoTests.Common;

namespace Automation.AutoTests.Tests
{
    [TestClass]
    public class ViewIdeasTest : TestBase
    {
        LoginPage loginPage;
        HomePage homePage;
        ViewIdeasPage ideasPage;
        SubmitIdeaPage submitIdeaPage;

        [TestCategory("Success")]
        [TestMethod]
        public void Check_HomePage_ViewIdeasClick_Correct()
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
                    Assert.AreEqual(firstRow.P4, homePage.GetHomePageDashboardUserName());

                    homePage.ClickIdeasMenu();

                    homePage.CheckforViewPage();

                    ideasPage = new ViewIdeasPage(this.Driver, this.CurrentTest);
                    Assert.AreEqual(firstRow.P5, ideasPage.GetIdeasPageHeader());
                    ideasPage.ClickSubmitIdea();
                    ideasPage.CheckforSubmitPage();

                    submitIdeaPage = new SubmitIdeaPage(this.Driver, this.CurrentTest);
                    Assert.AreEqual(firstRow.P6, submitIdeaPage.GetIdeasPageHeader().ToLower());
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

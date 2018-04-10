using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automation.AutoTests.Common;
using Automation.AutoTests.PageModels;

namespace Automation.AutoTests.Tests
{
    [TestClass]
    public class SubmitIdeasTest : TestBase
    {
        LoginPage loginPage;
        HomePage homePage;
        ViewIdeasPage ideasPage;
        SubmitIdeaPage submitIdeaPage;

        [TestCategory("Success")]
        [TestMethod]
        public void Check_HomePage_SubmitIdeaClick_Correct()
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

                    ideasPage.ClickSubmitIdea();
                    ideasPage.CheckforSubmitPage();

                    submitIdeaPage = new SubmitIdeaPage(this.Driver, this.CurrentTest);
                    Assert.AreEqual(firstRow.P6, submitIdeaPage.GetIdeasPageHeader().ToLower());

                    ///set idea			
                    Idea idea = new Idea();
                    idea.IdeaTitle = firstRow.P7;
                    idea.IdeaDesc = firstRow.P8;
                    idea.IdeaTags = firstRow.P9;
                    idea.IdeaTeammembers = firstRow.P10;
                    idea.AssistanceRequired = true;
                    idea.IdeaCategory = IdeaCategory.CSR;
                    idea.IdeaBusiness = IdeaBusiness.Gas;
                    //idea.IdeaCountry = IdeaCountry.India;
                    //idea.IdeaState = IdeaState.Gujarat;
                    //idea.IdeaCity = IdeaCity.Ahmedabad;
                    idea.ActionPlan = firstRow.P14;
                    idea.Benefits = firstRow.P15;
                    idea.Objective = firstRow.P13;
                    submitIdeaPage.SubmitIdea(idea);
                    Assert.AreEqual(firstRow.P11, submitIdeaPage.GetConfirmationMesg().ToLower());

                    submitIdeaPage.SubmitIdeaYesClick();
                    StringAssert.StartsWith(submitIdeaPage.GetIdeaSubmittedMesg().ToLower(), firstRow.P12);

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
        public void Check_HomePage_SaveDraftIdeaClick_Correct()
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

                    ideasPage.ClickSubmitIdea();
                    ideasPage.CheckforSubmitPage();

                    submitIdeaPage = new SubmitIdeaPage(this.Driver, this.CurrentTest);
                    Assert.AreEqual(firstRow.P6, submitIdeaPage.GetIdeasPageHeader().ToLower());

                    ///set idea			
                    Idea idea = new Idea();
                    idea.IdeaTitle = firstRow.P7;
                    idea.IdeaDesc = firstRow.P8;
                    idea.IdeaTags = firstRow.P9;
                    idea.IdeaTeammembers = firstRow.P10;
                    idea.AssistanceRequired = true;
                    idea.IdeaCategory = IdeaCategory.CSR;
                    idea.IdeaBusiness = IdeaBusiness.Gas;
                    //idea.IdeaCountry = IdeaCountry.India;
                    //idea.IdeaState = IdeaState.Gujarat;
                    //idea.IdeaCity = IdeaCity.Ahmedabad;
                    idea.ActionPlan = firstRow.P14;
                    idea.Benefits = firstRow.P15;
                    idea.Objective = firstRow.P13;
                    submitIdeaPage.SaveDraftIdea(idea);
                   
                    StringAssert.StartsWith(submitIdeaPage.GetIdeaSubmittedMesg().ToLower(), firstRow.P12);

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
        public void Check_HomePage_CancelClick_Correct()
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

                    ideasPage.ClickSubmitIdea();
                    ideasPage.CheckforSubmitPage();

                    submitIdeaPage = new SubmitIdeaPage(this.Driver, this.CurrentTest);
                    Assert.AreEqual(firstRow.P6, submitIdeaPage.GetIdeasPageHeader().ToLower());

                    ///set idea			
                    Idea idea = new Idea();
                    idea.IdeaTitle = firstRow.P7;
                    idea.IdeaDesc = firstRow.P8;
                    idea.IdeaTags = firstRow.P9;
                    idea.IdeaTeammembers = firstRow.P10;
                    idea.AssistanceRequired = true;
                    idea.IdeaCategory = IdeaCategory.CSR;
                    idea.IdeaBusiness = IdeaBusiness.Gas;
                    //idea.IdeaCountry = IdeaCountry.India;
                    //idea.IdeaState = IdeaState.Gujarat;
                    //idea.IdeaCity = IdeaCity.Ahmedabad;
                    idea.ActionPlan = firstRow.P14;
                    idea.Benefits = firstRow.P15;
                    idea.Objective = firstRow.P13;
                    submitIdeaPage.CancelIdea(idea);

                    Assert.IsTrue(submitIdeaPage.CheckIfTitleEmpty());
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
        public void Check_HomePage_SubmitIdeaFileUpload_Correct()
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

                    ideasPage.ClickSubmitIdea();
                    ideasPage.CheckforSubmitPage();

                    submitIdeaPage = new SubmitIdeaPage(this.Driver, this.CurrentTest);
                    Assert.AreEqual(firstRow.P6, submitIdeaPage.GetIdeasPageHeader().ToLower());

                    ///set idea			
                    Idea idea = new Idea();
                    idea.IdeaTitle = firstRow.P7;
                    idea.IdeaDesc = firstRow.P8;
                    idea.IdeaTags = firstRow.P9;
                    idea.IdeaTeammembers = firstRow.P10;
                    idea.AssistanceRequired = true;
                    idea.IdeaCategory = IdeaCategory.CSR;
                    idea.IdeaBusiness = IdeaBusiness.Gas;
                    //idea.IdeaCountry = IdeaCountry.India;
                    //idea.IdeaState = IdeaState.Gujarat;
                    //idea.IdeaCity = IdeaCity.Ahmedabad;
                    idea.ActionPlan = firstRow.P14;
                    idea.Benefits = firstRow.P15;
                    idea.Objective = firstRow.P13;
                    submitIdeaPage.FileUpload(firstRow.P16);

                    submitIdeaPage.SubmitIdea(idea);
                    Assert.AreEqual(firstRow.P11, submitIdeaPage.GetConfirmationMesg().ToLower());

                    submitIdeaPage.SubmitIdeaYesClick();
                    StringAssert.StartsWith(submitIdeaPage.GetIdeaSubmittedMesg().ToLower(), firstRow.P12);

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
        public void Check_HomePage_SubmitIdeaFileUpload_InCorrect()
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

                    ideasPage.ClickSubmitIdea();
                    ideasPage.CheckforSubmitPage();

                    submitIdeaPage = new SubmitIdeaPage(this.Driver, this.CurrentTest);
                    Assert.AreEqual(firstRow.P6, submitIdeaPage.GetIdeasPageHeader().ToLower());

                    ///set idea			
                    Idea idea = new Idea();
                    idea.IdeaTitle = firstRow.P7;
                    idea.IdeaDesc = firstRow.P8;
                    idea.IdeaTags = firstRow.P9;
                    idea.IdeaTeammembers = firstRow.P10;
                    idea.AssistanceRequired = true;
                    idea.IdeaCategory = IdeaCategory.CSR;
                    idea.IdeaBusiness = IdeaBusiness.Gas;
                    //idea.IdeaCountry = IdeaCountry.India;
                    //idea.IdeaState = IdeaState.Gujarat;
                    //idea.IdeaCity = IdeaCity.Ahmedabad;
                    idea.ActionPlan = firstRow.P14;
                    idea.Benefits = firstRow.P15;
                    idea.Objective = firstRow.P13;
                    submitIdeaPage.FileUpload(firstRow.P16);
                    var result = submitIdeaPage.GetValidationMessage();
                    //submitIdeaPage.SubmitIdea(idea);
                    Assert.AreEqual(firstRow.P11, result);

                    //submitIdeaPage.SubmitIdeaYesClick();
                    //StringAssert.StartsWith(submitIdeaPage.GetIdeaSubmittedMesg().ToLower(), firstRow.P12);
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
        public void Check_HomePage_DescriptionMorethan300Words_InCorrect()
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

                    ideasPage.ClickSubmitIdea();
                    ideasPage.CheckforSubmitPage();

                    submitIdeaPage = new SubmitIdeaPage(this.Driver, this.CurrentTest);
                    Assert.AreEqual(firstRow.P6, submitIdeaPage.GetIdeasPageHeader().ToLower());

                    ///set idea			
                    Idea idea = new Idea();
                    idea.IdeaTitle = firstRow.P7;
                    idea.IdeaDesc = firstRow.P8;
                    idea.IdeaTags = firstRow.P9;
                    idea.IdeaTeammembers = firstRow.P10;
                    idea.AssistanceRequired = true;
                    idea.IdeaCategory = IdeaCategory.CSR;
                    idea.IdeaBusiness = IdeaBusiness.Gas;
                    //idea.IdeaCountry = IdeaCountry.India;
                    //idea.IdeaState = IdeaState.Gujarat;
                    //idea.IdeaCity = IdeaCity.Ahmedabad;
                    idea.ActionPlan = firstRow.P14;
                    idea.Benefits = firstRow.P15;
                    idea.Objective = firstRow.P13;
                    //submitIdeaPage.FileUpload(firstRow.P16);
                    submitIdeaPage.SubmitIdea(idea);
                    Assert.AreEqual(firstRow.P11, submitIdeaPage.GetConfirmationMesg().ToLower());

                    submitIdeaPage.SubmitIdeaYesClick();
                    StringAssert.StartsWith(submitIdeaPage.GetIdeaSubmittedMesg().ToLower(), firstRow.P12);
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

using Automation.AutoTests.Common;
using Automation.AutoTests.PageModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation.AutoTests.Tests
{
    [TestClass]
    public class ApproveIdeaTest : TestBase
    {
        LoginPage loginPage;
        HomePage homePage;
        ViewIdeasPage ideasPage;
        SubmitIdeaPage submitIdeaPage;
        IdeaApprover approver;
        ApproveIdea approveIdea;

        [TestCategory("Success")]
        [TestMethod]
        public void Check_Approve_Ideas_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    //Create Login Page object

                    var ideaId = this.CreateIdea(firstRow);
                    this.PublishIdea(firstRow, firstRow.P16, firstRow.P17);
                    this.ApproveIdeaL1(firstRow, firstRow.P18, firstRow.P19);
                    this.ApproveIdeaL2(firstRow, firstRow.P20, firstRow.P21);
                    this.TestPassed($"Test passed for idea - {ideaId}");
                }
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                throw;
            }

        }

        #region BusinessCoordinator
        [TestCategory("Failure")]
        [TestMethod]
        public void Check_Redirect_To_Admin_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    //Create Login Page object

                    var ideaId = this.CreateIdea(firstRow);
                    this.ResendToAdmin(firstRow, firstRow.P16, firstRow.P17);

                    this.CheckFromAdmin(firstRow, firstRow.P1, firstRow.P2);

                    this.TestPassed($"Test passed for idea - {ideaId}");
                }
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                throw;
            }

        }

        [TestCategory("Failure")]
        [TestMethod]
        public void Check_Raise_A_Query_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    //Create Login Page object

                    var ideaId = this.CreateIdea(firstRow);
                    this.AskQueries(firstRow, firstRow.P16, firstRow.P17);

                    this.TestPassed($"Test passed for idea - {ideaId}");
                }
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                throw;
            }

        }

        #endregion

        #region L1Approver
        [TestCategory("Failure")]
        [TestMethod]
        public void Check_Reject_Idea_L1_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    //Create Login Page object

                    var ideaId = this.CreateIdea(firstRow);
                    this.PublishIdea(firstRow, firstRow.P16, firstRow.P17);
                    this.RejectIdeaL1(firstRow, firstRow.P18, firstRow.P19);
                    this.TestPassed($"Test passed for idea - {ideaId}");
                }
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                throw;
            }

        }

        [TestCategory("Failure")]
        [TestMethod]
        public void Check_Reject_Duplicate_Idea_L1_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    //Create Login Page object

                    var ideaId = this.CreateIdea(firstRow);
                    this.PublishIdea(firstRow, firstRow.P16, firstRow.P17);
                    this.RejectIdeaDuplicateL1(firstRow, firstRow.P18, firstRow.P19);
                    this.TestPassed($"Test passed for idea - {ideaId}");
                }
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                throw;
            }

        }

        [TestCategory("Failure")]
        [TestMethod]
        public void Check_Mark_Suggession_Idea_L1_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    //Create Login Page object

                    var ideaId = this.CreateIdea(firstRow);
                    this.PublishIdea(firstRow, firstRow.P16, firstRow.P17);
                    this.MarkAsSuggessionL1(firstRow, firstRow.P18, firstRow.P19);
                    this.TestPassed($"Test passed for idea - {ideaId}");
                }
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                throw;
            }

        }
        [TestCategory("Failure")]
        [TestMethod]
        public void Check_Ask_A_Query_Idea_L1_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    //Create Login Page object

                    var ideaId = this.CreateIdea(firstRow);
                    this.PublishIdea(firstRow, firstRow.P16, firstRow.P17);
                    this.AskAQueryL1(firstRow, firstRow.P18, firstRow.P19);
                    this.TestPassed($"Test passed for idea - {ideaId}");
                }
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                throw;
            }

        }
        #endregion

        #region L2Approver
        [TestCategory("Failure")]
        [TestMethod]
        public void Check_Reject_Idea_L2_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    //Create Login Page object

                    var ideaId = this.CreateIdea(firstRow);
                    this.PublishIdea(firstRow, firstRow.P16, firstRow.P17);
                    this.ApproveIdeaL1(firstRow, firstRow.P18, firstRow.P19);
                    this.RejectIdeaL2(firstRow, firstRow.P20, firstRow.P21);
                    this.TestPassed($"Test passed for idea - {ideaId}");
                }
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                throw;
            }

        }
        [TestCategory("Failure")]
        [TestMethod]
        public void Check_Park_Idea_L2_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    //Create Login Page object

                    var ideaId = this.CreateIdea(firstRow);
                    this.PublishIdea(firstRow, firstRow.P16, firstRow.P17);
                    this.ApproveIdeaL1(firstRow, firstRow.P18, firstRow.P19);
                    this.ParkIdeaL2(firstRow, firstRow.P20, firstRow.P21);
                    this.TestPassed($"Test passed for idea - {ideaId}");
                }
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                throw;
            }

        }
        [TestCategory("Failure")]
        [TestMethod]
        public void Check_Mark_Suggession_Idea_L2_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    //Create Login Page object

                    var ideaId = this.CreateIdea(firstRow);
                    this.PublishIdea(firstRow, firstRow.P16, firstRow.P17);
                    this.ApproveIdeaL1(firstRow, firstRow.P18, firstRow.P19);
                    this.MarkAsSuggessionL2(firstRow, firstRow.P20, firstRow.P21);
                    this.TestPassed($"Test passed for idea - {ideaId}");
                }
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                throw;
            }

        }
        [TestCategory("Failure")]
        [TestMethod]
        public void Check_Ask_A_Query_Idea_L2_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    //Create Login Page object

                    var ideaId = this.CreateIdea(firstRow);
                    this.PublishIdea(firstRow, firstRow.P16, firstRow.P17);
                    this.ApproveIdeaL1(firstRow, firstRow.P18, firstRow.P19);
                    this.AskAQueryL2(firstRow, firstRow.P20, firstRow.P21);
                    this.TestPassed($"Test passed for idea - {ideaId}");
                }
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                throw;
            }

        }
        #endregion

        private void ExecuteIdeaPage(DataModel firstRow, string userName, string password, string selectionCategory, Action<ApproveIdea> ideaMethod)
        {
            loginPage = new LoginPage(this.Driver, this.CurrentTest);
            string loginPageTitle = loginPage.GetLoginTitle();
            //Verify login page title
            Assert.AreEqual(loginPageTitle.ToLower(), firstRow.P3);

            //login to application
            loginPage.LoginToHome(userName, password);

            loginPage.CheckForHome();

            // go the next page
            homePage = new HomePage(this.Driver, this.CurrentTest);
            homePage.ChangeToCategory(selectionCategory);
            this.WaitForReady();
            homePage.ClickIdeasMenu();
            homePage.CheckforViewPage();


            ideasPage = new ViewIdeasPage(this.Driver, this.CurrentTest);
            ideasPage.ClickNotification();
            ideasPage.CheckforNotificationPage();


            approver = new IdeaApprover(this.Driver, this.CurrentTest);
            approver.ApproveIdeas();
            approver.CheckforApproveIdeaPage();

            approveIdea = new ApproveIdea(this.Driver, this.CurrentTest);
            ideaMethod(approveIdea);

            homePage.GetUserLoggedOut();
            homePage.CheckForLoginPage();
        }

        private void ApproveIdeaL1(DataModel firstRow, string userName, string password)
        {
            this.ExecuteIdeaPage(firstRow, userName, password, "Level 1 Approval", (approveIdea) =>
            {
                approveIdea.ApproveIdeaL1();
                approveIdea.CheckForIdeaPublish("Idea approved by level-1.");
            });
        }
       
        private void RejectIdeaL1(DataModel firstRow, string userName, string password)
        {
            this.ExecuteIdeaPage(firstRow, userName, password, "Level 1 Approval", (approveIdea) =>
            {
                approveIdea.RejectIdea(firstRow.P20);
                approveIdea.CheckForIdeaPublish("Idea rejected by Level-1");
            }); 
        }
        private void RejectIdeaL2(DataModel firstRow, string userName, string password)
        {
            this.ExecuteIdeaPage(firstRow, userName, password, "CEO/HOD Approval", (approveIdea) =>
            {
                approveIdea.RejectIdea(firstRow.P22);
                approveIdea.CheckForIdeaPublish("Idea rejected by Level-2");
            });
            
        }
        private void ParkIdeaL2(DataModel firstRow, string userName, string password)
        {
            this.ExecuteIdeaPage(firstRow, userName, password, "CEO/HOD Approval", (approveIdea) =>
            {
                approveIdea.ParkIdea(firstRow.P22);
                approveIdea.CheckForIdeaPublish("Idea Parked.");
            });
        }
        private void RejectIdeaDuplicateL1(DataModel firstRow, string userName, string password)
        {
            this.ExecuteIdeaPage(firstRow, userName, password, "Level 1 Approval", (approveIdea) =>
            {
                approveIdea.RejectIdeaDuplicateL1(firstRow.P20);
                approveIdea.CheckForIdeaPublish("Idea Marked as Duplicate.");
            });
        }
       
        private void MarkAsSuggessionL1(DataModel firstRow, string userName, string password)
        {
            this.ExecuteIdeaPage(firstRow, userName, password, "Level 1 Approval", (approveIdea) =>
            {
                approveIdea.MarkAsSuggession(firstRow.P20);
                approveIdea.CheckForIdeaPublish("Idea marked as suggestion by IA-L1.");
            });
        }
        private void MarkAsSuggessionL2(DataModel firstRow, string userName, string password)
        {
            this.ExecuteIdeaPage(firstRow, userName, password, "CEO/HOD Approval", (approveIdea) =>
            {
                approveIdea.MarkAsSuggessionL2(firstRow.P22);
                approveIdea.CheckForIdeaPublish("Idea marked as suggestion by IA-L2.");
            });
        }
        private void AskAQueryL1(DataModel firstRow, string userName, string password)
        {
            this.ExecuteIdeaPage(firstRow, userName, password, "Level 1 Approval", (approveIdea) =>
            {
                approveIdea.AskAQuery(firstRow.P20);
                
                approveIdea.CheckForPopupClose();
            });
        }
        private void AskAQueryL2(DataModel firstRow, string userName, string password)
        {
            this.ExecuteIdeaPage(firstRow, userName, password, "CEO/HOD Approval", (approveIdea) =>
            {
                approveIdea.AskAQuery(firstRow.P22);
                approveIdea.CheckForPopupClose();
                //approveIdea.CheckForIdeaPublish("Idea marked as suggestion by IA-L1.");
            });
        }
        private void ApproveIdeaL2(DataModel firstRow, string userName, string password)
        {
            this.ExecuteIdeaPage(firstRow, userName, password, "CEO/HOD Approval", (approveIdea) =>
            {
                approveIdea.ApproveIdeaL1();
                approveIdea.CheckForIdeaPublish("Idea approved by level-2.");
            });
           
        }
        private void PublishIdea(DataModel firstRow, string userName, string password)
        {
            this.ExecuteIdeaPage(firstRow, userName, password, "Business Coordinator", (approveIdea) =>
            {
                approveIdea.PublishIdea();
                approveIdea.CheckForIdeaPublish("Idea published.");
            }); 
        }
        private void ResendToAdmin(DataModel firstRow, string userName, string password)
        {
            this.ExecuteIdeaPage(firstRow, userName, password, "Business Coordinator", (approveIdea) =>
            {
                approveIdea.RedirectToAdmin();
                approveIdea.CheckForIdeaPublish("Idea sent to Admin successfully.");
            }); 
        }

        private bool CheckFromAdmin(DataModel firstRow, string userName, string password)
        {
            loginPage = new LoginPage(this.Driver, this.CurrentTest);
            string loginPageTitle = loginPage.GetLoginTitle();
            //Verify login page title
            Assert.AreEqual(loginPageTitle.ToLower(), firstRow.P3);

            //login to application
            loginPage.LoginToHome(userName, password);

            loginPage.CheckForHome();

            // go the next page
            homePage = new HomePage(this.Driver, this.CurrentTest);
            homePage.ClickIdeasMenu();
            homePage.CheckforViewPage();

            ideasPage = new ViewIdeasPage(this.Driver, this.CurrentTest);
            ideasPage.ClickNotification();
            ideasPage.CheckforNotificationPage();

            approver = new IdeaApprover(this.Driver, this.CurrentTest);

            return approver.CheckForIdeaRedirect();

            
        }

        private void AskQueries(DataModel firstRow, string userName, string password)
        {
            this.ExecuteIdeaPage(firstRow, userName, password, "Business Coordinator", (approveIdea) =>
            {
                approveIdea.RaiseQuery(firstRow.P18);
                approveIdea.CheckForPopupClose();
            });
        }
        private string CreateIdea(DataModel firstRow)
        {
            loginPage = new LoginPage(this.Driver, this.CurrentTest);
            string loginPageTitle = loginPage.GetLoginTitle();
            //Verify login page title
            Assert.AreEqual(loginPageTitle.ToLower(), firstRow.P3);

            //login to application
            loginPage.LoginToHome(firstRow.P1, firstRow.P2);

            loginPage.CheckForHome();

            // go the next page
            homePage = new HomePage(this.Driver, this.CurrentTest);

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
            idea.ActionPlan = firstRow.P14;
            idea.Benefits = firstRow.P15;
            idea.Objective = firstRow.P13;
            submitIdeaPage.SubmitIdea(idea);
            Assert.AreEqual(firstRow.P11, submitIdeaPage.GetConfirmationMesg().ToLower());

            submitIdeaPage.SubmitIdeaYesClick();

            var ideaId = submitIdeaPage.GetIdeaId();
            
            homePage.GetUserLoggedOut();
            homePage.CheckForLoginPage();

            return ideaId;
        }
    }
}

using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Automation.AutoTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Automation.AutoTests.PageModels
{
    public class ApproveIdea : PageObjectBase
    {
        public ApproveIdea(IWebDriver driver, ExtentTest test)
            :base(driver, test)
        {

        }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_lnkbtnPublish")]
        private IWebElement PublishButton { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_lnkbtnRedirectToAdmin")]
        private IWebElement RedirectToAdminButton { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_lnkbtnRaiseAQuery")]
        private IWebElement RaiseQueryButton { get; set; }
        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_txtRemark")]
        private IWebElement txtRemark { get; set; }
       
        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_lnkbtnSaveApproveIdeaDetails")]
        private IWebElement ApproveIdeaButton { get; set; }
        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_lnkbtnSaveRejectIdeaDetails")]
        private IWebElement RejectIdeaButton { get; set; }
        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_lnkbtnRejectAsDuplicate")]
        private IWebElement RejectIdeaAsDuplicateButton { get; set; }
        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_lnkbtnIAQuery")]
        private IWebElement AskAQueryButton { get; set; }
        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_btnActionQuerySubmit")]
        private IWebElement AskAQueryConfirmButton { get; set; }
        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_btnActionDuplicateSubmit")]
        private IWebElement RejectIdeaAsDuplicateConfirmButton { get; set; }
        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_btnActionSuggestionSubmit")]
        private IWebElement MarkAsSuggessionConfirmButton { get; set; }
        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_lnkbtnMarkAsSuggestion")]
        private IWebElement MarkAsSuggessionButton { get; set; }
        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_lnkbtnParkIdea")]
        private IWebElement ParkButton { get; set; }
        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_btnYes")]
        public IWebElement btnPublishIdeaYesButton { get; set; }
        
        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_txtRewardAmount")]
        public IWebElement txtRewardAmount { get; set; }
        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_btnCancel")]
        public IWebElement btnPublishIdeaCancelButton { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_btnActionQuerySubmit")]
        public IWebElement btnSubmitQuery { get; set; }

        public void PublishIdea()
        {
            this.TestInfo("Clicking on publish for confirmation");
            this.PublishButton.Click();
            this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_h4ConfirmationMessage"), 50);
            this.btnPublishIdeaYesButton.Click();
        }

        public void RedirectToAdmin()
        {
            this.TestInfo("Clicking on Redirect to Admin ");
            this.RedirectToAdminButton.Click();
            this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_h4ConfirmationMessage"), 50);
            this.btnPublishIdeaYesButton.Click();
        }

        public void RaiseQuery(string queryText)
        {
            this.TestInfo("Clicking on Raise a Query");
            this.RaiseQueryButton.Click();
            var popUpText = this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_txtCommentQuery"), 50);
            popUpText.SendKeys(queryText);

            this.btnSubmitQuery.Click();
        }

        public void ApproveIdeaL1()
        {
            this.TestInfo("Clicking on Approve idea 1");
            this.ApproveIdeaButton.Click();
            this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_h4ConfirmationMessage"), 50);
            this.btnPublishIdeaYesButton.Click();
        }

        public void RejectIdea(string remarks)
        {
            this.TestInfo("Clicking on Reject Idea");
            this.txtRemark.SendKeys(remarks);
            this.RejectIdeaButton.Click();
            this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_h4ConfirmationMessage"), 50);
            this.btnPublishIdeaYesButton.Click();
        }
        public void ParkIdea(string remarks)
        {
            this.TestInfo("Clicking on Park idea");
            this.txtRemark.SendKeys(remarks);
            this.ParkButton.Click();
            this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_h4ConfirmationMessage"), 50);
            this.btnPublishIdeaYesButton.Click();
        }
        public void RejectIdeaDuplicateL1(string remarks)
        {
            this.TestInfo("Clicking on Reject as duplicate by L1");
            this.RejectIdeaAsDuplicateButton.Click();

            var element = this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_txtCommentDuplicate"), 50);
            element.SendKeys(remarks); 
            this.RejectIdeaAsDuplicateConfirmButton.Click();
            this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_h4ConfirmationMessage"), 50);
            this.btnPublishIdeaYesButton.Click();
        }
        public void MarkAsSuggession(string remarks)
        {
            this.TestInfo("Clicking on Mark as suggession");
            this.MarkAsSuggessionButton.Click();
            var element = this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_txtCommentSuggestion"), 50);
            element.SendKeys(remarks); 
            this.MarkAsSuggessionConfirmButton.Click();
            this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_h4ConfirmationMessage"), 50);
            this.btnPublishIdeaYesButton.Click();
        }
        public void MarkAsSuggessionL2(string remarks)
        {
            this.TestInfo("Clicking on Mark as suggession by CEO");
            this.MarkAsSuggessionButton.Click();
            var element = this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_btnActionSuggestionSubmit"), 50);
            element.Click();
            element = this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_btnYes"), 50);
            element.Click();
            element = this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_lblIdeaStatus"), 50);
            var hasdata = element.Text.Contains("Idea marked as suggestion");
            Assert.AreEqual(hasdata, true);
            //this.MarkAsSuggessionConfirmButton.Click();
            //this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_lblIdeaStatus"), 50);
            //this.btnPublishIdeaYesButton.Click();
        }
        public void AskAQuery(string remarks)
        {
            this.TestInfo("Clicking on Ask a query");
            this.AskAQueryButton.Click();
            var element = this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_txtCommentQuery"), 50);
            element.SendKeys(remarks); 
            this.AskAQueryConfirmButton.Click();
        }
        public bool CheckForIdeaPublish(string message)
        {
            var element = this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_lblIdeaStatus"), 50);
            return element.Text == message; 
        }
        public bool CheckForPopupClose()
        { 
            var element = this.CurrentDriver.LoseElement(By.Id("MenuMasterContentHolder_txtCommentQuery"), 50);
            
            return element != null; 
        }
        public bool CheckForActivity()
        {
            this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_lnktabActivities"), 50);
            return true;
        }
    }
}

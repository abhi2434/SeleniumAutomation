using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.AutoTests.Common;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using AventStack.ExtentReports;

namespace Automation.AutoTests.PageModels
{
    public class SubmitIdeaPage : PageObjectBase
    {
        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_h3IdeaHeader")]
        public IWebElement lblSubmitIdeasPgeHeader { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_txtIdeaTitle")]
        public IWebElement txtIdeaTitle { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_txtIdeaDescription")]
        public IWebElement txtIdeaDescFrame { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_txtIdeaTags_tag")]
        public IWebElement txtIdeaTags { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_ddlIdeaCategories")]
        public IWebElement ddlIdeaCategory { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_ddlBusinessUnit")]
        public IWebElement ddlIdeaBusiness { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_ddlCountry")]
        public IWebElement ddlIdeaCountry { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_ddlLocation")]
        public IWebElement ddlIdeaState { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_ddlMission")]
        public IWebElement ddlIdeaCity { get; set; }

        [FindsBy(How = How.Name, Using = "ctl00$MenuMasterContentHolder$rbtnlistAssistance")]
        public IList<IWebElement> radioAssistanceRequired { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_gridviewTeamMembers_txtEmailID")]
        public IWebElement txtTeammembers { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_txtObjectiveOfIdea")]
        public IWebElement txtObjective { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_txtActionPlanForIdea")]
        public IWebElement txtActionPlan { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_txtBenefitsOfIdea")]
        public IWebElement txtBenefits { get; set; }
        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_chkbAnonymity")]
        public IWebElement chkboxAnnonymous { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_btnSubmitIdea")]
        public IWebElement btnSubmitButton { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_btnSaveAsDraft")]
        public IWebElement btnSaveDraftButton { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_btnCancelIdea")]
        public IWebElement btnCancelButton { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_h2")]
        public IWebElement lblConfirmationMesg { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_lblsubmitMsg")]
        public IWebElement lblIdeaSubmittedMesg { get; set; }

        [FindsBy(How = How.Id, Using = "btnPanelSubmitIdeamesgYes")]
        public IWebElement btnSubmitIdeaYesButton { get; set; }

        [FindsBy(How = How.Id, Using = "MenuMasterContentHolder_btnPanelSubmitIdeamesgNo")]
        public IWebElement btnSubmitIdeaNoButton { get; set; }

       [FindsBy(How = How.Id, Using = "dZUpload")]
        public IWebElement fileUploader { get; set; }

        public SubmitIdeaPage(IWebDriver driver, ExtentTest test)
            :base(driver, test)
        {
 
        }

        public string GetIdeasPageHeader()
        {
            this.TestInfo("Getting ideas page header");
            this.CurrentDriver.Wait(120);
            return lblSubmitIdeasPgeHeader.Text;
        }

        public string GetConfirmationMesg()
        {
            this.TestInfo("Getting confirmation message");
            this.CurrentDriver.Wait(120);
            return lblConfirmationMesg.Text;
        }

        public string GetIdeaSubmittedMesg()
        {
            this.TestInfo("Getting submitted idea");
            return lblIdeaSubmittedMesg.Text;
        }

        public void SubmitIdea(Idea idea)
        {
            this.TestInfo("Going to Submit an idea");
            this.SetIdeaDetails(idea);
            this.ClickSubmit();
        }

        public string GetValidationMessage()
        {
            var element = this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_RegularExpressionValidator1"), 50);
            return element.Text;
        }

        public void SaveDraftIdea(Idea idea)
        {
            this.CurrentTest.Info("Going to save draft an idea");
            this.SetIdeaDetails(idea);
            this.ClickSaveDraft();
        }

        public void CancelIdea(Idea idea)
        {
            this.TestInfo("Going to cancel an idea submission");
            this.SetIdeaDetails(idea);
            this.ClickCancel();
        }

        public string CheckErrorPage()
        {
            var element = this.CurrentDriver.FindElement(By.ClassName("error-details"), 50);
            return element.Text;
        }

        public void SubmitIdeaYesClick()
        {
            this.TestInfo("Clicking on Yes for confirmation");
            btnSubmitIdeaYesButton.Click();
        }

        public void SubmitIdeaNoClick()
        {
            this.TestInfo("Clicking on Yes for confirmation");
            btnSubmitIdeaNoButton.Click();
        }
        public void CheckIdeaAnnonymous()
        {
            this.TestInfo("Select Annonymous");
            chkboxAnnonymous.Click();
        }
        private void ClickSubmit()
        {
            this.TestInfo("Clicking on submit button");
            btnSubmitButton.Click();
        }
        private void ClickSaveDraft()
        {
            this.TestInfo("Clicking on Safe draft button");
            btnSaveDraftButton.Click();
        }

        private void ClickCancel()
        {
            this.TestInfo("Clicking on Cancel button");
            btnCancelButton.Click();
        }

        private void SetIdeaDetails(string title)
        {
            this.TestInfo("Setting idea details");
            txtIdeaTitle.SendKeys(title);
        }
        private void SetIdeaTitle(string title)
        {
            this.TestInfo("Setting idea title");
            txtIdeaTitle.SendKeys(title);
        }
        private void SetIdeaObjective(string objective)
        {
            this.TestInfo("Setting idea objective");
            txtObjective.SendKeys(objective);
        }
        private void SetIdeaActionPlan(string actionPlan)
        {
            this.TestInfo("Setting idea action plan");
            txtActionPlan.SendKeys(actionPlan);
        }
        private void SetIdeaBenefits(string benefits)
        {
            this.TestInfo("Setting benefits");
            txtBenefits.SendKeys(benefits);
        }
        private void SetIdeaDesc(string desc)
        {
            //IWebDriver frame = this.CurrentDriver.SwitchTo().Frame(this.CurrentDriver.FindElement(By.ClassName("cke_wysiwyg_frame")));
            //IWebElement txtIdeaDesc = frame.FindElement(By.ClassName("cke_editable"));
            //txtIdeaDesc.SendKeys(desc);
            //this.CurrentDriver.SwitchTo().DefaultContent();
            this.SetClipboardContents(desc);
            this.txtIdeaDescFrame.Click();
            this.txtIdeaDescFrame.SendKeys(Keys.Control + "v");

            //this.txtIdeaDescFrame.SendKeys(desc);
        }
        public void SetClipboardContents(string text)
        {
            this.TestInfo("Coping item to clipboard");
            System.Windows.Forms.Clipboard.SetText(text);
        }
        private void SetIdeaTags(string tags)
        {
            this.TestInfo("Setting up tags");
            txtIdeaTags.SendKeys(tags);
        }

        private void SetIdeaCategory(string category)
        {
            this.TestInfo("Setting up category");
            this.CurrentDriver.Wait(120);
            SelectElement select = new SelectElement(ddlIdeaCategory);
            select.SelectByText(category);
        }

        private void SetIdeaBusiness(String business)
        {
            this.TestInfo("Setting business unit");
            this.CurrentDriver.Wait(120);
            SelectElement select = new SelectElement(ddlIdeaBusiness);
            select.SelectByText(business);
        }

        private void SetIdeaCountry(String country)
        {
            this.TestInfo("Setting country");
            WebDriverWait wait = new WebDriverWait(this.CurrentDriver, TimeSpan.FromSeconds(180));
            wait.Until(ExpectedConditions.TextToBePresentInElement(ddlIdeaCountry, country));
            SelectElement select = new SelectElement(ddlIdeaCountry);
            select.SelectByText(country);
        }

        private void SetIdeaState(String state)
        {
            this.TestInfo("Selecting state for the entry");
            WebDriverWait wait = new WebDriverWait(this.CurrentDriver, TimeSpan.FromSeconds(180));
            wait.Until(ExpectedConditions.TextToBePresentInElement(ddlIdeaState, state));
            SelectElement select = new SelectElement(ddlIdeaState);
            select.SelectByText(state);
        }

        private void SetIdeaCity(String city)
        {
            this.TestInfo("Selecting city");
            WebDriverWait wait = new WebDriverWait(this.CurrentDriver, TimeSpan.FromSeconds(130));
            wait.Until(ExpectedConditions.TextToBePresentInElement(ddlIdeaCity, city));
            SelectElement select = new SelectElement(ddlIdeaCity);
            select.SelectByText(city);
        }

        private void SetTeamMemberNames(String names)
        {
            this.TestInfo("Setting team member names");
            txtTeammembers.SendKeys(names);
        }

        private void SetAssistanceRequiredYes()
        {
            radioAssistanceRequired.ElementAt(0).Click();
        }

        private void SetAssistanceRequiredNo()
        {
            radioAssistanceRequired.ElementAt(1).Click();
        }

        private void SetIdeaDetails(Idea idea)
        {
            SetIdeaTitle(idea.IdeaTitle);
            SetIdeaDesc(idea.IdeaDesc);
            SetIdeaTags(idea.IdeaTags);
            SetIdeaCategory(Idea.IdeaCategoryString(idea.IdeaCategory));
            SetIdeaBusiness(Idea.IdeaBusinessString(idea.IdeaBusiness));
            //SetIdeaCountry(Idea.IdeaCountryString(idea.IdeaCountry));
            //SetIdeaState(Idea.IdeaStateString(idea.IdeaState));
            //SetIdeaCity(Idea.IdeaCityString(idea.IdeaCity));
            //if (idea.AssistanceRequired)
            //    SetAssistanceRequiredYes();
            //else
            //    SetAssistanceRequiredNo();
            SetIdeaActionPlan(idea.ActionPlan);
            SetIdeaObjective(idea.Objective);
            SetIdeaBenefits(idea.Benefits);
            SetTeamMemberNames(idea.IdeaTeammembers);
            //CheckIdeaAnnonymous();
        }

        public bool CheckIfTitleEmpty()
        {
            return string.IsNullOrEmpty(this.txtIdeaTitle.Text);
        }

        public void FileUpload(string filePath)
        {

            this.TestInfo("Uploading File : " + filePath);

            //IJavaScriptExecutor js = CurrentDriver as IJavaScriptExecutor;
            //js.ExecuteScript("var myZone, blob, base64Image; myZone = Dropzone.forElement('#receiptDropzone');" +
            //  @"base64Image = '/9j/4AAQSkZJRgABAQEASABIAAD/2wCEAAgGBgcGBQgHBwcJCQgKDBQNDAsLDBkSEw8UHRofHh0aHBwgJC4nICIsIxwcKDcpLDAxNDQ0Hyc5PTgyPC4zNDIBCQkJDAsMGA0NGDIhHCEyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMv/AABEIABYAFgMBEQACEQEDEQH/xABQAAADAQAAAAAAAAAAAAAAAAAAAQIHEAEBAAAAAAAAAAAAAAAAAAAAEQEBAQEAAAAAAAAAAAAAAAAAAAECEQEAAAAAAAAAAAAAAAAAAAAA/9oADAMBAAIRAxEAPwDH6jR0BQSBgATQMAD/2Q==';" +
            //  "function base64toBlob(r,e,n){e=e||\"\",n=n||512;for(var t=atob(r),a=[],o=0;o<t.length;o+=n){for(var l=t.slice(o,o+n),h=new Array(l.length),b=0;b<l.length;b++)h[b]=l.charCodeAt(b);var v=new Uint8Array(h);a.push(v)}var c=new Blob(a,{type:e});return c}" +
            //   "blob = base64toBlob(base64Image, 'image / png');" +
            //   "blob.name = 'testfile.png';" +
            //   "myZone.addFile(blob);"
            //);

            IAllowsFileDetection allowsDetection = (IAllowsFileDetection)this.CurrentDriver;
            allowsDetection.FileDetector = new LocalFileDetector();
            //this.fileUploader.Click();
            this.fileUploader.SendKeys(filePath);
        }

        public string GetIdeaId()
        {
            var element = this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_lblsubmitMsg"), 50);
            string text = element.Text;
            var position = text.IndexOf('-');
            
            return text.Substring(position, text.Length - position);
        }
    }
}

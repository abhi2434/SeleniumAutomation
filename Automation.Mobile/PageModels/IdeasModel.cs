using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Automation.Mobile.PageModels
{
    public class IdeasModel: PageObjectBase
    {

        [FindsBy(How = How.ClassName, Using = "subidea_btn")]
        public IWebElement btnAdd { get; set; }

        [FindsBy(How = How.ClassName, Using = "android.webkit.WebView")]
        public IWebElement WebFrame { get; set; }

        [FindsBy(How = How.Id, Using = "idea_title")]
        public IWebElement txtIdeaTitle { get; set; }

        [FindsBy(How = How.Id, Using = "idea_desc")]
        public IWebElement txtIdeaDescription { get; set; }
        [FindsBy(How = How.Id, Using = "idea_obj")]
        public IWebElement txtIdeaObjective { get; set; }
        [FindsBy(How = How.Id, Using = "idea_action")]
        public IWebElement txtIdeaActionPlan { get; set; }
        [FindsBy(How = How.Id, Using = "idea_benifits")]
        public IWebElement txtIdeaBenefits { get; set; }

        [FindsBy(How = How.Id, Using = "ddlBusinessUnit")]
        public IWebElement drpIdeaBusinessUnit { get; set; }
        [FindsBy(How = How.Id, Using = "ddlCatagories")]
        public IWebElement drpIdeaCategories { get; set; }
        [FindsBy(How = How.ClassName, Using = "next_btn")]
        public IWebElement btnIdeaSubmitButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "draft_btn")]
        public IWebElement btnIdeaDraft { get; set; }


        public IdeasModel(AppiumDriver<IWebElement> driver, ExtentTest test)
            :base(driver, test)
        {

        }

        public void ClickAdd()
        {
            this.WaitForInvisibility(By.Id("gifload"));
            AndroidElement ideasButton = (AndroidElement)this.CurrentDriver.FindElementById("IdeasListContent");
            Thread.Sleep(2000);
            var element = ideasButton.FindElementByAndroidUIAutomator("new UiSelector().text(\"mob_submit\")");
            element.Click();
            
        }

        public void AddDetailsForFrame(string titile, string description, string objective,
            string actionPlan, string benefits, string businessUnit, string category)
        {
            this.WaitForReady(By.Id("common_back"));
            this.CurrentDriver.Context = this.CurrentDriver.Contexts[1];
            var submitIdea = this.CurrentDriver.FindElementById("SubmitIdeaScreen");
            var txtIdeaTitle = submitIdea.FindElement(By.Id("idea_title"));
            txtIdeaTitle.SendKeys(titile);
            var txtIdeaDescription = submitIdea.FindElement(By.Id("idea_desc"));
            txtIdeaDescription.SendKeys(description);
            var txtIdeaObjective = this.CurrentDriver.FindElementById("idea_obj");
            txtIdeaObjective.SendKeys(objective);
            var txtIdeaActionPlan = this.CurrentDriver.FindElementById("idea_action");
            txtIdeaActionPlan.SendKeys(actionPlan);
            var txtIdeaBenefits = this.CurrentDriver.FindElementById("idea_benifits");
            txtIdeaBenefits.SendKeys(benefits);

            //var uiElements = this.CurrentDriver.FindElementsByClassName("ui-link");
            //var infoElement = this.GetInfoElement(uiElements, "Info");
            IJavaScriptExecutor executer = this.CurrentDriver;
            executer.ExecuteScript("$('#SubmitInfo').addClass('active');$('#SubmitDetail').removeClass('active');");
         
            this.WaitForReady(By.ClassName("idea_details1"));

            SelectElement selectBu = new SelectElement(this.drpIdeaBusinessUnit);
            selectBu.SelectByText(businessUnit);
            SelectElement selectCat = new SelectElement(this.drpIdeaCategories);
            selectCat.SelectByText(category);

            this.btnIdeaSubmitButton.Click();

            this.WaitForInvisibility(By.Id("gifload"));

        }

        internal void SelectApprovals()
        {
            var selectPage = this.CurrentDriver.FindElementById("selectPage");
            SelectElement select = new SelectElement(selectPage);
            select.SelectByText("Approvals");
        }
        internal void SelectFirstItem()
        {
            var ideaList = this.CurrentDriver.FindElementsByClassName("idea_template");
            var idea = ideaList[0];
            idea.Click();
        }

        internal void PublishIdea(string comments)
        {
            var approvalButton = this.CurrentDriver.FindElementById("ShowApprovals");
            approvalButton.Click();
            var publishButton = this.WaitForReady(By.Id("bc_approval"));
            publishButton.Click();
            var commentBox = this.WaitForReady(By.Id("bu_publish_text"));
            commentBox.SendKeys(comments);
            //this.CurrentDriver.Context = this.CurrentDriver.Contexts[0];
            var btnPublish = this.WaitForClick("bu_publish_yes");
            Actions actions = new Actions(this.CurrentDriver);
            
            actions.MoveToElement(btnPublish).Click().Perform(); 
        }

        public void SetRole(string selectedRole)
        {
            var openButton = this.CurrentDriver.FindElementById("open-button");
            openButton.Click();
            SelectElement element = new SelectElement(this.WaitForReady("ddlViewBy"));
            element.SelectByText(selectedRole);
            var approvalButton = this.CurrentDriver.FindElementById("ShowApprovals");
            approvalButton.Click();
        }

        internal void L1Approve(string comments)
        {
            var l1ApproveButton = this.WaitForReady(By.Id("l1_approval"));
            l1ApproveButton.Click();

            var commentBox = this.WaitForReady(By.Id("l1_approve_text"));
            commentBox.SendKeys(comments);
            var btnApproveL1 = this.WaitForReady("l1_approve_yes");
            btnApproveL1.Click();
        }

        internal void L2Approve(string comments)
        {
           
            var l1ApproveButton = this.WaitForReady(By.Id("l2_approve"));
            l1ApproveButton.Click();

            var commentBox = this.WaitForReady(By.Id("l2_approve_text"));
            commentBox.SendKeys(comments);
            var btnApproveL1 = this.WaitForReady("l2_approve_yes");
            btnApproveL1.Click();
        }

        private AndroidElement GetInfoElement(ReadOnlyCollection<IWebElement> uiElements, string searchText)
        {
            foreach (var element in uiElements)
            {
                if (element.Text == searchText)
                    return (AndroidElement)element;
            }
            return null;
        }

        
    }
}

using AventStack.ExtentReports;
using Automation.AutoTests.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation.AutoTests.PageModels
{
    public class UserManagementPage : PageObjectBase
    {

        public UserManagementPage(IWebDriver driver, ExtentTest test)
            :base(driver, test)
        {

        }
        
        [FindsBy(How= How.XPath, Using = "//*[@id=\"ProfileMasterContentHolder_updtpnlUserManagement\"]/div/div[1]/h1")]
        public IWebElement HeaderUserManagementText { get; set; }

        [FindsBy(How= How.XPath, Using = "//*[@id=\"ProfileMasterContentHolder_updtpnlAssignRole\"]/div/div[1]/h1")]
        public IWebElement HeaderAssignRoleText { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_imgbtnAddSingleUser")]
        public IWebElement AddUserButton { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_lblPopupUpdateUserHeader")]
        public IWebElement PopupAddUserHeader { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_lblPopupUpdateDepartmentHeader")]
        public IWebElement PopupDepartmentHeader { get; set; }
        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_lblPopupUpdateCategoryHeader")]
        public IWebElement PopupCategoryHeader { get; set; }
        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_lblPopupUpdateLocationHeader")]
        public IWebElement PopupLocationHeader { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_txtFirstName")]
        public IWebElement txtFirstName { get; set; }
        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_txtLastName")]
        public IWebElement txtLastName { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_txtEmployeeCode")]
        public IWebElement txtEmpCode { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_txtDepartmentName")]
        public IWebElement txtDepartmentName { get; set; }
        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_txtCategoryName")]
        public IWebElement txtCategoryName { get; set; }
        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_txtColorCode")]
        public IWebElement txtColorCode { get; set; }
        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_txtLocationName")]
        public IWebElement txtLocationName { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_txtEmail")]
        public IWebElement txtEmail { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_txtBirthDate")]
        public IWebElement txtBirthDate { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_txtDesignation")]
        public IWebElement txtDesignation { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_ddlCountry")]
        public IWebElement ddlCountry { get; set; }

        [FindsBy(How = How.Id, Using = "UserManagementID")]
        public IWebElement btnUserManagement { get; set; }

        [FindsBy(How = How.Id, Using = "Li6")]
        public IWebElement btnAssignRole { get; set; }

        //[FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_ddlBusinessUnit")]
        //public IWebElement ddlBusinessunit { get; set; }
        //[FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_ddlDepartment")]
        //public IWebElement ddlDepartment { get; set; }
        //[FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_ddlLocation")]
        //public IWebElement ddlLocation { get; set; }

        //[FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_ddlCompany")]
        //public IWebElement ddlCompany { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_fileuploadCategoryIcon")]
        public IWebElement fileUploader { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_btnUpdateUserSubmit")]
        public IWebElement btnSubmit { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_lblPopupAssignRole")]
        public IWebElement hdrAssignRole { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_imgbtnAddSingleUser")]
        public IWebElement btnAdd { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_rdblGender_0")]
        public IWebElement rdMale { get; set; }
        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_rdblGender_1")]
        public IWebElement rdFemale { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_txtBusinessCoordinator")]
        public IWebElement BCEmail { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_txtIdeaApproverL1")]
        public IWebElement IA1Email { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_txtIdeaApproverL2")]
        public IWebElement IA2Email { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_btnAssignRoleSubmit")]
        public IWebElement btnAssignUserRole { get; set; }
        public bool ValidateUserPage(string validateText)
        {
            return this.HeaderUserManagementText.Text.Equals(validateText);
        }
        public bool ValidateRolePage(string validateText)
        {
            var property = this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_updtpnlAssignRole"));

            var header = property.FindElement(By.TagName("h1"));
            return header.Text.Equals(validateText);
        }

       
        internal void ClickOnUserManagementAgain()
        {
            this.CurrentDriver.Navigate().GoToUrl(this.BaseUrl + "/UserManagement.aspx");
            //var anchor = btnUserManagement.FindElement(By.XPath("//a"));
            //anchor.Click();
        }

        internal void ClickDepartment()
        {
            this.CurrentDriver.Navigate().GoToUrl(this.BaseUrl + "/DepartmentManagement.aspx");
        }
        internal void ClickLocation()
        {
            this.CurrentDriver.Navigate().GoToUrl(this.BaseUrl + "/LocationManagement.aspx");
        }
        internal void ClickCategory()
        {
            this.CurrentDriver.Navigate().GoToUrl(this.BaseUrl + "/CategoryManagement.aspx");
        }
        internal void ClickAssignRole()
        {
            this.CurrentDriver.Navigate().GoToUrl(this.BaseUrl + "/AssignRoles.aspx");
            //this.btnAssignRole.Click();
        }

        public void ClickOnAdd()
        { 
            this.btnAdd.Submit();
            this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_lblPopupUpdateUserHeader"), 50);

        }
        internal void AssignRole(CreateUser firstUser, CreateUser secondUser, CreateUser thirdUser)
        {
            var baseTable = this.CurrentDriver.FindElement(By.XPath("//*[@id=\"ProfileMasterContentHolder_divrepeaterAssignRole\"]/table"),50);
            if(baseTable != null)
            {
                //var baseTable = element.FindElement(By.TagName("table"));
                var tableBody = baseTable.FindElement(By.TagName("tbody"));
                var tableRows = tableBody.FindElements(By.TagName("tr"));
                foreach(var row in tableRows)
                {
                    var columns = row.FindElements(By.TagName("td"));

                    var firstElement = columns[0];

                    if(firstElement.Text == firstUser.BusinessUnit)
                    {
                        var fourthElement = columns[4];

                        //fourthElement.Click();
                        Actions action = new Actions(this.CurrentDriver);
                        action.MoveToElement(fourthElement.FindElement(By.TagName("input"))).Click().Build().Perform();
                        
                        var assingPopup = this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_lblPopupAssignRole"), 50);
                        if (assingPopup.Text == "Assign Roles")
                        {
                            this.BCEmail.SendKeys(firstUser.Email);
                            this.IA1Email.SendKeys(secondUser.Email);
                            this.IA2Email.SendKeys(thirdUser.Email);
                            this.btnAssignUserRole.Click();

                            Thread.Sleep(5000);
                        }
                    }
                }
            }
        }
        private string GetRandomSeed()
        {
            long ticks = DateTime.Now.Ticks;
            byte[] bytes = BitConverter.GetBytes(ticks);
            string rand = Convert.ToBase64String(bytes)
                                    .Replace('+', '_')
                                    .Replace('/', '-')
                                    .TrimEnd('=');
            return rand;
        }
        public void AddUser(string popupTitle, CreateUser user)
        {
            //Check opening of the popup.
            if (this.PopupAddUserHeader.Text == popupTitle)
            {
                var randomSeed = this.GetRandomSeed();
                var firstName = user.FirstName + randomSeed;
                var email = $"{user.Email.Substring(0, user.Email.IndexOf('@') - 1)}{randomSeed}{user.Email.Substring(user.Email.IndexOf('@'))}";
                user.FirstName = firstName;
                user.Email = email;
                this.txtFirstName.SendKeys(user.FirstName);
                this.txtLastName.SendKeys(user.LastName);
                this.txtEmpCode.SendKeys(user.EmpCode);

                this.txtEmail.SendKeys(email);
                this.txtDesignation.SendKeys(user.Designation);

                var ebu = new SelectElement(this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_ddlBusinessUnit"), 50));
                ebu.SelectByText(user.BusinessUnit);
                Thread.Sleep(4000);
                var elc = this.CurrentDriver.FindSelectElementWhenPopulated(By.Id("ProfileMasterContentHolder_ddlCountry"), 50);
                elc.SelectByText(user.Country);
                this.WaitForReady();
                var edl = this.CurrentDriver.FindSelectElementWhenPopulated(By.Id("ProfileMasterContentHolder_ddlLocation"), 50);
                edl.SelectByIndex(2);
                Thread.Sleep(4000);
                var eld = new SelectElement(this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_ddlDepartment"), 50));
                eld.SelectByText(user.Department);
                Thread.Sleep(4000);
                var edc = new SelectElement(this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_ddlCompany"), 50));
                edc.SelectByText(user.Company);
                Thread.Sleep(4000);

                if (user.Gender)
                    this.rdMale.Click();
                else
                    this.rdFemale.Click();
                this.SetBirthdate(user.BirthDate);
                
                this.btnSubmit.Click();

                this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_btnYes"), 50).Click();
                this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_btnClose"), 50).Click(); 

               
            }
        }
       
        internal void AddCategory(string p6)
        {
            this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_imgbtnAddCategory"), 50).Click();
            var popCategoryHeader = this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_lblPopupUpdateCategoryHeader"), 50);
            if (popCategoryHeader.Text == "Add Category")
            {
                var randomSeed = this.GetRandomSeed();
                var splitCategory = p6.Split(',');
                this.txtCategoryName.SendKeys(splitCategory[0] + randomSeed);
                this.txtColorCode.SendKeys(splitCategory[1]);

                IAllowsFileDetection allowsDetection = (IAllowsFileDetection)this.CurrentDriver;
                allowsDetection.FileDetector = new LocalFileDetector();

                this.fileUploader.SendKeys(splitCategory[2]);

                this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_btnUpdateCategorySubmit")).Click();
                this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_btnClose"), 50).Click();
            }
        }
        internal void AddLocation(string p6)
        {
            this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_imgbtnAddSingleLocation"), 50).Click();
            var popLocationHeader = this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_lblPopupUpdateLocationHeader"), 50);
            if (popLocationHeader.Text == "Add Location")
            {
                var randomSeed = this.GetRandomSeed();
                var splitLocation = p6.Split(',');
                SelectElement element = new SelectElement(this.ddlCountry);
                element.SelectByText(splitLocation[0]);
                this.txtLocationName.SendKeys(splitLocation[1] + randomSeed);
                this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_btnUpdateLocationSubmit")).Click();
                this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_btnYes"), 50).Click();
                this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_btnClose"), 50).Click();
            }
        }
        internal void AddDepartment(string p6)
        {
            this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_imgbtnAddSingleDepartment"), 50).Submit();
            var popDepartmentHeader = this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_lblPopupUpdateDepartmentHeader"), 50);
            if (popDepartmentHeader.Text == "Add Department")
            {
                var randomSeed = this.GetRandomSeed();
                this.txtDepartmentName.SendKeys(p6 + randomSeed);
                this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_btnUpdateDepartmentSubmit")).Click();
                this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_btnYes"), 50).Click();
                this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_btnClose"), 50).Click();
            }
        }
        private void SetBirthdate(DateTime birthDate)
        {
            ((IJavaScriptExecutor)this.CurrentDriver).ExecuteScript(
               "document.getElementById('ProfileMasterContentHolder_txtBirthDate').removeAttribute('readonly','readonly');");
            this.txtBirthDate.SendKeys(birthDate.ToString("dd-mm-yyyy"));
        }
    }
}

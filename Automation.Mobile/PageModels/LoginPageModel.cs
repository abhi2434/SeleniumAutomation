using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Mobile.PageModels
{
    public class LoginPage :PageObjectBase
    {
        [FindsBy(How = How.Id, Using = "employeeId")]
        public IWebElement txtEmployeeId { get; set; }

        [FindsBy(How = How.Id, Using = "firstName")]
        public IWebElement txtFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "lastName")]
        public IWebElement txtLastName { get; set; }

        [FindsBy(How = How.Id, Using = "btnRegistration")]
        public IWebElement btnLogin { get; set; }

        [FindsBy(How = How.Id, Using = "toaster")]
        public IWebElement toaster { get; set; }



        public LoginPage(AppiumDriver<IWebElement> driver, ExtentTest test)
            :base(driver, test)
        {

        }
        private void SetEmployeeId(string accountNumber)
        {
            this.TestInfo("Using Employee Id :" + accountNumber);
            this.txtEmployeeId.SendKeys(accountNumber);
        }
        private void SetFirstName(string firstName)
        {
            this.TestInfo("Using First Name :" + firstName);
            this.txtFirstName.SendKeys(firstName);
        }

        private void SetLastName(string lastName)
        {
            this.TestInfo("Using Last Name :" + lastName);
            this.txtLastName.SendKeys(lastName);
        }

        private void ClickLogin()
        {
            this.TestInfo("Clicking on Login");
            btnLogin.Click();
        }

        public string GetToasterMessage()
        {
            var toaster = this.WaitForReady("toaster");
            var element = toaster.FindElement(By.XPath("[@index='3']"));
            return element.Text;
        }

        public void WaitForLoginPage()
        {
            this.WaitForReady("logo_image1");
        }
        public void InvalidLogin(string employeeid, string firstName, string lastName, string errorMessage)
        {
            this.WaitForLoginPage();
            this.SetEmployeeId(employeeid);
            this.SetFirstName(firstName);
            this.SetLastName(lastName); ;
            this.ClickLogin();

            var toasterMessage = this.GetToasterMessage();

            Assert.AreEqual(errorMessage, toasterMessage);
        }

        public void ActivateLogin(string employeeid, string firstname, string lastname, string verificationKey)
        {
            this.WaitForLoginPage();
            this.SetEmployeeId(employeeid);
            this.SetFirstName(firstname);
            this.SetLastName(lastname); ;
            this.ClickLogin();

            var element = this.WaitForReady("code");
            var txtVerify = this.CurrentDriver.FindElement(By.Id("code"));

            txtVerify.SendKeys(verificationKey);
            var verifyButton = this.CurrentDriver.FindElement(By.Id("verifyCode"));
            verifyButton.Click();

           
            this.WaitForReady("open-button");

        }

        public void ResendCodeLogin(string employeeid, string firstname, string lastname, string verificationKey)
        {
            this.WaitForLoginPage();
            this.SetEmployeeId(employeeid);
            this.SetFirstName(firstname);
            this.SetLastName(lastname); ;
            this.ClickLogin();

            var element = this.WaitForReady("code");
            var btnResendCode = this.CurrentDriver.FindElement(By.Id("resendCode"));
            btnResendCode.Click();

        }

        public void Logout()
        {
            this.WaitForInvisibility(By.Id("gifload"));
            var openButton = this.WaitForClick("open-button");
            openButton.Click();
            this.WaitForReady(By.Id("NotificationsScreenLink"));
            
            var logOutLink = this.CurrentDriver.FindElement(By.Id("logoutScreenLink"));
            logOutLink.Click();

            var view = this.WaitForReady("logout_yes");
            view.Click();

            this.WaitForLoginPage();
        }
    }
}

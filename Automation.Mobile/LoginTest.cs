using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using Automation.Mobile.Common;
using OpenQA.Selenium.Support.UI;
using Automation.Mobile.PageModels;

namespace Automation.Mobile
{
    [TestClass]
    public class LoginTest: MobileBase
    {

        LoginPage loginModel = null;

        [TestCategory("Mobile")]
        [TestMethod]
        public void Automation_Mobile_Login()
        {
            loginModel = new LoginPage(this.CurrentDriver, this.CurrentTest);
            var models = this.GetCurrentData();
            if (models.Count > 0)
            {
                var firstRow = models[0];
                loginModel.ActivateLogin(firstRow.P1, firstRow.P2, firstRow.P3, firstRow.P4);


            }
            
        }

        [TestCategory("Mobile")]
        [TestMethod]
        public void Automation_Mobile_Logout()
        {
            loginModel = new LoginPage(this.CurrentDriver, this.CurrentTest);
            var models = this.GetCurrentData();
            if (models.Count > 0)
            {
                var firstRow = models[0];
                loginModel.ActivateLogin(firstRow.P1, firstRow.P2, firstRow.P3, firstRow.P4);

                loginModel.Logout();
            }

        }

        [TestCategory("Mobile")]
        [TestMethod]
        public void Automation_Mobile_Login_Invalid()
        {
            loginModel = new LoginPage(this.CurrentDriver, this.CurrentTest);
            var models = this.GetCurrentData();
            if (models.Count > 0)
            {
                var firstRow = models[0];
                loginModel.InvalidLogin(firstRow.P1, firstRow.P2, firstRow.P3, firstRow.P4);


            }

        }
        [TestCategory("Mobile")]
        [TestMethod]
        public void Automation_Mobile_Resend_Login()
        {
            loginModel = new LoginPage(this.CurrentDriver, this.CurrentTest);
            var models = this.GetCurrentData();
            if (models.Count > 0)
            {
                var firstRow = models[0];
                loginModel.ResendCodeLogin(firstRow.P1, firstRow.P2, firstRow.P3, firstRow.P4);
            }

        }
    }
}

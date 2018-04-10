using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Automation.AutoTests.Common;
using System.Threading.Tasks;
using System.Threading;

namespace Automation.AutoTests.PageModels
{
    public class LoginPage : PageObjectBase
    {
        [FindsBy(How = How.Id, Using = "txtUserName")]
        public IWebElement txtUserID { get; set; }

        [FindsBy(How = How.Id, Using = "txtPassword")]
        public IWebElement txtPasswd { get; set; }

        [FindsBy(How = How.Id, Using = "h3LoginTitle")]
        public IWebElement lblLoginTitle { get; set; }

        [FindsBy(How = How.Id, Using = "btnLogin")]
        public IWebElement btnLogin { get; set; }

        [FindsBy(How = How.Id, Using = "lblErrorMsg")]
        public IWebElement lblInvalidLogin { get; set; }

        

        public LoginPage(IWebDriver driver, ExtentTest test)
            :base(driver, test)
        {
          
        }

        private void SetUserName(string username)
        {
            this.TestInfo("Using userName :" + username);
            txtUserID.SendKeys(username);
        }

        private void SetPassword(string password)
        {
            this.TestInfo("Using password :" + password);
            txtPasswd.SendKeys(password);
        }

        private void ClickLogin()
        {
            this.TestInfo("Clicking on Login");
            btnLogin.Click();
        }

        public void CheckForHome()
        {
            this.CurrentDriver.FindElement(By.Id("btnShareIdea"), 50);
        }
        public void CheckForError()
        {
            this.CurrentDriver.FindElement(By.Id("lblErrorMsg"), 50);
        }
        public string GetLoginTitle()
        {
            this.TestInfo("Checking login title");
            return lblLoginTitle.Text;
        }

        public string GetInvalidLoginTitle()
        {
            this.TestInfo("Checking login title");
            this.CurrentDriver.FindElement(By.Id("lblErrorMsg"), 10);
            return lblInvalidLogin.Text;
        }

        public void LoginToHome(string strUserName, string strPasword)
        {
            this.SetUserName(strUserName);
            this.SetPassword(strPasword);
            this.ClickLogin();
        }
    }
}

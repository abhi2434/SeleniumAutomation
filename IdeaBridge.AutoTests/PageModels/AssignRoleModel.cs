using AventStack.ExtentReports;
using Automation.AutoTests.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation.AutoTests.PageModels
{
    public class AssignRoleModel : PageObjectBase
    {

        public AssignRoleModel(IWebDriver driver, ExtentTest test)
            :base(driver, test)
        {

        }
        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_txtBusinessCoordinator")]
        public IWebElement BCEmail { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_txtIdeaApproverL1")]
        public IWebElement IA1Email { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_txtIdeaApproverL2")]
        public IWebElement IA2Email { get; set; }

        [FindsBy(How = How.Id, Using = "ProfileMasterContentHolder_btnAssignRoleSubmit")]
        public IWebElement btnAssignUserRole { get; set; }
        public bool ValidateRolePage(string validateText)
        {
            var property = this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_updtpnlAssignRole"), 50);

            var header = property.FindElement(By.TagName("h1"));
            return header.Text.Equals(validateText);
        }
        internal void AssignRole(string businessunit, string firstEmail, string secondEmail, string thirdEmail)
        {
            var baseTable = this.CurrentDriver.FindElement(By.XPath("//*[@id=\"ProfileMasterContentHolder_divrepeaterAssignRole\"]/table"), 50);
            if (baseTable != null)
            {
                //var baseTable = element.FindElement(By.TagName("table"));
                var tableBody = baseTable.FindElement(By.TagName("tbody"));
                var tableRows = tableBody.FindElements(By.TagName("tr"));
                foreach (var row in tableRows)
                {
                    var columns = row.FindElements(By.TagName("td"));

                    var firstElement = columns[0];

                    if (firstElement.Text == businessunit)
                    {
                        var fourthElement = columns[4];

                        //fourthElement.Click();
                        Actions action = new Actions(this.CurrentDriver);
                        action.MoveToElement(fourthElement.FindElement(By.TagName("input"))).Click().Build().Perform();

                        var assingPopup = this.CurrentDriver.FindElement(By.Id("ProfileMasterContentHolder_lblPopupAssignRole"), 50);
                        if (assingPopup.Text == "Assign Roles")
                        {
                            this.BCEmail.Clear();
                            this.BCEmail.SendKeys(firstEmail);

                            this.IA1Email.Clear();
                            this.IA1Email.SendKeys(secondEmail);

                            this.IA2Email.Clear();
                            this.IA2Email.SendKeys(thirdEmail);
                            this.btnAssignUserRole.Click();

                            Thread.Sleep(5000);

                            break;
                        }
                    }
                }
                this.WaitForReady(); 
            }
        }
    }
}

using AventStack.ExtentReports;
using OpenQA.Selenium;
using Automation.AutoTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.AutoTests.PageModels
{
    public class IdeaApprover : PageObjectBase
    {
        public IdeaApprover(IWebDriver driver, ExtentTest test)
            :base(driver, test)
        {

        }

        #region Properties




        #endregion

        #region Methods 

        public bool CheckForIdeaRedirect()
        {
            string message = "Thank you for using Maadhyam Portal and submitting the idea. Your idea is sent back to Admin for redirecting the Business.";
             
            var rows = this.CurrentDriver.FindElements(By.XPath("//*[@id='ProfileMasterContentHolder_divrepeaternotification']/table/tbody/tr"));
            var fifthColumn = rows[0].FindElement(By.XPath("//td[4]"));
            return fifthColumn.Text == message; 
  
        }
        public void ApproveIdeas()
        {
            var rows = this.CurrentDriver.FindElements(By.XPath("//*[@id='ProfileMasterContentHolder_divrepeaternotification']/table/tbody/tr"));

            foreach (var rowElement in rows)
            {
                var ideaColumn = rowElement.FindElement(By.XPath("//*[@id='ProfileMasterContentHolder_RepeaterNotification_lnkbtnTitle_0']"));
                ideaColumn.Click();
                break;
            }
        }
        public bool CheckforApproveIdeaPage()
        {
            var element = this.CurrentDriver.FindElement(By.Id("MenuMasterContentHolder_lblIdeaStatusTag"), 50);
            return element != null;
        }
        #endregion
    }
}

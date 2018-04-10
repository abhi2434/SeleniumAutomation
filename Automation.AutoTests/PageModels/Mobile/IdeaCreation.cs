using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.AutoTests.PageModels.Mobile
{
    public class IdeaCreation
    {
        public IWebDriver Driver { get; private set; }
        WebDriverWait wait;
        public IdeaCreation(IWebDriver driver)
        {
            this.Driver = driver;
            wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(20));
        }
        public void SignIn(string platform, string userid, string password)
        {

            Driver.FindElement(By.XPath("//android.widget.EditText[@index='0']")).SendKeys(platform);
            Driver.FindElement(By.XPath("//android.widget.EditText[@index='1']")).SendKeys(userid);
            Driver.FindElement(By.XPath("//android.widget.EditText[@index='2']")).SendKeys(password);

            //Click Signin Button                                                                                               
            Driver.FindElement(By.XPath("//android.widget.Button[@text='Sign in']")).Click();

            //landed on home page
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//android.widget.TextView[@text='My Ideas']")));
        }
        public void CreateIdea(string platform, string userid, string password, string title, string description)
        {
            this.SignIn(platform, userid, password);

            this.Driver.FindElement(By.XPath("//android.widget.ImageButton[@index='3']")).Click();

            //submit idea
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//android.widget.TextView[@text='Submit Idea']")));
            this.Driver.FindElement(By.XPath("//android.widget.EditText[@text='Title']")).SendKeys(title);
            this.Driver.FindElement(By.XPath("//android.widget.EditText[@text='Description']")).SendKeys(description);
            this.Driver.FindElement(By.XPath("//android.widget.TextView[@text='Select Idea Category']")).Click();

            ReadOnlyCollection<IWebElement> list = this.Driver.FindElements(By.XPath("//android.widget.CheckedTextView"));
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Text == "Productivity")
                {
                    list[i].Click();
                    break;
                }
            }

            this.Driver.FindElement(By.XPath("//android.widget.Button[@text='Submit']")).Click();

            //click Yes on pop-up
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//android.widget.Button[@text='YES']")));
            this.Driver.FindElement(By.XPath("//android.widget.Button[@text='YES']")).Click();
            Assert.AreEqual(title, this.Driver.FindElement(By.XPath("//android.support.v7.widget.RecyclerView/android.widget.RelativeLayout/android.widget.FrameLayout[1]/android.widget.LinearLayout/android.widget.TextView[@index='0']")).Text);
        }
    }
}

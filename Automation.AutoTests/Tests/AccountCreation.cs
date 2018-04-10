using Automation.AutoTests.Common;
using Automation.AutoTests.PageModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.AutoTests.Tests
{
    [TestClass]
    public class AccountCreation : TestBase
    {
        public HomePage Home { get; private set; }
        public LoginPage Login { get; private set; }

        public UserManagementPage UserManagement { get; private set; }

        [TestCategory("Success")]
        [TestMethod]
        public void Check_Category_Creation_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    this.Login = new LoginPage(this.Driver, this.CurrentTest);

                    //Verify login page title
                    string loginPageTitle = this.Login.GetLoginTitle();
                    var p1 = firstRow.P1;
                    var p2 = firstRow.P2;

                    var p3 = firstRow.P3;
                    Assert.AreEqual(p3, loginPageTitle.ToLower());

                    //login to application
                    this.Login.LoginToHome(p1, p2);

                    this.Login.CheckForHome();

                    // go the next page
                    Home = new HomePage(this.Driver, this.CurrentTest);

                    var classData = Home.ChangeToAdmin(firstRow.P5);
                    Assert.AreEqual(firstRow.P6, classData);

                    UserManagement = new UserManagementPage(this.Driver, this.CurrentTest);
                    UserManagement.ClickCategory();

                    UserManagement.AddCategory(firstRow.P7);
                    this.TestPassed("Test passed");
                }
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                throw;
            }
        }

        [TestCategory("Success")]
        [TestMethod]
        public void Check_Location_Creation_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    this.Login = new LoginPage(this.Driver, this.CurrentTest);

                    //Verify login page title
                    string loginPageTitle = this.Login.GetLoginTitle();
                    var p1 = firstRow.P1;
                    var p2 = firstRow.P2;

                    var p3 = firstRow.P3;
                    Assert.AreEqual(p3, loginPageTitle.ToLower());

                    //login to application
                    this.Login.LoginToHome(p1, p2);

                    this.Login.CheckForHome();

                    // go the next page
                    Home = new HomePage(this.Driver, this.CurrentTest);

                    var classData = Home.ChangeToAdmin(firstRow.P5);
                    Assert.AreEqual(firstRow.P6, classData);

                    UserManagement = new UserManagementPage(this.Driver, this.CurrentTest);
                    UserManagement.ClickLocation();

                    UserManagement.AddLocation(firstRow.P7);
                    this.TestPassed("Test passed");
                }
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                throw;
            }
        }
        [TestCategory("Success")]
        [TestMethod]
        public void Check_Department_Creation_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    this.Login = new LoginPage(this.Driver, this.CurrentTest);

                    //Verify login page title
                    string loginPageTitle = this.Login.GetLoginTitle();
                    var p1 = firstRow.P1;
                    var p2 = firstRow.P2;

                    var p3 = firstRow.P3;
                    Assert.AreEqual(p3, loginPageTitle.ToLower());

                    //login to application
                    this.Login.LoginToHome(p1, p2);

                    this.Login.CheckForHome();

                    // go the next page
                    Home = new HomePage(this.Driver, this.CurrentTest);

                    var classData = Home.ChangeToAdmin(firstRow.P5);
                    Assert.AreEqual(firstRow.P6, classData);

                    UserManagement = new UserManagementPage(this.Driver, this.CurrentTest);
                    UserManagement.ClickDepartment();

                    UserManagement.AddDepartment(firstRow.P7);
                    this.TestPassed("Test passed");
                }
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                throw;
            }
        }
        [TestCategory("Success")]
        [TestMethod]
        public void Check_Account_Creation_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    this.Login = new LoginPage(this.Driver, this.CurrentTest);

                    //Verify login page title
                    string loginPageTitle = this.Login.GetLoginTitle();
                    var p1 = firstRow.P1;
                    var p2 = firstRow.P2;

                    var p3 = firstRow.P3;
                    Assert.AreEqual(p3, loginPageTitle.ToLower());

                    //login to application
                    this.Login.LoginToHome(p1, p2);

                    this.Login.CheckForHome();

                    // go the next page
                    Home = new HomePage(this.Driver, this.CurrentTest);

                    var classData = Home.ChangeToAdmin(firstRow.P5);
                    //Assert.AreEqual(firstRow.P6, classData);

                    UserManagement = new UserManagementPage(this.Driver, this.CurrentTest);
                    UserManagement.ClickOnUserManagementAgain();
                    UserManagement.ValidateUserPage(firstRow.P7);
                    

                    var firstUser = new CreateUser(firstRow.P9, firstRow.P13);
                    UserManagement.ClickOnAdd();
                    UserManagement.AddUser(firstRow.P8, firstUser);
                    UserManagement.ClickOnUserManagementAgain();
                    UserManagement.ValidateUserPage(firstRow.P7);
                    UserManagement.ClickOnAdd();
                    var secondUser = new CreateUser(firstRow.P10, firstRow.P13);
                    UserManagement.AddUser(firstRow.P8, secondUser);
                    UserManagement.ClickOnUserManagementAgain();
                    UserManagement.ValidateUserPage(firstRow.P7);
                    UserManagement.ClickOnAdd();
                    var thirdUser = new CreateUser(firstRow.P11, firstRow.P13);
                    UserManagement.AddUser(firstRow.P8, thirdUser);
                    this.TestPassed("Test passed");
                }
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                throw;
            }
        }

        [TestCategory("Success")]
        [TestMethod]
        public void Check_Assign_Role_Correct()
        {
            try
            {
                var models = this.GetCurrentData();
                if (models.Count > 0)
                {
                    var firstRow = models[0];
                    this.Login = new LoginPage(this.Driver, this.CurrentTest);

                    //Verify login page title
                    string loginPageTitle = this.Login.GetLoginTitle();
                    var p1 = firstRow.P1;
                    var p2 = firstRow.P2;

                    var p3 = firstRow.P3;
                    Assert.AreEqual(p3, loginPageTitle.ToLower());

                    //login to application
                    this.Login.LoginToHome(p1, p2);

                    this.Login.CheckForHome();

                    // go the next page
                    Home = new HomePage(this.Driver, this.CurrentTest);

                    var classData = Home.ChangeToAdmin(firstRow.P5);
                    //Assert.AreEqual(firstRow.P6, classData);

                    UserManagement = new UserManagementPage(this.Driver, this.CurrentTest);
                    UserManagement.ClickOnUserManagementAgain();
                    UserManagement.ValidateUserPage(firstRow.P7); 
                    UserManagement.ClickAssignRole();
                    UserManagement = new UserManagementPage(this.Driver, this.CurrentTest);
                    UserManagement.ValidateRolePage(firstRow.P8);
                    var assignRole = new AssignRoleModel(this.Driver, this.CurrentTest);

                    assignRole.ValidateRolePage(firstRow.P9);
                    assignRole.AssignRole(firstRow.P10, firstRow.P11, firstRow.P12, firstRow.P13);

                    Home.GetUserLoggedOut();
                    this.TestPassed("Test passed");
                }
            }
            catch (Exception ex)
            {
                this.LogException(ex);
                throw;
            }
        }
    }
}

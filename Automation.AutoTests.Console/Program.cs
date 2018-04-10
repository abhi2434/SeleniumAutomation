using Automation.API.Tests;
using Automation.API.Tests.Common;
using Automation.AutoTests.Common;
using Automation.AutoTests.Tests;
using System;

namespace Automation.AutoTests.Console
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            

            var selection = ShowMainMenu();
            switch (selection)
            {
                case 1:
                    ShowWebMenu();
                    break;
                case 2:
                    RunAPITests();
                    break;
                case 3:
                    break;
                default:
                    System.Console.WriteLine("Invalid input! bye.");
                    break;
            }

            System.Console.WriteLine("Ok, We are done.... Bye bye");
            System.Console.ReadLine();
        }
        private static void RunAPITests()
        {
            var reportingManager = new APIReportingManager("index" + DateTime.Now.ToFileTime(), "extentReport.config");
            RunUnitTestsClass<CategoryTest>.RunTests(reportingManager);
            RunUnitTestsClass<ContentTest>.RunTests(reportingManager);
            RunUnitTestsClass<DepartmentTest>.RunTests(reportingManager);
            RunUnitTestsClass<IdeaTest>.RunTests(reportingManager);
        }
        private static void RunAllTests(WebReportingManager reportingManager)
        {
            RunUnitTestsClass<LoginTest>.RunTests(reportingManager);
            RunUnitTestsClass<AccountCreation>.RunTests(reportingManager);
            RunUnitTestsClass<HomeTest>.RunTests(reportingManager);
            RunUnitTestsClass<ViewIdeasTest>.RunTests(reportingManager);
            RunUnitTestsClass<SubmitIdeasTest>.RunTests(reportingManager);
            RunUnitTestsClass<ApproveIdeaTest>.RunTests(reportingManager);
}
        private static void RunByCategoryname(WebReportingManager reportingManager, string name)
        {
            RunUnitTestsClass<LoginTest>.RunTestByCategory(reportingManager, name);
            RunUnitTestsClass<HomeTest>.RunTestByCategory(reportingManager, name);
            RunUnitTestsClass<ViewIdeasTest>.RunTestByCategory(reportingManager, name);
            RunUnitTestsClass<SubmitIdeasTest>.RunTestByCategory(reportingManager, name);
            RunUnitTestsClass<ApproveIdeaTest>.RunTestByCategory(reportingManager, name);
        }

        private static void RunByPagename(WebReportingManager reportingManager, string page)
        {
            switch (page.ToLower())
            {
                case "login":
                    RunUnitTestsClass<LoginTest>.RunTests(reportingManager);
                    break;
                case "account":
                    RunUnitTestsClass<AccountCreation>.RunTests(reportingManager);
                    break;
                case "home":
                    RunUnitTestsClass<HomeTest>.RunTests(reportingManager);
                    break;
                case "viewideas":
                    RunUnitTestsClass<ViewIdeasTest>.RunTests(reportingManager);
                    break;
                case "submitideas":
                    RunUnitTestsClass<SubmitIdeasTest>.RunTests(reportingManager);
                    break;
                case "approveideas":
                    RunUnitTestsClass<ApproveIdeaTest>.RunTests(reportingManager);
                    break;
            }
        }

        private static void RunByFunctionname(WebReportingManager reportingManager, string name)
        {
            RunUnitTestsClass<LoginTest>.RunTest(reportingManager, name);
            RunUnitTestsClass<AccountCreation>.RunTest(reportingManager, name);
            RunUnitTestsClass<HomeTest>.RunTest(reportingManager, name);
            RunUnitTestsClass<ViewIdeasTest>.RunTest(reportingManager, name);
            RunUnitTestsClass<SubmitIdeasTest>.RunTest(reportingManager, name);
            RunUnitTestsClass<ApproveIdeaTest>.RunTest(reportingManager, name);
        }
        private static void ShowWebMenu()
        {
            var reportingManager = new WebReportingManager("index" + DateTime.Now.ToFileTime());
            var selection = ShowMenu();

            switch (selection)
            {
                case 1:
                    RunAllTests(reportingManager);
                    break;
                case 2:
                    System.Console.WriteLine("Ok, Enter the page name");
                    var page = System.Console.ReadLine();
                    RunByPagename(reportingManager, page);
                    break;
                case 3:
                    System.Console.WriteLine("Ok, Enter the category name");
                    var name = System.Console.ReadLine();
                    RunByCategoryname(reportingManager, name);
                    break;

                case 4:
                    System.Console.WriteLine("Ok, Enter the function name");
                    var function = System.Console.ReadLine();
                    RunByFunctionname(reportingManager, function);
                    break;
                default:
                    System.Console.WriteLine("Invalid input! bye.");
                    break;
            }
        }
        private static int ShowMenu()
        {
            System.Console.WriteLine("Web Menu");
            System.Console.WriteLine("---------------------------------------------------------");
            System.Console.WriteLine("1. Run all tests."); 
            System.Console.WriteLine("2. Run test by page.");
            System.Console.WriteLine("3. Run test by category.");
            System.Console.WriteLine("4. Run test by function.");
            System.Console.WriteLine("----------------------------------------------------------");
            System.Console.WriteLine("Enter your input: ");

            return Convert.ToInt32(System.Console.ReadLine());


        }

        private static int ShowMainMenu()
        {
            System.Console.WriteLine("Menu");
            System.Console.WriteLine("---------------------------------------------------------");
            System.Console.WriteLine("1. Web.");
            System.Console.WriteLine("2. API.");
            System.Console.WriteLine("3. Mobile.");
            System.Console.WriteLine("----------------------------------------------------------");
            System.Console.WriteLine("Enter your input: ");

            return Convert.ToInt32(System.Console.ReadLine());


        }
    }
}

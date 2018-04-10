using Automation.API.Tests.Common;
using Automation.AutoTests.Common;
using Automation.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Automation.AutoTests.Console
{
    public static class RunUnitTestsClass<TUnitTests> where TUnitTests : ISupportReporting, new()
    {
        private static IEnumerable<MethodInfo> WithMethodAttribute<TAttribute>()
        {
            return typeof(TUnitTests).GetMethods()
                .Where(method => method.GetCustomAttributes(typeof(TAttribute), true).Any());
        }
       
        private static void RunWithAttribute<TAttribute>(TUnitTests unitTests)
        {
            foreach (var method in WithMethodAttribute<TAttribute>())
                method.Invoke(unitTests, new object[0]);
        }

        public static void RunTestInitializeSetup(TUnitTests unitTests)
        {
            RunWithAttribute<TestInitializeAttribute>(unitTests);
        }

        public static void RunTestFinalizeSetup(TUnitTests unitTests)
        {
            RunWithAttribute<TestCleanupAttribute>(unitTests);
        }

        public static void RunTestByCategory(IReportingManager manager, string categoryName)
        {
            try
            {
                TUnitTests unitTests = new TUnitTests();
                unitTests.SetReport(manager);

                foreach (var method in WithMethodAttribute<TestMethodAttribute>())
                {
                    var category = method.GetCustomAttribute<TestCategoryAttribute>();
                    if (category != null && category.TestCategories.Any(e => e.Equals(categoryName, StringComparison.InvariantCultureIgnoreCase)))
                    {

                        try
                        {
                            RunTestInitializeSetup(unitTests);

                            method.Invoke(unitTests, null);
                        }
                        catch (Exception ex)
                        {
                            System.Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            RunTestFinalizeSetup(unitTests);
                            manager.FlushTest();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
         

        public static void RunTests(IReportingManager manager)
        {
            try
            {
                TUnitTests unitTests = new TUnitTests();
                unitTests.SetReport(manager);

                foreach (var method in WithMethodAttribute<TestMethodAttribute>())
                {
                    try
                    {
                        RunTestInitializeSetup(unitTests);

                        method.Invoke(unitTests, null);

                        System.Console.WriteLine($"Executed : {method.Name}");
                    }
                    catch(Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        RunTestFinalizeSetup(unitTests);
                        manager.FlushTest();
                    }
                } 
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

        public static void RunTest(IReportingManager manager,  string methodname)
        {
            try
            {
                TUnitTests testClass = new TUnitTests();
                testClass.SetReport(manager);

                var method = testClass.GetType().GetMethod(methodname);
                if(method != null) 
                {
                    try
                    {
                        RunTestInitializeSetup(testClass);

                        method.Invoke(testClass, null);
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        RunTestFinalizeSetup(testClass);
                        manager.FlushTest();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

    }
}

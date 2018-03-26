using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Common
{
    public interface IReportingManager
    {
        ExtentTest CreateTest(string testName, List<string> categories);
        void FlushTest();
    }
}

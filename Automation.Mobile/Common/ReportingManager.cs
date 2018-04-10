using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Mobile.Common
{
    public class ReportingManager
    {
        public ReportingManager(string fileName)
        {
            this.Settings = MobileSettings.Default;
            this.Report = new ExtentReports();
            this.CreateReport(fileName);

        }
        internal MobileSettings Settings { get; set; }

        internal ExtentReports Report { get; set; }

        private void CreateReport(string fileName)
        {
            var htmlReporter = new ExtentHtmlReporter(Path.Combine(this.Settings.FolderUrl, "Report", fileName + ".html"));
            this.AddSystemInformation(this.Report);
            this.Report.AttachReporter(htmlReporter);
        }

        private void AddSystemInformation(ExtentReports report)
        {
            try
            {
                report.AddSystemInfo("Package Name", this.Settings.PackageName);


                report.AddSystemInfo("Operation System", Environment.OSVersion.ToString());

                var bit = "32 Bit (x86) Operating System";
                report.AddSystemInfo("Operation System", Environment.OSVersion.ToString());
                if (Environment.Is64BitOperatingSystem)
                    bit = "64 Bit Operating System";
                report.AddSystemInfo("Type", bit);
                report.AddSystemInfo("SystemDirectory", Environment.SystemDirectory);
                report.AddSystemInfo("ProcessorCount", Environment.ProcessorCount.ToString());
                report.AddSystemInfo("UserDomainName", Environment.UserDomainName);
                report.AddSystemInfo("UserName", Environment.UserName);


                foreach (DriveInfo DriveInfo1 in DriveInfo.GetDrives())
                {


                    try
                    {
                        report.AddSystemInfo("Logical Drives", string.Format("Drive: {0}, VolumeLabel: {1}, DriveType: {2}, DriveFormat: {3}, Total Size: {4}, Available Size: {5}", DriveInfo1.Name, DriveInfo1.VolumeLabel, DriveInfo1.DriveType,
                          DriveInfo1.DriveFormat, DriveInfo1.TotalSize, DriveInfo1.AvailableFreeSpace));
                    }
                    catch
                    {
                    }
                }
                report.AddSystemInfo("SystemPageSize", Environment.SystemPageSize.ToString());
                report.AddSystemInfo("Version", Environment.Version.ToString());

            }
            catch
            {
            }
        }



        public ExtentTest CreateTest(string testName, List<string> categories)
        {
            var test = this.Report.CreateTest(testName);
            test.AssignAuthor(Environment.UserName);

            test.AssignCategory(categories.ToArray());

            return test;
        }

        public void FlushTest()
        {
            this.Report.Flush();
        }
    }
}

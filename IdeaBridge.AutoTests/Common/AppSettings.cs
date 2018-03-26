using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.AutoTests.Common
{
    public class AppSettings
    {
        private static AppSettings _default;
        public static AppSettings Default
        {
            get
            {
                if (AppSettings._default == null)
                    AppSettings._default = new AppSettings();
                return AppSettings._default;
            }
        }

        public string BaseUrl { get; private set; }
        public string Browser { get; private set; }
        public string DirectoryPath { get; private set; }
        public string DataFile { get; private set; }

        public AppSettings()
        {
            this.BaseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            this.Browser = ConfigurationManager.AppSettings["Browser"];
            this.DirectoryPath = ConfigurationManager.AppSettings["DirectoryPath"];
            this.DataFile = ConfigurationManager.AppSettings["DataFile"];
        } 
    }
}

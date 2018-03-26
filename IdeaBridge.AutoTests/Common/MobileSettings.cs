using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.AutoTests.Common
{
    public class MobileSettings
    {
        public MobileSettings()
        {
            this.App = ConfigurationManager.AppSettings["m.app"];
            this.DeviceName = ConfigurationManager.AppSettings["m.deviceName"];
            this.PlatformName = ConfigurationManager.AppSettings["m.platformName"];
            this.PlatformVersion = ConfigurationManager.AppSettings["m.platformVersion"];
            this.Url = ConfigurationManager.AppSettings["m.url"];
            this.Data = ConfigurationManager.AppSettings["data"]; 
        }

        public string App { get; private set; }
        public string Data { get; private set; }
        public string DeviceName { get; private set; }
        public string PlatformName { get; private set; }
        public string PlatformVersion { get; private set; }
        public string Url { get; private set; }


    }
}

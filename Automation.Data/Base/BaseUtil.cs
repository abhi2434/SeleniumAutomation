using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Data.Base
{
    public class BaseUtil
    {
        public BaseUtil(DatabaseManager manager)
        {
            this.DataBridge = manager;
        }

        public DatabaseManager DataBridge { get; private set; }

        public DatabaseFactory DbFactory
        {
            get
            {
                return this.DataBridge.DbBridge;
            }

        }
    }
}

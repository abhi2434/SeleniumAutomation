using Automation.Data.Base;
using Automation.Data.DataUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Data
{
    public class DatabaseManager
    {
        public DatabaseManager(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        internal string ConnectionString { get; private set; }

        private DatabaseFactory _dbBridge;
        public DatabaseFactory DbBridge
        {
            get
            {
                this._dbBridge = this._dbBridge ?? new DatabaseFactory(this.ConnectionString);
                return this._dbBridge;
            }
        }

        private IdeaUtil _ideas; 
        private IdeaUtil Ideas
        {
            get
            {
                this._ideas = this._ideas ?? new IdeaUtil(this);
                return this._ideas;
            }
        }
    }
}

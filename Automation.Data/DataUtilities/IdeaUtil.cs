using Automation.Data.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Data.DataUtilities
{
    public class IdeaUtil : BaseUtil
    {
        public IdeaUtil(DatabaseManager manager)
            : base(manager)
        {

        }

        public DataTable GetIdeasTable()
        {
            string sql = "Select * from Tags";
            return this.DbFactory.ExecuteTable(sql);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Mobile.Common
{
    public class DataModel
    {
        public DataModel(DataRow row)
        {
            if (row != null)
            {
                this.CaseName = this.GetData(row, "CaseName");
                this.P1 = this.GetData(row, "P1");
                this.P2 = this.GetData(row, "P2");
                this.P3 = this.GetData(row, "P3");
                this.P4 = this.GetData(row, "P4");
                this.P5 = this.GetData(row, "P5");
                this.P6 = this.GetData(row, "P6");
                this.P7 = this.GetData(row, "P7");
                this.P8 = this.GetData(row, "P8");
                this.P9 = this.GetData(row, "P9");
                this.P10 = this.GetData(row, "P10");
                this.P11 = this.GetData(row, "P11");
                this.P12 = this.GetData(row, "P12");
                this.P13 = this.GetData(row, "P13");
                this.P14 = this.GetData(row, "P14");
                this.P15 = this.GetData(row, "P15");
                this.P16 = this.GetData(row, "P16");
                this.P17 = this.GetData(row, "P17");
                this.P18 = this.GetData(row, "P18");
                this.P19 = this.GetData(row, "P19");
                this.P20 = this.GetData(row, "P20");
                this.P21 = this.GetData(row, "P21");
                this.P22 = this.GetData(row, "P22");
                this.P23 = this.GetData(row, "P23");
                this.P24 = this.GetData(row, "P24");
                this.P25 = this.GetData(row, "P25");
                this.P26 = this.GetData(row, "P26");
                this.P27 = this.GetData(row, "P27");
                this.P28 = this.GetData(row, "P28");
                this.P29 = this.GetData(row, "P29");
                this.P30 = this.GetData(row, "P30");
                this.P31 = this.GetData(row, "P31");
                this.P32 = this.GetData(row, "P32");
            }
        }
        public string CaseName { get; set; }

        public string P1 { get; set; }

        public string P2 { get; set; }

        public string P3 { get; set; }

        public string P4 { get; set; }

        public string P5 { get; set; }

        public string P6 { get; set; }

        public string P7 { get; set; }
        public string P8 { get; set; }
        public string P9 { get; set; }
        public string P10 { get; set; }

        public string P11 { get; set; }
        public string P12 { get; set; }
        public string P13 { get; set; }
        public string P14 { get; set; }
        public string P15 { get; set; }
        public string P16 { get; set; }

        public string P17 { get; set; }

        public string P20 { get; set; }

        public string P21 { get; set; }

        public string P22 { get; set; }

        public string P23 { get; set; }

        public string P24 { get; set; }

        public string P25 { get; set; }
        public string P26 { get; set; }
        public string P27 { get; set; }
        public string P28 { get; set; }

        public string P18 { get; set; }
        public string P19 { get; set; }
        public string P29 { get; set; }
        public string P30 { get; set; }
        public string P31 { get; set; }
        public string P32 { get; set; }

        private string GetData(DataRow row, string columnName)
        {
            try
            {
                return row[columnName].ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}

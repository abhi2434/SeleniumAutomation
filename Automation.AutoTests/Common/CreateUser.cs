using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.AutoTests.Common
{
    public class CreateUser
    {
        public CreateUser(string userString, string businessUnit)
        {
            Random rng = new Random();
            var data = userString.Split(',');
            this.FirstName = data[0];
            this.LastName = data[1];
            this.EmpCode = rng.Next(9999).ToString();
            this.Email = data[2];
            this.Gender = Convert.ToBoolean(data[3]);
            this.BirthDate = DateTime.ParseExact(data[4], "dd-mm-yyyy", null);
            this.Designation = data[5];
            this.Department = data[6];
            this.Country = data[7];
            this.BusinessUnit = businessUnit;
            this.Location = data[8];
            this.Company = data[9];
            //string firstName, string lastName, string empCode, string email, bool gender, DateTime birthdate, string desig, string country,
            //string businessunit, string department, string location, string company
        }

        public DateTime BirthDate { get; private set; }
        public string BusinessUnit { get; private set; }
        public string Company { get; private set; }
        public string Country { get; private set; }
        public string Department { get; private set; }
        public string Designation { get; private set; }
        public string Email { get; set; }
        public string EmpCode { get; private set; }
        public string FirstName { get; set; }
        public bool Gender { get; private set; }
        public string LastName { get; private set; }
        public string Location { get; private set; }
    }
}

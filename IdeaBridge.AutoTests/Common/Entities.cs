using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.AutoTests.Common
{
    public enum IdeaCategory
    {
        ApplicantSatisfaction,
        CostReduction,
        EmployeeSatisfaction,
        GreenIdea,
        Others,
        Productivity,
        RevenueGeneration,
        TATReduction,
        TimeSaving,
        CSR,
        Unknown
    }

    public enum IdeaBusiness
    {
        Agro,
        Energy,
        Logistics,
        Resources,
        Finance,
        Gas,
        Unknown
    }

    public enum IdeaCountry
    {
        India,
        Australia,
        Indonesia,
        Unknown
    }

    public enum IdeaState
    {
        Gujarat,
        Queensland,
        Jakarta,
        Unknown
    }

    public enum IdeaCity
    {
        Ahmedabad,
        Brisbane,
        JakartaSelatan,
        Unknown
    }

    public class Idea
    {
        public String IdeaTitle { get; set; }
        public String IdeaDesc { get; set; }
        public String IdeaTeammembers { get; set; }
        public String IdeaTags { get; set; }
        public String ActionPlan { get; set; }
        public String Objective { get; set; }
        public String Benefits { get; set; }
        public IdeaCategory IdeaCategory { get; set; }
        public IdeaBusiness IdeaBusiness { get; set; }
        public IdeaCountry IdeaCountry { get; set; }
        public IdeaState IdeaState { get; set; }
        public IdeaCity IdeaCity { get; set; }
        public bool AssistanceRequired { get; set; }

        public static String IdeaCategoryString(IdeaCategory category)
        {
            String returnValue = "";
            switch (category)
            {
                case IdeaCategory.ApplicantSatisfaction:
                    returnValue = "Applicant satisfaction";
                    break;

                case IdeaCategory.CostReduction:
                    returnValue = "Cost reduction";
                    break;

                case IdeaCategory.EmployeeSatisfaction:
                    returnValue = "Employee satisfaction";
                    break;

                case IdeaCategory.GreenIdea:
                    returnValue = "Green idea";
                    break;

                case IdeaCategory.Others:
                    returnValue = "Others";
                    break;

                case IdeaCategory.Productivity:
                    returnValue = "Productivity";
                    break;

                case IdeaCategory.RevenueGeneration:
                    returnValue = "Revenue generation";
                    break;

                case IdeaCategory.TATReduction:
                    returnValue = "TAT reduction";
                    break;

                case IdeaCategory.TimeSaving:
                    returnValue = "Time saving";
                    break;
                case IdeaCategory.CSR:
                    returnValue = "CSR";
                    break;
                default:
                    returnValue = "Select";
                    break;
            }
            return returnValue;
        }
        public static String IdeaBusinessString(IdeaBusiness business)
        {
            String returnValue = "";
            switch (business)
            {
                case IdeaBusiness.Agro:
                    returnValue = "Agri";
                    break;

                case IdeaBusiness.Energy:
                    returnValue = "Energy";
                    break;

                case IdeaBusiness.Logistics:
                    returnValue = "Logistics";
                    break;

                case IdeaBusiness.Resources:
                    returnValue = "Resources";
                    break;
                case IdeaBusiness.Finance:
                    returnValue = "Financial Services";
                    break;
                case IdeaBusiness.Gas:
                    returnValue = "Gas Distribution";
                    break;
                default:
                    returnValue = "Select";
                    break;
            }
            return returnValue;
        }

        public static String IdeaCountryString(IdeaCountry country)
        {
            String returnValue = "";
            switch (country)
            {
                case IdeaCountry.Australia:
                    returnValue = "Australia";
                    break;

                case IdeaCountry.India:
                    returnValue = "India";
                    break;

                case IdeaCountry.Indonesia:
                    returnValue = "Indonesia";
                    break;

                default:
                    returnValue = "Select";
                    break;
            }
            return returnValue;
        }

        public static String IdeaStateString(IdeaState state)
        {
            String returnValue = "";
            switch (state)
            {
                case IdeaState.Gujarat:
                    returnValue = "Gujarat";
                    break;

                case IdeaState.Jakarta:
                    returnValue = "Jakarta";
                    break;

                case IdeaState.Queensland:
                    returnValue = "Queensland";
                    break;

                default:
                    returnValue = "Select";
                    break;
            }
            return returnValue;
        }

        public static String IdeaCityString(IdeaCity city)
        {
            String returnValue = "";
            switch (city)
            {
                case IdeaCity.Ahmedabad:
                    returnValue = "Ahmedabad";
                    break;

                case IdeaCity.Brisbane:
                    returnValue = "Brisbane";
                    break;

                case IdeaCity.JakartaSelatan:
                    returnValue = "JakartaSelatan";
                    break;

                default:
                    returnValue = "Select";
                    break;
            }
            return returnValue;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ADroper.Core.Models
{
    public class Colleges
    {
        public const string LAWS = "LAWS";
        public const string ECONS = "ENMS";
        public const string IRKHS = "IRKHS";
        public const string ENGIN = "ENGIN";
        public const string ARCHITECTURE = "AED";
        public const string EDUCATION = "EDUC";
        public const string ICT = "KICT";
        public const string SCIENCE = "KOS";
        public const string CELPAD = "CFL";
        public const string COCU = "CCAC";
        public const string KLM = "KLM";
        public const string ISTAC = "ISTAC";
        public const string MEDICINE = "MEDIC";
        public const string PHARMACY = "PHARM";
        public const string NURSING = "NURS";
        public const string ALLIED_HEALTH_SCIENCES = "KAHS";
        public const string DENTISTRY = "DENT";
        public const string BRIDGING_PROGRAMME = "BRIDG";
        public const string ISLAMIC_BANKING_AND_FINANCE = "IIBF";
        public const string INTERNATIONAL_INSTITUTE_FOR_HALAL_RESEARCH_AND_TRAINING = "IHART";

        public static string GetCollege(string name)
        {
            for (int i = 0; i < GetAllColleges().Count; i++)
            {
                if (GetAllColleges()[i].ToLower() == name.ToLower())
                {
                    return GetAllCollegesValues()[i] ;
                }
            }
            return null;
        }

        private static List<string> GetAllColleges()
        {
            return new List<string>
            {
                nameof(LAWS),
                nameof(ECONS),
                nameof(IRKHS),
                nameof(ENGIN),
                nameof(ARCHITECTURE),
                nameof(EDUCATION),
                nameof(ICT),
                nameof(SCIENCE),
                nameof(CELPAD),
                nameof(COCU),
                nameof(KLM),
                nameof(ISTAC),
                nameof(MEDICINE),
                nameof(PHARMACY),
                nameof(NURSING),
                nameof(ALLIED_HEALTH_SCIENCES),
                nameof(DENTISTRY),
                nameof(BRIDGING_PROGRAMME),
                nameof(ISLAMIC_BANKING_AND_FINANCE),
                nameof(INTERNATIONAL_INSTITUTE_FOR_HALAL_RESEARCH_AND_TRAINING)
            };
        }

        private static List<string> GetAllCollegesValues()
        {
            return new List<string>
            {
                LAWS,
                ECONS,
                IRKHS,
                ENGIN,
                ARCHITECTURE,
                EDUCATION,
                ICT,
                SCIENCE,
                CELPAD,
                COCU,
                KLM,
                ISTAC,
                MEDICINE,
                PHARMACY,
                NURSING,
                ALLIED_HEALTH_SCIENCES,
                DENTISTRY,
                BRIDGING_PROGRAMME,
                ISLAMIC_BANKING_AND_FINANCE,
                INTERNATIONAL_INSTITUTE_FOR_HALAL_RESEARCH_AND_TRAINING
            };
        }

    }
}

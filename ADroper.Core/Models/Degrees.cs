using System;
using System.Collections.Generic;
using System.Text;

namespace ADroper.Core.Models
{
    public class Degrees
    {
        public const string UNDERGRADUATE = "<";

        public const string POSTGRADUATE = ">=";

        public static string GetDegree(string name)
        {
            for (int i = 0; i < GetAllDegrees().Count; i++)
            {
                if (GetAllDegrees()[i].ToLower() == name.ToLower())
                {
                    return GetAllDegreesValues()[i];
                }
            }
            return null;
        }
        private static List<string> GetAllDegrees()
        {
            return new List<string>() { nameof(UNDERGRADUATE), nameof(POSTGRADUATE) };
        }

        private static List<string> GetAllDegreesValues()
        {
            return new List<string>() { UNDERGRADUATE, POSTGRADUATE };
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SpecflowAPIAutomation.Extensions
{
    public static class JSONExtension
    {
        public static string GetStringValue(this JToken token, string property)
        {
            string path = $"$.{property}";

            if (token.SelectToken(path) == null)
                return null;

            return token.SelectToken(path).ToString();
        }

        //------------------------------------------------------------------------------
        public static DateTime GetDateValue(this JToken token, string property)
        {
            string path = $"$.{property}";
            string val = token.SelectToken(path).ToString();
            return DateTime.Parse(val);
        }

        //------------------------------------------------------------------------------
    }
}

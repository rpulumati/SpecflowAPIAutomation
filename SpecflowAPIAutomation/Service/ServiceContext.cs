using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecflowAPIAutomation.Config;

namespace SpecflowAPIAutomation.Service
{
    public class ServiceContext
    {
        private string BearerToken { get; set; }
        public Uri BaseUri { get; set; }

        //------------------------------------------------------------------------------

        public string AuthorizationHeader
        {

            get
            {
                string credential = SFConfig.Instance.BearerToken;
                return $"Bearer {credential}";
            }
        }

        //------------------------------------------------------------------------------

        private string Base64Encode(string input)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(bytes);
        }
    }
}

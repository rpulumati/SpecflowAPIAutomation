using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Libmongocrypt;

namespace SpecflowAPIAutomation.Config
{
    public sealed class SFConfig
    {
        public Uri BaseUri { get; set; }
        public string SpecflowReportsDir { get; set; }
        public string BearerToken { get; set; }

        private static readonly Lazy<SFConfig> lazy = new Lazy<SFConfig>(() => new SFConfig());

        public static SFConfig Instance => lazy.Value;

        //------------------------------------------------------------------------------
        private SFConfig()
        {

        }

        //------------------------------------------------------------------------------

        public void Initialize()
        {
            BaseUri = new Uri(ConfigurationManager.AppSettings["BaseUrl"]);
            SpecflowReportsDir = ConfigurationManager.AppSettings["SpecflowReportsDir"];
            BearerToken = ConfigurationManager.AppSettings["BearerToken"];
        }
    }
}

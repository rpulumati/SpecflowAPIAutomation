using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowAPIAutomation.Data
{
    class SpecflowTransactionResult
    {
        /// <summary>
        /// Specflow transaction Result
        /// </summary>
        public bool IsSuccess;

        /// <summary>
        /// Specflow transaction Error Message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Specflow transaction Response Message
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Specflow transaction http status code received
        /// </summary>
        public HttpStatusCode RawHttpStatusCode { get; set; }
    }
}

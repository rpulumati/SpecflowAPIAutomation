using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace SpecflowAPIAutomation.Service
{
    class RestApi : IRestApi
    {
        public ServiceContext Context { get; }
        //------------------------------------------------------------------------------
        public RestApi(ServiceContext context)
        {
            Context = context;
        }

        //------------------------------------------------------------------------------
        public (string,HttpStatusCode) Invoke(string url, string data, HttpMethod httpMethod)
        {
            HttpWebRequest request = GetHttpWebRequest(url);
            request.Method = httpMethod.ToString();

            if (httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Put)
            {
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(data);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }

            using (HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = httpWebResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    string response = reader.ReadToEnd();
                    return (response,httpWebResponse.StatusCode);
                }
            }
        }

        //------------------------------------------------------------------------------

        private HttpWebRequest GetHttpWebRequest(string url)
        {
            Uri uri = new Uri(url);

            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uri);
            request.ContentType = "application/json; charset=utf-8";
            request.Headers["Authorization"] = Context.AuthorizationHeader;

            return request;
        }

    }
}

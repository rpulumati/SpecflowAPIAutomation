using System.Net;
using System.Net.Http;

namespace SpecflowAPIAutomation.Service
{
    internal interface IRestApi
    {
        (string,HttpStatusCode) Invoke(string url, string data, HttpMethod httpMethod);

        ServiceContext Context { get; }
    }
}
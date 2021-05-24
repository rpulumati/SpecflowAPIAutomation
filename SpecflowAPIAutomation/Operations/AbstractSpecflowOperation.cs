using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpecflowAPIAutomation.Data;
using SpecflowAPIAutomation.Service;

namespace SpecflowAPIAutomation.Operations
{
    internal abstract class AbstractSpecflowOperation<TReq,TResp>
    {
        private readonly IRestApi _restApi;
        protected abstract HttpMethod ServiceCallMethod { get; }
        protected abstract object GetRequestObject(TReq request);
        protected abstract string GetServiceCallUrl(string baseUrl, TReq request);
        protected abstract TResp ProcessResponse(string responseMessage);
        protected abstract void CheckRequestArgs(TReq request);
        //protected TReq Request { get; private set; }
        protected SpecflowTransactionResult Result { get; private set; }

        //------------------------------------------------------------------------------
        public AbstractSpecflowOperation(IRestApi restApi)
        {
            this._restApi = restApi;
        }
        //------------------------------------------------------------------------------

        public TResp Execute(TReq request)
        {
            CheckRequestArgs(request);

            object requestObj = GetRequestObject(request);

            string json = ConvertToJson(requestObj);

            string baseUrl = _restApi.Context.BaseUri.ToString();
                
            string url = GetServiceCallUrl(baseUrl,request);

            Result = ExecuteServiceCall(url, json);

            TResp resp = ProcessResponse(Result.ResponseMessage);

            return resp;

        }

        //------------------------------------------------------------------------------
        private SpecflowTransactionResult ExecuteServiceCall(string url, string data)
        {
            SpecflowTransactionResult result = new SpecflowTransactionResult();

            try
            {
                var response = _restApi.Invoke(url, data, ServiceCallMethod);
                result.IsSuccess = true;
                result.ResponseMessage = response.Item1;
                result.RawHttpStatusCode = response.Item2;

            }
            catch (WebException ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;

                if (ex.Response is HttpWebResponse resp)
                {
                    result.RawHttpStatusCode = resp.StatusCode;
                }
            }


            return result;
        }

        //------------------------------------------------------------------------------

        private string ConvertToJson(object req)
        {
            string json = null;

            if (req != null)
            {
                json = JsonConvert.SerializeObject(req);
            }

            return json;
        }
    }
}

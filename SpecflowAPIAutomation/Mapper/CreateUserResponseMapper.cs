using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SpecflowAPIAutomation.Data;
using SpecflowAPIAutomation.Extensions;
using SpecflowAPIAutomation.Response;

namespace SpecflowAPIAutomation.Mapper
{
    class CreateUserResponseMapper : BaseResponseMapper<CreateUserResponse>
    {
        public CreateUserResponse Map(string json)
        {
            CreateUserResponse response = new CreateUserResponse();
            JObject o = JObject.Parse(json);

            response.Code = o.SelectToken("$.code").ToString();
            response.MetaData = o.SelectToken("$.meta").ToString();

            JToken data = o.SelectToken("$.data");
            response.User = MapUser(data);

            return response;
        }

        //-----------------------------------------------------------------------
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SpecflowAPIAutomation.Enums;
using SpecflowAPIAutomation.Mapper;
using SpecflowAPIAutomation.Request;
using SpecflowAPIAutomation.Response;
using SpecflowAPIAutomation.Service;

namespace SpecflowAPIAutomation.Operations
{
    internal class CreateUserOperation : AbstractSpecflowOperation<CreateUserRequest,CreateUserResponse>
    {
        protected override HttpMethod ServiceCallMethod => HttpMethod.Post;

        //------------------------------------------------------------------
        public CreateUserOperation(IRestApi restApi) : base(restApi)
        {

        }

        //------------------------------------------------------------------
        protected override object GetRequestObject(CreateUserRequest request)
        {
            var user = new 
            {
                name = request.User.Name,
                email = request.User.Email,
                gender = request.User.Gender.ToString(),
                status = request.User.Status.ToString()
            };

            return user;
        }

     
        //------------------------------------------------------------------
        protected override string GetServiceCallUrl(string baseUrl, CreateUserRequest request)
        {
            string url = $"{baseUrl}/users";
            return url;
        }

        //------------------------------------------------------------------

        protected override CreateUserResponse ProcessResponse(string responseMessage)
        {
            return new CreateUserResponseMapper().Map(responseMessage);
        }
        //------------------------------------------------------------------
        protected override void CheckRequestArgs(CreateUserRequest request)
        {
            if (request.User == null)
            {
                throw new Exception("Not a valid user sent in the request");
            }

            if (request.User.Gender == Gender.Unknown)
            {
                throw new Exception("Not a valid user gender");
            }
        }
    }
}

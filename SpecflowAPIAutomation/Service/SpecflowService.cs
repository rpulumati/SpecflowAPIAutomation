using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecflowAPIAutomation.Config;
using SpecflowAPIAutomation.Operations;
using SpecflowAPIAutomation.Request;
using SpecflowAPIAutomation.Response;

namespace SpecflowAPIAutomation.Service
{
    public class SpecflowService: ISpecflowService
    {
        private readonly IRestApi _restApi;
 
        //------------------------------------------------------------------------------
        public SpecflowService(ServiceContext context)
        {
            _restApi = new RestApi(context);
        }

         //------------------------------------------------------------------------------
        public CreateUserResponse CreateUserOperation(CreateUserRequest request)
        {
            return new CreateUserOperation(_restApi).Execute(request);
        }
    }
}

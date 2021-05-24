using SpecflowAPIAutomation.Request;
using SpecflowAPIAutomation.Response;

namespace SpecflowAPIAutomation.Service
{
    public interface ISpecflowService
    {
        CreateUserResponse CreateUserOperation(CreateUserRequest request);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SpecflowAPIAutomation.Data;
using SpecflowAPIAutomation.Enums;
using SpecflowAPIAutomation.Operations;
using SpecflowAPIAutomation.Request;
using SpecflowAPIAutomation.Response;
using TechTalk.SpecFlow;

namespace SpecflowAPIAutomation.StepDefinitions
{
    [Binding]
    public class CreateUserSteps : BaseSteps
    {

        public CreateUserSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        //------------------------------------------------------------------------------------
        [Given(@"I populate create user request with \((.*),(.*),(.*),(.*)\)")]
        public void GivenIPopulateCreateUserRequest(string userName, string email, Gender gender, Status status)
        {
           CreateUserRequest request = new CreateUserRequest
           {
               User = new User
               {
                   Name = userName,
                   Email = email,
                   Gender = gender,
                   Status = status
               }
           };

           SFContext.SetValue(request);
        }

        //------------------------------------------------------------------------------------
        [When(@"I execute create user request")]
        public void WhenIExecuteCreateUserRequest()
        {
            CreateUserRequest request = SFContext.GetValue<CreateUserRequest>();
            CreateUserResponse response = SpecflowService.CreateUserOperation(request);
            SFContext.SetValue(response);
        }

        //------------------------------------------------------------------------------------
        [Then(@"I validate user is successfully created (.*)")]
        public void ThenIValidateUserIsSuccessfullyCreated(string respCode)
        {
            CreateUserResponse resp = SFContext.GetValue<CreateUserResponse>();
            CreateUserRequest req = SFContext.GetValue<CreateUserRequest>();

            // Assert Create user response against request
            Assert.IsNotNull(resp.User);
            Assert.AreEqual(resp.Code, respCode, $"Response code assert failed, Expected: {respCode}, Actual: {resp.Code}");
            Assert.AreEqual(resp.User.Name, req.User.Name, $"User name assert failed, Expected: {req.User.Name}, Actual: {resp.User.Name}");
            Assert.AreEqual(resp.User.Email, req.User.Email, $"Email assert failed, Expected: {req.User.Email}, Actual: {resp.User.Email}");
            Assert.AreEqual(resp.User.Status, req.User.Status, $"Status assert failed, Expected: {req.User.Status}, Actual: {resp.User.Status}");
        }
    }
}

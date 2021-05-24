using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecflowAPIAutomation.Config;
using SpecflowAPIAutomation.Service;
using TechTalk.SpecFlow;

namespace SpecflowAPIAutomation.StepDefinitions
{
    public abstract class BaseSteps : Steps
    {
        protected SFContext SFContext { get; }
        protected ServiceContext ServiceContext { get; }
        protected SpecflowService SpecflowService { get; }

        //-------------------------------------------------------------------------
        public BaseSteps(ScenarioContext scenarioContext)
        {
            SFContext = new SFContext(scenarioContext);
            ServiceContext = new ServiceContext {BaseUri = SFConfig.Instance.BaseUri};
            SpecflowService = new SpecflowService(ServiceContext);
        }
    }
}

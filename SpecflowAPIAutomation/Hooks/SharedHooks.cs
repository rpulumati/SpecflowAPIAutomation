using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using SpecflowAPIAutomation.Config;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace SpecflowAPIAutomation.Hooks
{
    [Binding]
    public class SharedHooks
    {
        static ExtentReports _extent;
        static ExtentTest _feature, _scenario, _step;

        [BeforeTestRun]
        private static void SfConfig()
        {
            SFConfig.Instance.Initialize();
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(SFConfig.Instance.SpecflowReportsDir);
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        private static void BeforeFeature(FeatureContext context)
        {
            _feature = _extent.CreateTest(context.FeatureInfo.Title);
        }

        [BeforeScenario]
        private static void BeforeScenario(ScenarioContext context)
        {
            _scenario = _feature.CreateNode(context.ScenarioInfo.Title);
        }

        [BeforeStep]
        private static void BeforeStep()
        {
            _step = _scenario;
        }

        [AfterStep]
        private static void AfterStep(ScenarioContext context)
        {
            if (context.TestError == null)
            {
                _step.Log(Status.Pass, context.StepContext.StepInfo.Text);
            }

            else if (context.TestError != null)
            {
                _step.Log(Status.Fail, context.StepContext.StepInfo.Text);
            }
        }

        [AfterFeature]
        private static void AfterFeature()
        {
            _extent.Flush();
        }
    }
}

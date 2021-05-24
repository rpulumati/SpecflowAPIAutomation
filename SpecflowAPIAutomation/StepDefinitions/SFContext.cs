using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowAPIAutomation.StepDefinitions
{
    public sealed class SFContext
    {
        // -----------------------------------------------------------------------------
        //          Generic methods that apply to all context operations
        // -----------------------------------------------------------------------------

        private readonly ScenarioContext _scenarioContext;

        // -----------------------------------------------------------------------------
        public SFContext(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }

        // -----------------------------------------------------------------------------
        public T SetValue<T>(T data, string contextKey)
        {
            _scenarioContext.Set(data,contextKey);
            return data;
        }

        // -----------------------------------------------------------------------------
        public T SetValue<T>(T data)
        {
            _scenarioContext.Set(data, typeof(T).Name);
            return data;
        }

        // -----------------------------------------------------------------------------
        public T GetValue<T>(string contextKey)
        {
            if (ContainsKey(contextKey))
            {
                return _scenarioContext.Get<T>(contextKey);
            }

            throw new Exception(string.Format("Could not get value from context for key: {0}.", contextKey));
        }

        // -----------------------------------------------------------------------------
        public T GetValue<T>()
        {
            if (ContainsKeyFor<T>())
            {
                return _scenarioContext.Get<T>(typeof(T).Name);
            }

            throw new Exception(string.Format("Could not get value from context for key: {0}.", typeof(T).Name));
        }

        // -----------------------------------------------------------------------------
        public bool ContainsKey(string key)
        {
            return _scenarioContext.ContainsKey(key);
        }

        // -----------------------------------------------------------------------------
        public bool ContainsKeyFor<T>()
        {
            return _scenarioContext.ContainsKey(typeof(T).Name);
        }
    }
}

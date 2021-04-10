using API_RestSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace API_RestSharp
{
    [Binding]
    public sealed class Hooks1
    {
        private Settings _settings;
        public Hooks1(Settings settings)
        {
            _settings = settings;
        }
        

        [BeforeScenario]
        public void BeforeScenario()
        {
           
            _settings.BaseUrl = new Uri(AppConfigManager.BaseUrl());
            _settings.client.BaseUrl = _settings.BaseUrl;
        }

       
    }
}

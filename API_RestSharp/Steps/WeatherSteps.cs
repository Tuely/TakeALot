using API_RestSharp.APIHelper;
using API_RestSharp.Core;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace API_RestSharp.Steps
{
    [Binding]
    public class WeatherSteps
    {
        private Settings _settings;
        public WeatherSteps(Settings settings)
        {
            _settings = settings;
        }
        [Given(@"I enter the city as '(.*)'")]
        public void GivenIEnterTheCityAs(string location)
        {
            _settings.request = new RestRequest(AppConfigManager.BaseUrl() + location + "&appid=" + AppConfigManager.ApiKey(), Method.GET);
            
        }

        [Then(@"I verify the response as '(.*)'")]
        public void ThenIVerifyTheResponseAs(string responseCode)
        {
            var response = _settings.client.Execute<BodyParams>(_settings.request);

            Assert.That(response.Data.name, Is.EqualTo("London"), "Response has showing teh weather in London");
            Assert.That(response.Data.cod, Is.EqualTo(responseCode), "Sucessful response with response code as 200");
        }

    }
}

using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace WeatherAPI.Steps
{
    [Binding]
    public class VerifyWeatherSteps
    {
        private WeatherCheckExecuter WeatherCheckExecuter;

        [Before]
        public void Before()
        {
            WeatherCheckExecuter = new WeatherCheckExecuter();
        }

        [After]
        public void After()
        {
            WeatherCheckExecuter = null;
        }
        [Given(@"I have enter city as '(.*)'")]
        public void GivenIHaveEnterCityAs(string cityName)
        {
            WeatherCheckExecuter.Loction = cityName;
        }
        
        [When(@"I send request to API")]
        public void WhenISendRequestToAPI()
        {
            WeatherCheckExecuter.Submit();
        }
        
        [Then(@"The Co-Ordinates returned will be long '(.*)' lat '(.*)'")]
        public void ThenTheCo_OrdinatesReturnedWillBeLongLat(Double lon, Decimal lat)
        {
            Assert.AreEqual(WeatherCheckExecuter.Response.results[0].coord.lon, lon);
        }

        [When(@"I send request to API with API Key '(.*)'")]
        public void WhenISendRequestToAPIWithAPIKey(string apiKey)
        {
            WeatherCheckExecuter.APIKey = apiKey;
            WeatherCheckExecuter.Submit();
        }

        [Then(@"an error of '(.*)' will be returned")]
        public void ThenAnErrorOfWillBeReturned(string error)
        {
            Assert.AreEqual(WeatherCheckExecuter.Response.status, error);
        }

        [Then(@"response will be '(.*)'")]
        public void ThenResponseWillBe(int code)
        {
            Assert.AreEqual(WeatherCheckExecuter.Response.cod, code);
        }


    }
}

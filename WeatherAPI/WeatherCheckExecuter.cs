using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Text;

namespace WeatherAPI
{
    public class WeatherCheckExecuter
    {
        public string Loction { get; set; }
        public string APIKey { get; set; }
        public string ResponseText { get; private set; }
        public dynamic Response { get; private set; }

        private ExpandoObjectConverter converter;
        private WebClient client;

        public WeatherCheckExecuter()
        {
            client = new WebClient();

            converter = new ExpandoObjectConverter();
        }

        public void Submit()
        {
           
            var url = string.Format(AppConfigManager.APIURI()+ WebUtility.UrlEncode(Loction) +"&appid="+ AppConfigManager.APIKey());

            ResponseText = HTTPGet(url);

            Response = JsonConvert.DeserializeObject<ExpandoObject>(ResponseText, converter);
        }
        private string HTTPGet(string url)
        {
            string response = string.Empty;

            try
            {
                var data = client.OpenRead(url);
                var reader = new StreamReader(data);

                response = reader.ReadToEnd();

                data.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }

            return response;
        }

    }
}

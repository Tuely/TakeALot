using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherAPI
{
    public class AppConfigManager
    {
        public static readonly IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
                   .Build();

        public static string APIURI()
        {
            return configuration["Client:APIURI"] ?? string.Empty;
        }

        public static string APIKey()
        {
            return configuration["Client:APIKey"] ?? string.Empty;
        }
    }
}

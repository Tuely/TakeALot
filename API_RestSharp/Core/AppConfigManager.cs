using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_RestSharp.Core
{
   public class AppConfigManager
    {
        public static readonly IConfigurationRoot configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", true, true)
                  .Build();

        public static string BaseUrl()
        {
            return configuration["Client:APIUri"] ?? string.Empty;
        }
        public static string ApiKey()
        {
            return configuration["Client:APIKey"] ?? string.Empty;
        }
    }
}

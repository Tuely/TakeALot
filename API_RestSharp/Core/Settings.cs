using RestSharp;
using API_RestSharp.APIHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_RestSharp.Core
{
   public class Settings
    {
        public Uri BaseUrl { get; set; }
        public IRestResponse<BodyParams> response { get; set; }
        public RestRequest request { get; set; }

        public RestClient client { get; set; } = new RestClient();
    }
}

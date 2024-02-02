using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace JobVietAPI.Commons
{
    public class RequestAPI
    {
        public HttpClient client;
        private IConfiguration config;
        public RequestAPI(IConfiguration configuration, string confBaseUrl, string token = "")
        {
            ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            var handler = new HttpClientHandler { UseDefaultCredentials = true };
            client = new HttpClient(handler);

            client.BaseAddress = new Uri(config[confBaseUrl].ToString());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.
                Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }
}

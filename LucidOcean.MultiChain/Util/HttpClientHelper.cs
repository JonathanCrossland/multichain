using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace LucidOcean.MultiChain.Util
{
    public static class HttpClientHelper
    {
        // Basic auth
        public static HttpClient GetHttpClientWithBasicAuth(string url, string username, string password)
        {
            Trace.WriteLine("Creating RPC Connection");
            var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));

            var baseAddress = new Uri(url);
            var client = new HttpClient()
            {
                BaseAddress = baseAddress,
                DefaultRequestHeaders = { Authorization = authValue, ConnectionClose = false }
            };
            ServicePointManager.FindServicePoint(baseAddress).ConnectionLeaseTimeout = 120 * 1000;
            return client;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeneralWebApp
{
    public class ExmplApiClient
    {
        private HttpClient client;

        public ExmplApiClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://localhost:37173/api/Example/");

            client = httpClient;
        }

        public async Task<string> GetGreeting(string name)
        {
            try
            {
                return await client.GetStringAsync($"?name={name}");// new Uri($"?name={name}", UriKind.Relative));
            }
            catch (Exception ex)
            {
                return ex.ToString();
                //throw ex;
            }
        }
    }
}

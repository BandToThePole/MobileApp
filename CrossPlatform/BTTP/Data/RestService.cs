using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BTTP
{
    public class RestService : IRestService
    {
        private HttpClient client;

        public RestService()
        {
            this.client = new HttpClient();
        }

        public async Task<AllData> RefreshDataAsync()
        {
            AllData allData = null;

            var uri = new Uri(Constants.FetchUrl);

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    allData = JsonConvert.DeserializeObject<AllData>(content);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error fetching/parsing data: {e.Message}");
            }

            return allData;
        }
    }
}

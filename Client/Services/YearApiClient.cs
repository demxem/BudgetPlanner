using System.Net.Http.Json;
using Client.Models;

namespace Client.Services
{
    public class YearApiClient
    {
        private readonly HttpClient httpClient;

        public YearApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<YearModel>?> GetResultAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("/years");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<List<YearModel>>();

                    return result;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<YearModel>();

        }
    }
}
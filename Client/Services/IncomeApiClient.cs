using System.Net.Http.Json;
using Client.Models;

namespace Client.Services
{
    public class IncomeApiClient
    {

        private readonly HttpClient httpClient;

        public IncomeApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<IncomeModel>?> GetIncomeAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("/years/months/income");

                if (response.IsSuccessStatusCode)
                {
                    var income = await response.Content.ReadFromJsonAsync<List<IncomeModel>>();

                    return income;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<IncomeModel>();

        }

        //     public async Task AddItemAsync()
        //     {
        //         var item = new IncomeModel { Name = _name, Description = _description, ReleaseDate = _releaseDate };
        //         await httpClient.PostAsJsonAsync("movies", item);
        //     }
        // }

    }
}
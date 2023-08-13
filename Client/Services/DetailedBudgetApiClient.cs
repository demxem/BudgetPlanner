using System.Net.Http.Json;
using Client.Models;

namespace Client.Services
{
    public class DetailedBudgetApiClient
    {
        private readonly HttpClient httpClient;

        public DetailedBudgetApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<DetailedBudgetModel>?> GetBudgetAsync()
        {
            try
            {
                var response = await httpClient.GetAsync($"/years/months/budget");

                if (response.IsSuccessStatusCode)
                {
                    var budget = await response.Content.ReadFromJsonAsync<List<DetailedBudgetModel>>();

                    return budget;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<DetailedBudgetModel>();
        }

        public async Task<List<DetailedBudgetModel?>> GetBudgetByMonthIdAsync(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/years/months/budget/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var budget = await response.Content.ReadFromJsonAsync<List<DetailedBudgetModel>>();

                    return budget!;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<DetailedBudgetModel?>();
        }

        public async Task InsertBudgetAsync(DetailedBudgetModel budget)
        {
            try
            {
                await httpClient.PostAsJsonAsync("/years/months/budget/", budget);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public async Task UpdateBudgetAsync(int id)
        {
            try
            {
                await httpClient.PutAsJsonAsync($"/years/months/budget/{id}", id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        public async Task DeleteBudgetAsync(int id)
        {
            try
            {
                await httpClient.DeleteAsync($"/years/months/budget/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}

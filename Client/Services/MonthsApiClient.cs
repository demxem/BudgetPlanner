using System.Net.Http.Json;
using Client.Models;
namespace Client.Services
{
    public class MonthsApiClient
    {
        private readonly HttpClient httpClient;

        public MonthsApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<BudgetModel>?> GetMonthsAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("/years/months");

                if (response.IsSuccessStatusCode)
                {
                    var months = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

                    return months;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            return new List<BudgetModel>();
        }

        public async Task UpdateMonthAsync(BudgetModel month)
        {
            await httpClient.PutAsJsonAsync($"/years/months/{month.Id}", month);
        }

        public async Task PostMonthAsync(BudgetModel month)
        {
            await httpClient.PostAsJsonAsync($"/years/months", month);
        }
        public async Task<float> GetMonthlyIncome(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/months/income/monthlyIncome/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var monthlyIncome = await response.Content.ReadFromJsonAsync<float>();

                    return monthlyIncome;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return 0;
        }

    }
}

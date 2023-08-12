using System.Net.Http.Json;
using Client.Models;

namespace Client.Services
{
    public class CompletedBudgetApiService
    {
        private readonly HttpClient httpClient;
        public CompletedBudgetApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<BudgetCompletionModel>?> GetBudgetCompletionByYearIdAsync(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/years/completed/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var budget = await response.Content.ReadFromJsonAsync<List<BudgetCompletionModel>>();
                    return budget;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new List<BudgetCompletionModel>();
        }

        public async Task<BudgetCompletionModel?> GetBudgetCompletionByMonthIdAsync(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/years/months/completed/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var budget = await response.Content.ReadFromJsonAsync<BudgetCompletionModel>();
                    return budget;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new BudgetCompletionModel();
        }
        public async Task<BudgetCompletionModel?> GetBudgetCompletionByMonthIdInPercentAsync(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/years/months/percentCompleted/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var budget = await response.Content.ReadFromJsonAsync<BudgetCompletionModel>();
                    return budget;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new BudgetCompletionModel();
        }
    }
}
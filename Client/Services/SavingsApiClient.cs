using System.Net.Http.Json;
using Client.Models;
namespace Client.Services
{
    public class SavingsApiClient
    {
        private readonly HttpClient httpClient;

        public SavingsApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<SavingsModel>?> GetSavingsAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("/savings");

                if (response.IsSuccessStatusCode)
                {
                    var savings = await response.Content.ReadFromJsonAsync<List<SavingsModel>>();

                    return savings;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<SavingsModel>();
        }

        public async Task<BudgetModel?> GetLatestSavingsAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("years/months/savings");

                if (response.IsSuccessStatusCode)
                {
                    var savings = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();
                    var latestSavings = savings?.LastOrDefault();

                    return latestSavings;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new BudgetModel();
        }

        public async Task<List<BudgetModel>?> GetSavingByEachMonthAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("years/months/savings");

                if (response.IsSuccessStatusCode)
                {
                    var savings = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

                    return savings;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<BudgetModel>();
        }
        public async Task<List<BudgetModel>?> GetSavingsByYearId(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/years/months/savings/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var savings = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

                    return savings;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<BudgetModel>();
        }
        public async Task<BudgetModel?> GetSavingsByMonthIdAsync(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/years/months/savings/month/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var savings = await response.Content.ReadFromJsonAsync<BudgetModel>();

                    return savings;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new BudgetModel();
        }

        public async Task UpdateSavingsAsync(SavingsModel? item)
        {
            await httpClient.PutAsJsonAsync($"/years/months/savings/{item?.Id}", item);
        }

        public async Task DeleteSavingsByIdAsync(int Id)
        {
            await httpClient.DeleteAsync($"/years/months/savings/{Id}");
        }

        public async Task PostSavingsAsync(SavingsModel savings)
        {
            await httpClient.PostAsJsonAsync($"/years/months/savings/", savings);
        }

        public async Task<float> GetMonthlySavings(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/months/income/monthlySavings/{id}");

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

        public async Task<float> GetYearlySavings(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/months/savings/totalSavings/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var yearlySavings = await response.Content.ReadFromJsonAsync<float>();

                    return yearlySavings;
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
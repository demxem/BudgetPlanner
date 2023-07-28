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
                var response = await httpClient.GetAsync("/income");

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

        public async Task<List<BudgetModel>?> GetIncomeByEachMonthAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("years/months/income");

                if (response.IsSuccessStatusCode)
                {
                    var income = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

                    return income;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<BudgetModel>();
        }
        public async Task<BudgetModel?> GetLatestIncomeAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("years/months/income");

                if (response.IsSuccessStatusCode)
                {
                    var income = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();
                    var latestIncome = income?.LastOrDefault();

                    return latestIncome;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new BudgetModel();
        }
        public async Task<List<BudgetModel>?> GetIncomeByYearId(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/years/months/income/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var income = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

                    return income;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<BudgetModel>();
        }
        public async Task<BudgetModel?> GetIncomeByMonthIdAsync(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/years/months/income/month/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var income = await response.Content.ReadFromJsonAsync<BudgetModel>();

                    return income;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new BudgetModel();
        }

        public async Task UpdateIncomeAsync(IncomeModel? item)
        {
            await httpClient.PutAsJsonAsync($"/years/months/income/{item?.Id}", item);
        }


        public async Task DeleteIncomeByIdAsync(int Id)
        {
            await httpClient.DeleteAsync($"/years/months/income/{Id}");
        }

        public async Task PostIncomeAsync(IncomeModel income)
        {
            await httpClient.PostAsJsonAsync($"/years/months/income/", income);
        }

        public async Task PostIncomeByYearIdAsync(BudgetModel month)
        {
            await httpClient.PostAsJsonAsync($"/years/months/incomeByYearId", month);
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

        public async Task<float> GetMonthlyUndistributedIncome(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/months/income/monthlyUndistributedIncome/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var monthlyUndistributedIncome = await response.Content.ReadFromJsonAsync<float>();

                    return monthlyUndistributedIncome;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return 0;
        }

        public async Task<float> GetYearlyIncome(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/months/income/totalIncome/{id}");

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


        public async Task<float> GetYearlyUndistributedIncome(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/months/income/yearlyUndistributedIncome/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var yearlyUndistributedIncome = await response.Content.ReadFromJsonAsync<float>();

                    return yearlyUndistributedIncome;
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

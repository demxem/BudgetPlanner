using System.Data.Common;
using System.Net.Http.Json;
using Client.Models;

namespace Client.Services
{
    public class ApiClient
    {

        private readonly HttpClient httpClient;

        public ApiClient(HttpClient httpClient)
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
        public async Task<List<SavingsModel>?> GetSavingsAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("/years/months/savings");

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
        public async Task<List<ExpensesModel>?> GetExpensesAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("/years/months/expenses");

                if (response.IsSuccessStatusCode)
                {
                    var expenses = await response.Content.ReadFromJsonAsync<List<ExpensesModel>>();

                    return expenses;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<ExpensesModel>();
        }

        public async Task<List<MonthModel>?> GetMonthsAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("years/months");

                if (response.IsSuccessStatusCode)
                {
                    var months = await response.Content.ReadFromJsonAsync<List<MonthModel>>();

                    return months;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<MonthModel>();
        }

        public async Task<List<YearModel>?> GetYearsAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("/years");

                if (response.IsSuccessStatusCode)
                {
                    var years = await response.Content.ReadFromJsonAsync<List<YearModel>>();

                    return years;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<YearModel>();
        }

        public async Task AddItemAsync(IncomeModel item)
        {
            await httpClient.PutAsJsonAsync($"/years/months/income/{item.Id}", item);
        }
    }
}
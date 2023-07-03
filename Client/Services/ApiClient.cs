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

        public async Task<List<YearModel?>> GetYears()
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
            return new List<YearModel?>();
        }
        public async Task<List<MonthModel?>> GetMonthsAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("/years/months");

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
            return new List<MonthModel?>();
        }

        public async Task<List<DateModel?>> GetLatestDateAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("/years/months/date");

                if (response.IsSuccessStatusCode)
                {
                    var date = await response.Content.ReadFromJsonAsync<List<DateModel>>();

                    return date;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<DateModel?>();
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

        public async Task<List<MonthModel>?> GetExpensesByMonthAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("years/months/expenses");

                if (response.IsSuccessStatusCode)
                {
                    var expenses = await response.Content.ReadFromJsonAsync<List<MonthModel>>();

                    return expenses;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<MonthModel>();
        }
        public async Task<List<MonthModel>?> GetIncomeByMonthAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("years/months/income");

                if (response.IsSuccessStatusCode)
                {
                    var income = await response.Content.ReadFromJsonAsync<List<MonthModel>>();

                    return income;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<MonthModel>();
        }
        public async Task<List<MonthModel>?> GetSavingByMonthAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("years/months/savings");

                if (response.IsSuccessStatusCode)
                {
                    var savings = await response.Content.ReadFromJsonAsync<List<MonthModel>>();

                    return savings;
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
        public async Task<List<MonthModel>> GetIncomeByYearId(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/years/months/income/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var income = await response.Content.ReadFromJsonAsync<List<MonthModel>>();

                    return income;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<MonthModel>();
        }

        public async Task UpdateIncomeAsync(IncomeModel item)
        {
            await httpClient.PutAsJsonAsync($"/years/months/income/{item.Id}", item);
        }
        public async Task UpdateSavingsAsync(SavingsModel item)
        {
            await httpClient.PutAsJsonAsync($"/years/months/savings/{item.Id}", item);
        }
        public async Task UpdateExpensesAsync(ExpensesModel item)
        {
            await httpClient.PutAsJsonAsync($"/years/months/expenses/{item.Id}", item);
        }

        public async Task DeleteIncomeAsync(int Id)
        {
            await httpClient.DeleteAsync($"/years/months/income/{Id}");
        }
        public async Task DeleteSavingsAsync(int Id)
        {
            await httpClient.DeleteAsync($"/years/months/savings/{Id}");
        }
        public async Task DeleteExpensesAsync(int Id)
        {
            await httpClient.DeleteAsync($"/years/months/expenses/{Id}");
        }

        public async Task PostIncomeAsync(IncomeModel income)
        {
            await httpClient.PostAsJsonAsync($"/years/months/income/", income);
        }
        public async Task PostIncomeByYearIdAsync(MonthModel month, int id)
        {
            await httpClient.PostAsJsonAsync($"/years/months/income/{id}", month);
        }

        public async Task PostYearAsync(YearModel year)
        {
            await httpClient.PostAsJsonAsync($"/years", year);
        }
        public async Task PostMonthAsync(MonthModel month)
        {
            await httpClient.PostAsJsonAsync($"/years/months", month);
        }
    }

}
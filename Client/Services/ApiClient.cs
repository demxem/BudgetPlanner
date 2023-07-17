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

        public async Task<List<MonthModel>?> GetMonthsAsync()
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

            return new List<MonthModel>();
        }

        public async Task<List<DateModel>?> GetLatestDateAsync()
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
            return new List<DateModel>();
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
        public async Task<List<ExpensesModel>?> GetExpensesAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("/expenses");

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
        public async Task<List<MonthModel>?> GetDataAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("months/budget");

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<List<MonthModel>>();

                    return data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<MonthModel>();
        }
        public async Task<List<MonthModel>?> GetExpensesByEachMonthAsync()
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
        public async Task<List<MonthModel>?> GetIncomeByEachMonthAsync()
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
            return new List<MonthModel?>();
        }
        public async Task<List<MonthModel>?> GetSavingByEachMonthAsync()
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
        public async Task<List<MonthModel>?> GetIncomeByYearId(int id)
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

        public async Task<List<MonthModel>?> GetExpensesByYearId(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/years/months/expenses/{id}");

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

        public async Task<List<MonthModel>?> GetSavingsByYearId(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/years/months/savings/{id}");

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

        public async Task UpdateIncomeAsync(IncomeModel? item)
        {
            await httpClient.PutAsJsonAsync($"/years/months/income/{item?.Id}", item);
        }
        public async Task UpdateSavingsAsync(SavingsModel? item)
        {
            await httpClient.PutAsJsonAsync($"/years/months/savings/{item?.Id}", item);
        }
        public async Task UpdateExpensesAsync(ExpensesModel? item)
        {
            await httpClient.PutAsJsonAsync($"/years/months/expenses/{item?.Id}", item);
        }
        public async Task UpdateMonthAsync(MonthModel month)
        {
            await httpClient.PutAsJsonAsync($"/years/months/{month.Id}", month);
        }

        public async Task DeleteIncomeByIdAsync(int Id)
        {
            await httpClient.DeleteAsync($"/years/months/income/{Id}");
        }
        public async Task DeleteSavingsByIdAsync(int Id)
        {
            await httpClient.DeleteAsync($"/years/months/savings/{Id}");
        }
        public async Task DeleteExpensesByIdAsync(int Id)
        {
            await httpClient.DeleteAsync($"/years/months/expenses/{Id}");
        }

        public async Task DeleteYearByIdAsync(int id)
        {
            await httpClient.DeleteAsync($"/years/{id}");
        }

        public async Task PostIncomeAsync(IncomeModel income)
        {
            await httpClient.PostAsJsonAsync($"/years/months/income/", income);
        }
        public async Task PostExpensesAsync(ExpensesModel expenses)
        {
            await httpClient.PostAsJsonAsync($"/years/months/expenses/", expenses);
        }
        public async Task PostSavingsAsync(SavingsModel savings)
        {
            await httpClient.PostAsJsonAsync($"/years/months/savings/", savings);
        }
        public async Task PostIncomeByYearIdAsync(MonthModel month)
        {
            await httpClient.PostAsJsonAsync($"/years/months/incomeByYearId", month);
        }

        public async Task PostYearAsync(YearModel year)
        {
            await httpClient.PostAsJsonAsync($"/years", year);
        }
        public async Task PostMonthAsync(MonthModel month)
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
        public async Task<float> GetMonthlyExpenses(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/months/income/monthlyExpenses/{id}");

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
        public async Task<float> GetYearlyExpenses(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/months/expenses/totalExpenses/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var yearlyExpenses = await response.Content.ReadFromJsonAsync<float>();

                    return yearlyExpenses;
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
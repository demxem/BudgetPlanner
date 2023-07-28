using System.Net.Http.Json;
using Client.Models;
namespace Client.Services
{
    public class ExpensesApiClient
    {
        private readonly HttpClient httpClient;

        public ExpensesApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
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

        public async Task<List<BudgetModel>?> GetExpensesByEachMonthAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("years/months/expenses");

                if (response.IsSuccessStatusCode)
                {
                    var expenses = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

                    return expenses;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<BudgetModel>();
        }

        public async Task<BudgetModel?> GetLatestExpensesAsync()
        {
            try
            {
                var response = await httpClient.GetAsync("years/months/expenses");

                if (response.IsSuccessStatusCode)
                {
                    var expenses = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();
                    var latestExpenses = expenses?.LastOrDefault();

                    return latestExpenses;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new BudgetModel();
        }

        public async Task<List<BudgetModel>?> GetExpensesByYearId(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/years/months/expenses/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var expenses = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

                    return expenses;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new List<BudgetModel>();
        }
        public async Task<BudgetModel?> GetExpensesByMonthIdAsync(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"/years/months/expenses/month/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var expenses = await response.Content.ReadFromJsonAsync<BudgetModel>();

                    return expenses;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            return new BudgetModel();
        }

        public async Task UpdateExpensesAsync(ExpensesModel? item)
        {
            await httpClient.PutAsJsonAsync($"/years/months/expenses/{item?.Id}", item);
        }

        public async Task DeleteExpensesByIdAsync(int Id)
        {
            await httpClient.DeleteAsync($"/years/months/expenses/{Id}");
        }

        public async Task PostExpensesAsync(ExpensesModel expenses)
        {
            await httpClient.PostAsJsonAsync($"/years/months/expenses/", expenses);
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
    }
}
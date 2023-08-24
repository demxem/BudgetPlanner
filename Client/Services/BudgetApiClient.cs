using Client.Models;
using System.Net.Http.Json;


namespace Client.Services;

public class BudgetApiClient
{
    private readonly HttpClient _httpClient;

    public BudgetApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<BudgetModel>?> GetIncomeAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/budget/income");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

                return result;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
        return new List<BudgetModel>();
    }

    public async Task<List<BudgetModel>?> GetIncomeByYearIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/budget/years/income/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

                return result;
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
            var response = await _httpClient.GetAsync($"/budget/years/months/income/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<BudgetModel>();

                return result;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }

        return new BudgetModel()
        {
            Income = new IncomeModel()
        };
    }

    public async Task<List<BudgetModel>?> GetExpensesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/budget/expenses");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

                return result;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
        return new List<BudgetModel>();
    }

    public async Task<List<BudgetModel>?> GetExpensesByYearIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/budget/years/expenses/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

                return result;
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
            var response = await _httpClient.GetAsync($"/budget/years/months/expenses/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<BudgetModel>();

                return result;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }

        return new BudgetModel()
        {
            Expenses = new ExpensesModel()
        };
    }

    public async Task<List<BudgetModel>?> GetSavingAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/budget/savings");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

                return result;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
        return new List<BudgetModel>();
    }

    public async Task<List<BudgetModel>?> GetSavingsByYearIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/budget/years/savings/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

                return result;
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
            var response = await _httpClient.GetAsync($"/budget/years/months/savings/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<BudgetModel>();

                return result;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
        return new BudgetModel()
        {
            Savings = new SavingsModel()
        };
    }

    public async Task<List<BudgetModel>?> GetMonthsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/years/months");

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
        await _httpClient.PutAsJsonAsync($"/years/months/{month.Id}", month);
    }

    public async Task AddMonthAsync(BudgetModel month)
    {
        await _httpClient.PostAsJsonAsync($"/years/months", month);
    }
}

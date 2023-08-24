using System.Net.Http.Json;
using Client.Models;

namespace Client.Services;

public class ExpensesApiClient
{
    private readonly HttpClient _httpClient;

    public ExpensesApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ExpensesModel>?> GetAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/expenses");

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

    public async Task UpdateAsync(ExpensesModel? item)
    {
        try
        {
            await _httpClient.PutAsJsonAsync($"/years/months/expenses/{item?.Id}", item);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
    }

    public async Task DeleteAsync(int Id)
    {
        try
        {
            await _httpClient.DeleteAsync($"/years/months/expenses/{Id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
    }

    public async Task AddAsync(ExpensesModel expenses)
    {
        try
        {
            await _httpClient.PostAsJsonAsync($"/years/months/expenses/", expenses);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
    }
}

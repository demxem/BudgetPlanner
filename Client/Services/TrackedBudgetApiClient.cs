using System.Net.Http.Json;
using Client.Models;

namespace Client.Services;

public class TrackedBudgetApiClient
{
    private readonly HttpClient _httpClient;

    public TrackedBudgetApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<BudgetTrackedModel>?> GetAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync($"/years/months/trackedbudget/");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<BudgetTrackedModel>>();

                return result;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
        return new List<BudgetTrackedModel>();
    }

    public async Task<List<BudgetTrackedModel?>> GetByMonthIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/years/months/trackedbudget/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<BudgetTrackedModel>>();

                return result!;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
        return new List<BudgetTrackedModel?>();
    }

    public async Task AddAsync(BudgetTrackedModel budget)
    {
        try
        {
            await _httpClient.PostAsJsonAsync("/years/months/trackedbudget/", budget);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
    }

    public async Task UpdateAsync(int id)
    {
        try
        {
            await _httpClient.PutAsJsonAsync($"/years/months/trackebudget/{id}", id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
    }
    public async Task DeleteAsync(int id)
    {
        try
        {
            await _httpClient.DeleteAsync($"/years/months/trackedbudget/{id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
    }
}


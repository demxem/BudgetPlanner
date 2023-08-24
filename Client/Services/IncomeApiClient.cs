using System.Net.Http.Json;
using Client.Models;

namespace Client.Services;

public class IncomeApiClient
{

    private readonly HttpClient _httpClient;

    public IncomeApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<IncomeModel>?> GetAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/income");

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

    public async Task UpdateAsync(IncomeModel? item)
    {
        try
        {
            await _httpClient.PutAsJsonAsync($"/years/months/income/{item?.Id}", item);
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
            await _httpClient.DeleteAsync($"/years/months/income/{Id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
    }

    public async Task AddAsync(IncomeModel income)
    {
        try
        {
            await _httpClient.PostAsJsonAsync($"/years/months/income/", income);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
    }
}


using System.Net.Http.Json;
using Client.Models;

namespace Client.Services;

public class SavingsApiClient
{
    private readonly HttpClient _httpClient;

    public SavingsApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<SavingsModel>?> GetAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/savings");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<SavingsModel>>();

                return result;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
        return new List<SavingsModel>();
    }

    public async Task UpdateAsync(SavingsModel? item)
    {
        try
        {
            await _httpClient.PutAsJsonAsync($"/years/months/savings/{item?.Id}", item);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
    }

    public async Task DeleteAsync(int Id)
    {
        await _httpClient.DeleteAsync($"/years/months/savings/{Id}");
    }

    public async Task AddAsync(SavingsModel savings)
    {
        try
        {
            await _httpClient.PostAsJsonAsync($"/years/months/savings/", savings);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
    }
}

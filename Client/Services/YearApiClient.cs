using System.Net.Http.Json;
using Client.Models;

namespace Client.Services;

public class YearApiClient
{
    private readonly HttpClient _httpClient;

    public YearApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<YearModel>?> GetYearsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/years");

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

    public async Task DeleteYearByIdAsync(int id)
    {
        await _httpClient.DeleteAsync($"/years/{id}");
    }

    public async Task PostYearAsync(YearModel year)
    {
        await _httpClient.PostAsJsonAsync($"/years", year);
    }
}

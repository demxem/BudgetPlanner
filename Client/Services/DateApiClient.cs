using System.Net.Http.Json;
using Client.Models;

namespace Client.Services;

public class DateApiClient
{
    private readonly HttpClient httpClient;

    public DateApiClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<List<DateModel>?> GetAsync()
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

}


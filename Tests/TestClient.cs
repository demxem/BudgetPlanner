using Client.Models;
using Client.Services;
namespace Tests;

public class TestClient
{
    [Fact]
    public async void TestDatePicker_Return_MonthId_YearId()
    {
        //Set
        var datePicker = new DatePicker();
        var apiBaseAddress = "http://localhost:5555";
        var yearApiClient = new YearApiClient(new HttpClient { BaseAddress = new Uri(apiBaseAddress) });
        var monthApiClient = new MonthsApiClient(new HttpClient { BaseAddress = new Uri(apiBaseAddress) });

        //Action
        IEnumerable<YearModel> years = await yearApiClient.GetYearsAsync();
        IEnumerable<BudgetModel> months = await monthApiClient.GetMonthsAsync();

        DateTime? date = new DateTime(2023, 07, 20);

        var monthIdResult = datePicker.FindMonthId(date, years, months);
        var yearIdResult = datePicker.FindYearId(date, years, months);

        //Assert
        Assert.Equal(16, monthIdResult);
        Assert.Equal(17, yearIdResult);
        Assert.NotNull(monthIdResult);
        Assert.NotNull(yearIdResult);
    }


}
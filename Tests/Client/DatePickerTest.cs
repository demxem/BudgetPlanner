using Client.Models;
using Client.Services;

namespace Tests;

public class TestDatePicker
{
    [Fact]
    public async void TestDatePicker_Return_MonthId_YearId()
    {
      
        var datePicker = new DatePicker();
        var apiBaseAddress = "http://localhost:5555";
        var yearApiClient = new YearApiClient(new HttpClient { BaseAddress = new Uri(apiBaseAddress) });
        var monthApiClient = new BudgetApiClient(new HttpClient { BaseAddress = new Uri(apiBaseAddress) });

        //Action
        IEnumerable<YearModel>? years = await yearApiClient.GetYearsAsync();
        IEnumerable<BudgetModel>? months = await monthApiClient.GetMonthsAsync();

        DateTime? date = new DateTime(2005, 01, 10);

        var monthIdResult = datePicker.GetMonthId(date, years!, months!);
        var yearIdResult = datePicker.GetYearId(date, years!, months!);

        //Assert
        Assert.Equal(16, monthIdResult);
        Assert.Equal(17, yearIdResult);
    }
}
using Client.Models;
using Client.Services;
using Microsoft.AspNetCore.Components;

namespace Tests;

public class TestDatePicker
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
        IEnumerable<YearModel>? years = await yearApiClient.GetYearsAsync();
        IEnumerable<BudgetModel>? months = await monthApiClient.GetMonthsAsync();

        DateTime? date = new DateTime(2023, 07, 20);

        var monthIdResult = datePicker.FindMonthId(date, years!, months!);
        var yearIdResult = datePicker.FindYearId(date, years!, months!);

        //Assert
        Assert.Equal(16, monthIdResult);
        Assert.Equal(17, yearIdResult);
    }
    [Fact]
    public async void TestDatePickerParser_Return_MonthId_YearId()
    {
        //Set
        var datePicker = new DatePicker();
        var apiBaseAddress = "http://localhost:5555";
        var yearApiClient = new YearApiClient(new HttpClient { BaseAddress = new Uri(apiBaseAddress) });
        var monthApiClient = new MonthsApiClient(new HttpClient { BaseAddress = new Uri(apiBaseAddress) });

        //Action
        IEnumerable<YearModel>? years = await yearApiClient.GetYearsAsync();
        IEnumerable<BudgetModel>? months = await monthApiClient.GetMonthsAsync();

        datePicker.Date = "August 12, 2023";

        var yearIdResult = datePicker.FindYearIdByParsedDate(years!, months!);
        var monthIdResult = datePicker.FindMonthIdByParsedDate(years!, months!);

        //Assert
        Assert.Equal(40, yearIdResult);
        Assert.Equal(171, monthIdResult);
    }

    [Fact]
    public async void DatePicker_Pareser_Return_ProperValue()
    {
        DatePicker datePicker = new DatePicker();
        var apiBaseAddress = "http://localhost:5555";
        var yearApiClient = new YearApiClient(new HttpClient { BaseAddress = new Uri(apiBaseAddress) });
        List<YearModel>? years = await yearApiClient.GetYearsAsync();

        ChangeEventArgs userInput = new ChangeEventArgs { Value = "1jan2025" };
        string result = "January 01, 2023";
        datePicker.ParseDate(userInput, years!);
        Assert.Equal(result, datePicker.Date);
    }
}
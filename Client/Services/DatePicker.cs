using System.Globalization;
using Client.Models;
using Microsoft.AspNetCore.Components;

namespace Client.Services;

public class DatePicker
{

    public DateTime? MinimalPeriodInterval;
    public DateTime? MaximumPeriodInteval;
    public string MinDashboardDate = "";
    public string MaxDashboardDate = "";
    public string DashBoardSelectedMonth = "";
    public string Date = "";

    public void ParseDate(ChangeEventArgs e)
    {
        var userInputDate = e.Value.ToString();
        DateTime date;
        var result = DateTime.TryParse(userInputDate, out date);
        if (result == true)
        {
            Date = date.ToString("MMMM dd, yyyy");
        }
        else
        {
            Date = DateTime.Now.ToString("MMMM dd, yyyy");
        }
    }

    public DateTime GetDate()
    {
        DateTime date;
        var result = DateTime.TryParse(Date, out date);
        if (result == true)
        {
            return date;
        }
        return date;
    }

    public int FindYearId(DateTime? selectedDate, IEnumerable<YearModel> years, IEnumerable<BudgetModel> months)
    {
        string year = selectedDate.Value.Year.ToString();
        int yearid = years.Where(y => y.Name.Equals(year)).Select(y => y.Id).FirstOrDefault();

        return yearid;
    }

    public void SetDashboardIntervals(DateTime? selectedDate)
    {
        var monthYear = selectedDate.Value.ToString(new CultureInfo("en-US").DateTimeFormat.YearMonthPattern);
        string[] splitDate = monthYear.Split(" ");
        DashBoardSelectedMonth = splitDate[0].Replace(" ", "");

        var date = selectedDate.Value.Date;
        int year = date.Year;
        int month = date.Month;

        var DashBoardMinimalInterval = new DateTime(year, month, 1);
        var DashBoardMaximumInterval = new DateTime(year, month, 12);

        MinDashboardDate = DashBoardMinimalInterval.ToString(new CultureInfo("en-US").DateTimeFormat.YearMonthPattern) + " , 01";
        MaxDashboardDate = DashBoardMaximumInterval.ToString(new CultureInfo("en-US").DateTimeFormat.YearMonthPattern) + " , 31";
    }

    public int FindMonthId(DateTime? selectedDate, IEnumerable<YearModel> years, IEnumerable<BudgetModel> months)
    {

        string date = selectedDate.Value.ToString(new CultureInfo("en-US").DateTimeFormat.YearMonthPattern);
        string[] splitDate = date.Split(" ");
        string year = splitDate[1].Replace(" ", "");
        string month = splitDate[0].Replace(" ", "");

        int yearid = years.Where(y => y.Name.Equals(year)).Select(y => y.Id).FirstOrDefault();
        int monthId = months.Where(m => m.YearId == yearid && m.Name.Equals(month)).Select(m => m.Id).FirstOrDefault();

        return monthId;
    }

    public void SetMinAndMaxYearPeriodForCalendar(IEnumerable<YearModel> Years)
    {
        int minYear = Int32.Parse(Years.Select(year => year.Name).FirstOrDefault());
        MinimalPeriodInterval = new DateTime(minYear, 01, 01);

        int maxYear = Int32.Parse(Years.Select(year => year.Name).LastOrDefault());
        MaximumPeriodInteval = new DateTime(maxYear, 12, 31);
    }
}

using System.Globalization;
using Client.Models;

namespace Client.Services;

public class DatePicker
{
    public DateTime? MinPeriodInterval;
    public DateTime? MaxPeriodInteval;
    public string MinDashboardDate = "";
    public string MaxDashboardDate = "";
    public string DashBoardSelectedMonth = "";
    public string SelectedDate = "";
    public int DaysInMonth = 1;

    public int GetYearId(DateTime? selectedDate, IEnumerable<YearModel> years, IEnumerable<BudgetModel> months)
    {
        string year = selectedDate!.Value.Year.ToString();
        int yearid = years
                        .Where(y => y.Name!.Equals(year))
                        .Select(y => y.Id)
                        .FirstOrDefault();

        return yearid;
    }

    public void SetInterval(DateTime? selectedDate)
    {
        var formatedDate = selectedDate!.Value.ToString(new CultureInfo("en-US").DateTimeFormat.YearMonthPattern);
        string[] splitDate = formatedDate.Split(" ");
        DashBoardSelectedMonth = splitDate[0].Replace(" ", "");

        var date = selectedDate.Value.Date;
        int year = date.Year;
        int month = date.Month;

        var minDashboardDate = new DateTime(year, month, 1);
        var maxDashboardDate = new DateTime(year, month, 12);

        MinDashboardDate = minDashboardDate.ToString(new CultureInfo("en-US").DateTimeFormat.YearMonthPattern) + " , 01";
        MaxDashboardDate = maxDashboardDate.ToString(new CultureInfo("en-US").DateTimeFormat.YearMonthPattern) + " , 31";
    }

    public int GetMonthId(DateTime? selectedDate, IEnumerable<YearModel> years, IEnumerable<BudgetModel> months)
    {
        string formatedDate = selectedDate!.Value.ToString(new CultureInfo("en-US").DateTimeFormat.YearMonthPattern);
        string[] splitDate = formatedDate.Split(" ");
        string year = splitDate[1].Replace(" ", "");
        string month = splitDate[0].Replace(" ", "");

        int yearid = years
                        .Where(y => y.Name!.Equals(year))
                        .Select(y => y.Id)
                        .FirstOrDefault();

        int monthId = months
                        .Where(m => m.YearId == yearid && m.Name!.Equals(month))
                        .Select(m => m.Id)
                        .FirstOrDefault();

        return monthId;
    }

    public void SetMinAndMaxYearPeriodForCalendar(IEnumerable<YearModel> Years)
    {
        int minYear = Int32.Parse(Years.Select(year => year.Name).FirstOrDefault()!);
        MinPeriodInterval = new DateTime(minYear, 01, 01);

        int maxYear = Int32.Parse(Years.Select(year => year.Name).LastOrDefault()!);
        MaxPeriodInteval = new DateTime(maxYear, 12, 31);
    }
}

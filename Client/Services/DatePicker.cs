using System.Globalization;
using Client.Models;

namespace Client.Services;

public class DatePicker
{

    public DateTime? MinimalPeriodInterval;
    public DateTime? MaximumPeriodInteval;
    public int FindYearId(DateTime? selectedDate, IEnumerable<YearModel> years, IEnumerable<BudgetModel> months)
    {
        string year = selectedDate.Value.Year.ToString();
        int yearid = years.Where(y => y.Name.Equals(year)).Select(y => y.Id).FirstOrDefault();

        return yearid;
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

namespace DAL.Models;

public class YearsModel
{
    public int YearId { get; set; }
    public DateTime Date { get; set; }
    public IList<MonthsModel> Months { get; set; } = new List<MonthsModel>();
}
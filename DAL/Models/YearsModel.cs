namespace DAL.Models;

public class YearsModel
{
    public int Id { get; set; }
    public IList<MonthModel> Months { get; set; } = new List<MonthModel>();
}
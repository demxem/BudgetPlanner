namespace Client.Models;

public class YearModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public IList<MonthModel>? Months { get; set; } = new List<MonthModel>();
}
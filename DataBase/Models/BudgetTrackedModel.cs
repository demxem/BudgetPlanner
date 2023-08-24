namespace DataBase.Models;

public class BudgetTrackedModel
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; } = "";
    public string Category { get; set; } = "";
    public decimal Amount { get; set; }
    public string Details { get; set; } = "";
    public decimal Balance { get; set; }
    public decimal Tracked { get; set; }
    public int MonthId { get; set; }
    public int YearId { get; set; }
}

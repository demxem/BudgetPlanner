namespace DAL.Models;

public class MonthsModel
{
    public int MonthId { get; set; }
    public string? Name { get; set; }
    public SavingsModel? Savings { get; set; }
    public ExpensesModel? Expanses { get; set; }
    public IncomeModel? Income { get; set; }
    public DateTime Date { get; set; }
}
namespace Client.Models;

public class MonthModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public double MonthlyIncome { get; set; }
    public double MonthlySavings { get; set; }
    public double MonthlyExpenses { get; set; }
    public SavingsModel? Savings { get; set; }
    public ExpensesModel? Expenses { get; set; }
    public IncomeModel? Income { get; set; }
    public int YearId { get; set; }
}
namespace DAL.Models;

public class MonthModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public float MonthlyExpenses { get; set; }
    public float MonthlySavings { get; set; }
    public float MonthlyIncome { get; set; }
    public SavingsModel? Savings { get; set; }
    public ExpensesModel? Expenses { get; set; }
    public IncomeModel? Income { get; set; }

}
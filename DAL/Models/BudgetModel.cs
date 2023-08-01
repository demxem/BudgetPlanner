namespace DAL.Models;

public class BudgetModel
{
    public int Id { get; set; }
    public int IncomeId { get; set; }
    public int SavingsId { get; set; }
    public int ExpensesId { get; set; }
    public int YearId { get; set; }
    public string? Name { get; set; }
    public decimal MonthlyExpenses { get; set; }
    public decimal MonthlySavings { get; set; }
    public decimal MonthlyIncome { get; set; }
    public decimal TrackedMonthlyIncome { get; set; }
    public decimal TrackedMonthlySavings { get; set; }
    public decimal TrackedMonthlyExpenses { get; set; }
    public SavingsModel? Savings { get; set; }
    public ExpensesModel? Expenses { get; set; }
    public IncomeModel? Income { get; set; }
    public DateTime Date { get; set; }
}
namespace DAL.Data;

public interface ICalculations
{
    Task<decimal> GetMonthlyExpenses(int Id);
    Task<decimal> GetMonthlyIncome(int Id);
    Task<decimal> GetMonthlySavings(int Id);
    Task<decimal> GetYearlyExpenses(int Id);
    Task<decimal> GetYearlyIncome(int Id);
    Task<decimal> GetYearlySavings(int Id);
    Task<decimal> GetYearlyUndistributedIncome(int Id);
    Task<decimal> GetMonthlyUndistributedIncome(int Id);


}

namespace DAL.Data;

public interface ICalculations
{
    Task<float> GetMonthlyExpenses(int Id);
    Task<float> GetMonthlyIncome(int Id);
    Task<float> GetMonthlySavings(int Id);
    Task<float> GetYearlyExpenses(int Id);
    Task<float> GetYearlyIncome(int Id);
    Task<float> GetYearlySavings(int Id);
    Task<float> GetYearlyUndistributedIncome(int Id);
    Task<float> GetMonthlyUndistributedIncome(int Id);


}

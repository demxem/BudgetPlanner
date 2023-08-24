using DataBase.Models;

namespace DataBase.Data;

public interface IBudget
{
    Task<IEnumerable<BudgetModel>> GetMonths();
    Task<IEnumerable<BudgetModel>> GetIncome();
    Task<IEnumerable<BudgetModel>> Get();
    Task<IEnumerable<BudgetModel>> GetSavings();
    Task<IEnumerable<BudgetModel>> GetExpenses();
    Task<IEnumerable<BudgetModel?>> GetIncomeByYearId(int id);
    Task<BudgetModel?> GetIncomeByMonthId(int id);
    Task<IEnumerable<BudgetModel>> GetSavingsByYearId(int id);
    Task<BudgetModel> GetSavingsByMonthId(int id);
    Task<IEnumerable<BudgetModel?>> GetBudgetExpensesByYearId(int id);
    Task<BudgetModel> GetExpensesByMonthId(int id);
    Task<IEnumerable<BudgetModel?>> GetMonthByYearId(int id);
    Task<IEnumerable<BudgetModel>> GetSavingsById(int id);
    Task<IEnumerable<BudgetModel>> GetByMonthId(int id);
    Task<IEnumerable<BudgetModel>> GetByYearId(int id);

    Task AddMonth(BudgetModel month);
    Task DeleteMonthById(int id);
    Task UpdateMonth(BudgetModel month);
}
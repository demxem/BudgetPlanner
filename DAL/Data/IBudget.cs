using DAL.Models;

namespace DAL.ComplexData;

public interface IBudget
{
    Task<IEnumerable<BudgetModel>> GetAllByMonthId(int id);
    Task<IEnumerable<BudgetModel>> GetAllMonths();
    Task<IEnumerable<BudgetModel?>> GetMonthByYearId(int id);
    Task<IEnumerable<BudgetModel>> GetSavingsByid(int id);
    Task<IEnumerable<BudgetModel>> GetIncomeByMonth();
    Task<IEnumerable<BudgetModel>> GetSavingsByMonth();
    Task<IEnumerable<BudgetModel>> GetExpensesByMonth();
    Task DeleteMonthById(int id);
    Task InsertMonth(BudgetModel month);
    Task InsertIncomeByYearId(BudgetModel month);
    Task<IEnumerable<BudgetModel?>> GetIncomeByYearId(int id);
    Task<IEnumerable<BudgetModel?>> GetExpensesByYearId(int id);
    Task<IEnumerable<BudgetModel>> GetSavingsByYearId(int id);
    Task<BudgetModel?> GetIncomeByMonthId(int id);
    Task<BudgetModel> GetSavingsByMonthId(int id);
    Task<BudgetModel> GetExpensesByMonthId(int id);
    Task UpdateMonth(BudgetModel month);
    Task<IEnumerable<BudgetModel>> GetBudget();
    Task<IEnumerable<BudgetModel>?> GetCompletedBudgetByYearId(int id);
}


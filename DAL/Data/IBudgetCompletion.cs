using DAL.Models;

namespace DAL.Data;

public interface IBudgetCompletion
{
    Task<IEnumerable<BudgetCompletionModel?>> GetBudgetCompletionByYearId(int id);
    Task<BudgetCompletionModel?> GetBudgetCompletionByMonthId(int id);
    Task<BudgetCompletionModel?> GetBudgetCompletionByMonthIdInPercent(int id);
}

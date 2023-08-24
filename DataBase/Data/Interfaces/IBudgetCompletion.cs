using DataBase.Models;

namespace DataBase.Data;

public interface IBudgetCompletion
{
    Task<IEnumerable<BudgetCompletionModel?>> GetByYearId(int id);
    Task<BudgetCompletionModel?> GetByMonthId(int id);
    Task<BudgetCompletionModel?> GetPercentByMonthId(int id);
}

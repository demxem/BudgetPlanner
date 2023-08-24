using DataBase.Models;

namespace DataBase.Data;

public interface IBudgetTracked
{
    Task<IEnumerable<BudgetTrackedModel>> Get();
    Task<IEnumerable<BudgetTrackedModel>> GetByMonthId(int id);
    Task Add(BudgetTrackedModel budget);
    Task Update(BudgetTrackedModel budget);
    Task Delete(int id);
}


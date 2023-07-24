using DAL.Models;

namespace DAL.Data;

public interface IBudget
{
    Task DeleteBudgetById(int id);
    Task<IEnumerable<BudgetModel>> GetBudget();
    Task InsertBudget(BudgetModel budget);
    Task UpdateBudget(BudgetModel budget);
}


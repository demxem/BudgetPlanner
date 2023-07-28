using DAL.Models;

namespace DAL.Data;

public interface IDetailedBudget
{
    Task DeleteBudgetById(int id);
    Task<IEnumerable<DetailedBudgetModel>> GetBudget();
    Task InsertBudget(DetailedBudgetModel budget);
    Task UpdateBudget(DetailedBudgetModel budget);
}


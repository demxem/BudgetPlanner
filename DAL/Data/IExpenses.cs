using DAL.Models;

namespace DAL.Data;

public interface IExpenses
{
    Task DeleteExpenses(int id);
    Task<IEnumerable<ExpensesModel>> GetExpenses();
    Task<ExpensesModel?> GetExpensesById(int id);
    Task InsertExpenses(ExpensesModel expenses);
    Task UpdateExpenses(ExpensesModel expenses);
}

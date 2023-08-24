using DataBase.Models;

namespace DataBase.Data;

public interface IExpenses
{
    Task<IEnumerable<ExpensesModel>> Get();
    Task<ExpensesModel?> GetById(int id);
    Task Add(ExpensesModel expenses);
    Task Update(ExpensesModel expenses);
    Task Delete(int id);
}

using DataBase.Models;

namespace DataBase.Data;

public interface IIncome
{
    Task Delete(int id);
    Task<IEnumerable<IncomeModel>> Get();
    Task<IncomeModel?> GetById(int id);
    Task Add(IncomeModel income);
    Task Update(IncomeModel income);
}

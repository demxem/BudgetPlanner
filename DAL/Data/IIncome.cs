using DAL.Models;

namespace DAL.Data;

public interface IIncome
{
    Task DeleteIncomeById(int id);
    Task<IEnumerable<IncomeModel>> GetIncome();
    Task<IncomeModel?> GetIncomeById(int id);
    Task InsertIncome(IncomeModel income);
    Task UpdateIncomeById(IncomeModel income);
}

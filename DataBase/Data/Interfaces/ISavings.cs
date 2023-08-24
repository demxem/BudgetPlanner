using DataBase.Models;

namespace DataBase.Data;

public interface ISavings
{
    Task<IEnumerable<SavingsModel>> Get();
    Task<SavingsModel?> GetById(int id);
    Task Add(SavingsModel savings);
    Task Update(SavingsModel savings);
    Task Delete(int id);
}


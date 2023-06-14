using DAL.Models;

namespace DAL.Data;

public interface ISavings
{
    Task DeleteSavings(int id);
    Task<IEnumerable<SavingsModel>> GetSavings();
    Task<SavingsModel?> GetSavingsById(int id);
    Task InsertSavings(SavingsModel savings);
    Task UpdateSavings(SavingsModel savings);
}


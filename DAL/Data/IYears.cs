using DAL.Models;

namespace DAL.Data;

public interface IYears
{
    Task<IEnumerable<YearModel>> GetYears();
    Task<YearModel?> GetYearById(int id);
    Task InsertYear(YearModel year);
    Task DeleteYearById(int id);
}

using DAL.Models;

namespace DAL.ComplexData;

public interface IYears
{
    Task<IEnumerable<YearModel>> GetYears();
    Task<YearModel?> GetYearById(int id);
    Task InsertYear(YearModel year);
    Task DeleteYearById(int id);
}

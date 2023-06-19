using DAL.Models;

namespace DAL.ComplexData;

public interface IYears
{
    Task<IEnumerable<YearModel>> Get();
    Task<YearModel?> GetYearById(int id);
}

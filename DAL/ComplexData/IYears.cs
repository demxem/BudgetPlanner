using DAL.Models;

namespace DAL.ComplexData;

public interface IYears
{
    Task<IEnumerable<YearModel>> GetAll();
    Task<YearModel?> GetYearById(int id);
}

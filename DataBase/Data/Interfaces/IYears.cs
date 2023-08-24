using DataBase.Models;

namespace DataBase.Data;

public interface IYears
{
    Task<IEnumerable<YearModel>> Get();
    Task<YearModel?> GetById(int id);
    Task Add(YearModel year);
    Task Delete(int id);
}

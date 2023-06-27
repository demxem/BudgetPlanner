using DAL.Models;

namespace DAL.Data;
public interface IDate
{
    Task<IEnumerable<DateModel>> GetLatestDate();
}


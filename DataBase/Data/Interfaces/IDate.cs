using DataBase.Models;

namespace DataBase.Data;
public interface IDate
{
    Task<IEnumerable<DateModel>> Get();
}


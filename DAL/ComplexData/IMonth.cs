using DAL.Models;

namespace DAL.ComplexData;

public interface IMonth
{
    Task<IEnumerable<MonthModel>> GetAllByMonthId(int id);
    Task<IEnumerable<MonthModel>> GetAllMonths();
    Task<MonthModel?> GetMonthById(int id);
    Task<IEnumerable<MonthModel>> GetSavingsByid(int id);
    Task<IEnumerable<MonthModel>> GetTotalIncomeByMonthId(int id);
    Task<IEnumerable<MonthModel>> GetTotalSavingsByMonthId(int id);
    Task<IEnumerable<MonthModel>> GetTotalExpensesByMonthId(int id);
    Task InsertMonth(MonthModel month);

}


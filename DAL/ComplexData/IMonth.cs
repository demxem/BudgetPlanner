using DAL.Models;

namespace DAL.ComplexData;

public interface IMonth
{
    Task<IEnumerable<MonthModel>> GetAllByMonthId(int id);
    Task<IEnumerable<MonthModel>> GetAllMonths();
    Task<MonthModel?> GetMonthById(int id);
    Task<IEnumerable<MonthModel>> GetSavingsByid(int id);
    Task<IEnumerable<MonthModel>> GetIncomeByMonth();
    Task<IEnumerable<MonthModel>> GetSavingsByMonth();
    Task<IEnumerable<MonthModel>> GetExpensesByMonth();
    Task DeleteMonthById(int id);
    Task InsertMonth(MonthModel month);
    Task InsertIncomeByYearId(MonthModel month);
    Task<IEnumerable<MonthModel?>> GetIncomeByYearId(int id);
    Task<IEnumerable<MonthModel?>> GetExpensesByYearId(int id);
    Task<IEnumerable<MonthModel>> GetSavingsByYearId(int id);
    Task UpdateMonth(MonthModel month);
}


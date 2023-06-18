using DAL.DbAccess;
using DAL.Models;

namespace DAL.Data;

public class Income : IIncome
{
    private readonly IPgsqlAccess _dataAccess;

    public Income(IPgsqlAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public Task<IEnumerable<IncomeModel>> GetIncome()
    {
        string sql = @"select id,employment, sidehustle, dividends, date, monthid
                       from income;";

        return _dataAccess.LoadData<IncomeModel, dynamic>(sql, new { });
    }

    public async Task<IncomeModel?> GetIncomeById(int id)
    {
        string sql = @"select id,employment, sidehustle, dividends, date, monthid
                       from income where id = @id;";

        var result = await _dataAccess.LoadData<IncomeModel, dynamic>(sql, new { id = id });
        return result.FirstOrDefault();
    }

    public Task InsertIncome(IncomeModel income)
    {
        string sql = @"insert into income (employment, sidehustle, dividends, date, monthid)
                           values (@Employment, @SideHustle, @Dividends, @Date, (select id from months where id = (select max(id) from months)));";

        return _dataAccess.SafeData(sql, new { income.Employment, income.SideHustle, income.Dividends, Date = DateTime.Now, income.MonthId });
    }

    public async Task UpdateIncome(IncomeModel income)
    {
        string sql = @"update income
                       set employment = @Employment, 
                            sidehustle = @SideHustle,
                            dividends = @Dividends, 
                            date = @Date,
                            monthid = @MonthId
                        where id = @id;";

        await _dataAccess.SafeData(sql, new { income.Employment, income.SideHustle, income.Dividends, Date = DateTime.Now });
    }

    public async Task DeleteIncome(int id)
    {
        string sql = @"delete 
                       from income
                       where id = @id;";

        await _dataAccess.SafeData(sql, new { id = id });
    }
}

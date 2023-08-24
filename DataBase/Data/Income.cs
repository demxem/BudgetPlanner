using DataBase.Access;
using DataBase.Models;

namespace DataBase.Data;

public class Income : IIncome
{
    private readonly IPostgreSQL _dataAccess;

    public Income(IPostgreSQL dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public Task<IEnumerable<IncomeModel>> Get()
    {
        string sql = @"select id, employment, sidehustle, dividends, date, monthid, yearid
                       from income
                       order by id asc;";

        return _dataAccess.LoadData<IncomeModel, dynamic>(sql, new { });
    }

    public async Task<IncomeModel?> GetById(int id)
    {
        string sql = @"select id,employment, sidehustle, dividends, date, monthid, yearid
                       from income where id = @id;";

        var result = await _dataAccess.LoadData<IncomeModel, dynamic>(sql, new { id = id });
        return result.FirstOrDefault();
    }

    public Task Add(IncomeModel income)
    {
        string sql = @"insert into income (employment, sidehustle, dividends,trackedemployment, trackedsidehustle, trackeddividends, monthid, yearid, date)
                           values (@Employment, @SideHustle, @Dividends,@TrackedEmployment, @TrackedSideHustle, @TrackedDividends, @MonthId, @YearId, @Date);";

        return _dataAccess.SafeData(sql, new
        {
            income.Id,
            income.Employment,
            income.SideHustle,
            income.Dividends,
            income.TrackedEmployment,
            income.TrackedSideHustle,
            income.TrackedDividends,
            income.MonthId,
            income.YearId,
            Date = DateTime.Now
        });
    }

    public async Task Update(IncomeModel income)
    {
        income.Date = DateTime.Now;
        string sql = @"update income
                       set employment = @Employment, 
                            sidehustle = @SideHustle,
                            dividends = @Dividends, 
                            date = @Date,
                            yearid = @YearId,
                            monthid = @MonthId,
                            trackedemployment = @TrackedEmployment,
                            trackedsidehustle = @TrackedSideHustle,
                            trackeddividends = @TrackedDividends
                        where id = @Id;";

        await _dataAccess.SafeData(sql, income);
    }

    public async Task Delete(int id)
    {
        string sql = @" with delete_budget as 
                        (
                            delete from budget where monthid = (select monthid from income where id = @id) AND type='Income'
                        ), delete_income as 
                        (
                            delete from income where id = @id
                        ) update months
                            set incomeid = 0
                            where incomeid = @id;";

        await _dataAccess.SafeData(sql, new { id = id });
    }
}

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
        string sql = @"select incomeId,employment, sidehustle, dividends
                       from income;";

        return _dataAccess.LoadData<IncomeModel, dynamic>(sql, new { });
    }

    public async Task<IncomeModel?> GetIncomeById(int id)
    {
        string sql = @"select incomeId,employment, sidehustle, dividends
                       from income where incomeId = @IncomeId;";

        var result = await _dataAccess.LoadData<IncomeModel, dynamic>(sql, new { IncomeId = id });
        return result.FirstOrDefault();
    }

    public Task InsertIncome(IncomeModel income)
    {
        string sql = @"insert into income (employment, sidehustle, dividends)
                           values (@Employment, @SideHustle, @Dividends);";

        return _dataAccess.SafeData(sql, new { income.Employment, income.SideHustle, income.Dividends });
    }

    public async Task UpdateIncome(IncomeModel income)
    {
        string sql = @"update income
                       set employment = @Employment, 
                            sidehustle = @SideHustle,
                            dividends = @Dividends
                        where incomeId = @IncomeId;";

        await _dataAccess.SafeData(sql, income);
    }

    public async Task DeleteIncome(int id)
    {
        string sql = @"delete 
                       from income
                       where incomeId = @IncomeId;";

        await _dataAccess.SafeData(sql, new { IncomeId = id });
    }
}

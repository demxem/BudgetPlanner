using DAL.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DAL.ComplexData;

public class Years : IYears
{
    private readonly IConfiguration _config;

    public Years(IConfiguration config)
    {
        _config = config;
    }

    // public async Task<IEnumerable<YearModel>> Get()
    // {
    //     using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
    //     {
    //         string sql = @"select * from years as y
    //                 join months as m on y.id = m.yearid
    //                 join savings as s on m.savingsid = s.id
    //                 join income as i on m.incomeid = i.id
    //                 join expenses as e on m.expensesid = e.id;";

    //***Alternative SQL => should test if perfomance is better***/

    // string sql = @"select y.id, y.name, m.id, m.name,
    //         s.id, s.emergencyfund, s.retirementaccount, s.vacation, s.healthneeds, s.date, 
    //         i.id, i.employment, i.sidehustle, i.dividends, i.date, 
    //         e.id, e.housing, e.groceries, e.utilities, e.vacation, e.transportation, e.medicine, e.clothing, e.media, e.insuranses, e.date
    // from years as y
    // join months as m on m.yearid = y.id
    // join income as i on m.incomeid = i.monthid
    // join expenses as e on m.expensesid = e.monthid
    // join savings as s on m.savingsid = s.monthid
    // Group by y.id, m.id, e.id, i.id, s.id;";

    //     var result = await connection.QueryAsync<YearModel, MonthModel, SavingsModel, IncomeModel, ExpensesModel, YearModel>(sql,
    //     (years, months, savings, income, expenses) =>
    //     {
    //         months.Savings = savings;
    //         months.Income = income;
    //         months.Expenses = expenses;
    //         years.Months?.Add(months);
    //         return years;
    //     });

    //     return result;
    // }
    // }
    public async Task<IEnumerable<YearModel?>> GetYears()
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select id, name 
                            from years
                            order by id;";

            var result = await connection.QueryAsync<YearModel>(sql);
            return result;
        }
    }

    public async Task<YearModel?> GetYearById(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select id, name 
                    from years 
                    where id = @id;";

            var result = await connection.QueryAsync<YearModel>(sql, new { Id = id });
            return result.FirstOrDefault();
        }
    }

    public async Task InsertYear(YearModel year)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"insert into years (id, name)
                            values ((select max(id) + 1 from years), @Name);";

            await connection.ExecuteAsync(sql, new { year.Name });
        }
    }

    public async Task DeleteYearById(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"with MonthsToDelete as (
                            delete from months
	                        where yearid = @id
                            ),
                            IncomeDeleted as (
                                delete from Income
                            where yearId = @id
                            ),
                            SavingsDeleted as (
                                delete from Savings
                            where yearId = @id

                            ),
                            ExpensesDeleted as (
                                delete from Expenses
                            where yearId = @id
                            )
                            delete from years
                            where id = @id;";

            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}

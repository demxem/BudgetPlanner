using DAL.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DAL.Data;

public class Years : IYears
{
    private readonly IConfiguration _config;

    public Years(IConfiguration config)
    {
        _config = config;
    }

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
            string sql = @"insert into years (name, date)
                            values (@Name, @Date);";

            await connection.ExecuteAsync(sql, new { year.Name, Date = DateTime.Now });
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

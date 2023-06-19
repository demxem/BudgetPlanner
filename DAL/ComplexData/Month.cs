using DAL.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DAL.ComplexData;

public class Month : IMonth
{
    private readonly IConfiguration _config;

    public Month(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<MonthModel>> GetAllMonths()
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select * 
                            from Month;";

            return await connection.QueryAsync<MonthModel>(sql, new { });
        }
    }

    public async Task<MonthModel?> GetMonthById(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select * 
                            from Month 
                            where id = @Id;";

            var result = await connection.QueryAsync<MonthModel>(sql, new { Id = id });
            return result.FirstOrDefault();
        }
    }

    public async Task<IEnumerable<MonthModel>> GetSavingsByid(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select * 
                            from months as m
                            join savings as s on m.id = s.id
                            where m.id = @Id;";

            var result = await connection.QueryAsync<MonthModel, SavingsModel, MonthModel>(sql, (month, savings) =>
            {
                month.Savings = savings;
                return month;
            }, new { Id = id });

            return result;
        }
    }

    public async Task<IEnumerable<MonthModel>> GetAllByMonthId(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select *  
                          from months as m
                            join savings as s on m.id = s.id
                            join expenses as e on m.id = e.id
                            join income as i on m.id = i.id
                            where m.id = @Id;";

            var result = await connection.QueryAsync<MonthModel, SavingsModel, ExpensesModel, IncomeModel, MonthModel>(sql, (month, savings, expenses, income) =>
            {
                month.Savings = savings;
                month.Expenses = expenses;
                month.Income = income;
                return month;
            }, new { Id = id });

            return result;
        }
    }

    public async Task<IEnumerable<MonthModel>> GetTotalIncomeByMonthId(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select sum (i.employment + i.sidehustle + i.dividends) as monthlyIncome
                            from income as i 
                            join months as m on m.incomeid = i.id
                            where m.id = @Id;";

            var result = await connection.QueryAsync<MonthModel>(sql, new { Id = id });

            return result;
        }
    }

    public async Task<IEnumerable<MonthModel>> GetTotalExpensesByMonthId(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select sum (e.housing + e.groceries + e.utilities + e.vacation 
                                        + e.transportation + e.medicine + e.clothing + e.media 
                                        + e.insuranses) as monthlyExpenses
                            from expenses as e 
                            join months as m on m.expensesid = e.id
                            where m.id = @Id;";

            var result = await connection.QueryAsync<MonthModel>(sql, new { Id = id });

            return result;
        }
    }

    public async Task<IEnumerable<MonthModel>> GetTotalSavingsByMonthId(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select sum (s.emergencyfund + s.retirementaccount + s.vacation + s.healthneeds) as monthlySavings
                            from savings as s
                            join months as m on m.savingsid = s.id
                            where m.id = @Id;";

            var result = await connection.QueryAsync<MonthModel>(sql, new { Id = id });

            return result;
        }
    }

    public async Task InsertMonth(MonthModel month)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            var sql = @"insert into months (id, name, yearid, incomeid, expensesid, savingsid)
                        values((select max(id) + 1 from months, @Name, @YearId, (select max(incomeid) + 1 from months), 
                        (select max(expensesid) + 1 from months), (select max(savingsid) + 1 from months));";

            await connection.ExecuteAsync(sql, new
            {
                month.Id,
                month.Name,
                month.MonthlyExpenses,
                month.MonthlyIncome,
                month.MonthlySavings,
                month.Expenses,
                month.Income,
                month.Savings
            });
        }
    }
}

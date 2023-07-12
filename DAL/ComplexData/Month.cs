using System;
using System.Data;
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
            string sql = @"select * from months 
                            order by date;";

            var result = await connection.QueryAsync<MonthModel>(sql);
            return result;
        }
    }

    public async Task<IEnumerable<MonthModel>> GetIncomeByMonth()
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select m.*, sum (i.employment + i.sidehustle + i.dividends) as monthlyIncome, i.* 
                            from months as m
                            join income as i on m.incomeid = i.id
                            group by m.id, i.id
                            order by m.date;";

            var result = await connection.QueryAsync<MonthModel, IncomeModel, MonthModel>(sql, (month, income) =>
            {
                month.Income = income;
                return month;
            });

            return result;
        }
    }
    public async Task<IEnumerable<MonthModel>> GetSavingsByMonth()
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select m.*, sum (s.emergencyfund + s.retirementaccount + s.vacation + s.healthneeds) as monthlySavings, s.* 
                            from months as m
                            join savings as s on m.savingsid = s.id
                            group by m.id, s.id
                            order by m.date;";

            var result = await connection.QueryAsync<MonthModel, SavingsModel, MonthModel>(sql, (month, savings) =>
            {
                month.Savings = savings;
                return month;
            });

            return result;
        }
    }

    public async Task InsertIncomeByYearId(MonthModel month)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"With insert As (
                            insert into months(id, name, yearid)
                            values((select max(id) + 1 from months), @Name, @YearId)
                            )
                            insert into income (id, monthid)
                            values ((select max(id) + 1 from income), (select max(id) from months)
                            );
                            update months
                            set incomeid = (select max(id) from income)
                            where id = (select max(id) from months);";

            await connection.ExecuteAsync(sql, new { month.Name, month.YearId });
        }
    }

    public async Task<IEnumerable<MonthModel>> GetExpensesByMonth()
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select m.*, sum (e.housing + e.groceries + e.utilities + e.vacation 
                                        + e.transportation + e.medicine + e.clothing + e.media 
                                        + e.insuranses) as monthlyExpenses, e.* 
                            from months as m
                            join expenses as e on m.expensesid = e.id
                            group by m.id, e.id
                            order by m.date;";

            var result = await connection.QueryAsync<MonthModel, ExpensesModel, MonthModel>(sql, (month, expenses) =>
            {
                month.Expenses = expenses;
                return month;
            });

            return result;
        }
    }

    public async Task<IEnumerable<MonthModel?>> GetIncomeByYearId(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select m.*, sum (i.employment + i.sidehustle + i.dividends) as monthlyIncome, i.* 
                            from months as m
                            join income as i on m.incomeid = i.id
                            where m.yearid = @YearId
                            group by m.id, i.id
                            order by m.date;";

            var result = await connection.QueryAsync<MonthModel, IncomeModel, MonthModel>(sql, (month, income) =>
            {
                month.Income = income;
                return month;
            }, new { YearId = id });

            return result;
        }
    }

    public async Task<IEnumerable<MonthModel>> GetSavingsByYearId(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select m.*, sum (s.emergencyfund + s.retirementaccount + s.vacation + s.healthneeds) as monthlySavings, s.* 
                            from months as m
                            join savings as s on m.savingsid = s.id
                            where m.yearid = @YearId
                            group by m.id, s.id
                            order by m.date;";

            var result = await connection.QueryAsync<MonthModel, SavingsModel, MonthModel>(sql, (month, savings) =>
            {
                month.Savings = savings;
                return month;
            }, new { YearId = id });

            return result;
        }
    }
    public async Task<IEnumerable<MonthModel?>> GetExpensesByYearId(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select m.*, sum (e.housing + e.groceries + e.utilities + e.vacation 
                                        + e.transportation + e.medicine + e.clothing + e.media 
                                        + e.insuranses) as monthlyExpenses, e.* 
                            from months as m
                            join expenses as e on m.expensesid = e.id
                            where m.yearid = @YearId
                            group by m.id, e.id
                            order by m.date;";

            var result = await connection.QueryAsync<MonthModel, ExpensesModel, MonthModel>(sql, (month, expenses) =>
                    {
                        month.Expenses = expenses;
                        return month;
                    }, new { YearId = id });

            return result;
        }
    }

    public async Task<MonthModel?> GetMonthById(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select * 
                            from months 
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

    public async Task InsertMonth(MonthModel month)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"insert into months(name, yearid, date)
                            values(@Name, @YearId, @Date);";

            await connection.ExecuteAsync(sql, new { month.Name, month.YearId, Date = DateTime.Now });
        }
    }
    public async Task UpdateMonth(MonthModel month)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            month.Date = DateTime.Now;
            string sql = @"update months
                            set name = @Name,
                                yearid = @YearId,
                                incomeid = @IncomeId,
                                savingsId = @SavingsId,
                                expensesId = @ExpensesId,
                                date = @Date
                            where id = @Id;";

            await connection.ExecuteAsync(sql, month);
        }
    }

    public async Task DeleteMonthById(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"delete from months
                            where id = @Id";

            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}


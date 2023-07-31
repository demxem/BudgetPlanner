
using DAL.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;



// this is the test class. Due to perfomance hit all the calculations implemented in these methods are made in Client side.//
//The class would be removed completely later//

namespace DAL.Data;

public class Calculations : ICalculations
{
    private readonly IConfiguration _config;

    public Calculations(IConfiguration config)
    {
        _config = config;
    }

    public async Task<float> GetYearlyIncome(int Id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select m.id, sum(i.employment + i.sidehustle + i.dividends) as monthlyIncome, i.id
                            from months as m
                            join income as i on m.incomeid = i.id
                            where m.yearid = @YearId
                            group by m.id, i.id
                            order by m.date;";

            var result = await connection.QueryAsync<BudgetModel, IncomeModel, BudgetModel>(sql, (months, income) =>
            {
                months.Income = income;
                return months;
            }, new { YearId = Id });

            var yearlyIncome = result.Select(x => x.MonthlyIncome).Sum();
            return yearlyIncome;
        }
    }

    public async Task<float> GetYearlySavings(int Id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select m.id, sum (s.emergencyfund + s.retirementaccount + s.vacation + s.healthneeds) as monthlySavings, s.id
                            from months as m
                            join savings as s on m.savingsid = s.id
                            where m.yearid = @YearId
                            group by m.id, s.id
                            order by m.date;";

            var result = await connection.QueryAsync<BudgetModel, SavingsModel, BudgetModel>(sql, (months, savings) =>
            {
                months.Savings = savings;
                return months;
            }, new { YearId = Id });

            var yearlySavings = result.Select(x => x.MonthlySavings).Sum();
            return yearlySavings;
        }
    }

    public async Task<float> GetYearlyExpenses(int Id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {

            string sql = @"select m.id, sum(e.housing + e.groceries + e.utilities + e.vacation 
                                        + e.transportation + e.medicine + e.clothing + e.media 
                                        + e.insuranses) as monthlyExpenses, e.id
                            from months as m
                            join expenses as e on m.expensesid = e.id
                            where m.yearid = @YearId
                            group by m.id, e.id
                            order by m.date;";

            var result = await connection.QueryAsync<BudgetModel, ExpensesModel, BudgetModel>(sql, (months, expenses) =>
            {
                months.Expenses = expenses;
                return months;
            }, new { YearId = Id });

            var yearlyExpenses = result.Select(x => x.MonthlyExpenses).Sum();
            return yearlyExpenses;
        }
    }

    public async Task<float> GetMonthlyIncome(int Id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select m.id, m.incomeid, sum(i.employment + i.sidehustle + i.dividends) as monthlyIncome, i.id
                            from months as m
                            join income as i on m.incomeid = i.id
                            where m.incomeid = @IncomeId
                            group by m.id, i.id
                            order by m.date;";

            var result = await connection.QueryAsync<BudgetModel, IncomeModel, BudgetModel>(sql, (month, income) =>
            {
                month.Income = income;
                return month;
            }, new { IncomeId = Id });

            return result.Select(income => income.MonthlyIncome).FirstOrDefault();
        }
    }
    public async Task<float> GetMonthlySavings(int Id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select m.id, m.savingsid, sum(s.emergencyfund + s.retirementaccount + s.vacation + s.healthneeds) as monthlySavings, s.id
                            from months as m
                            join savings as s on m.savingsid = s.id
                            where m.incomeid = @IncomeId
                            group by m.id, s.id
                            order by m.date;";

            var result = await connection.QueryAsync<BudgetModel, SavingsModel, BudgetModel>(sql, (month, savings) =>
            {
                month.Savings = savings;
                return month;
            }, new { SavingsId = Id });

            return result.Select(savings => savings.MonthlySavings).FirstOrDefault();
        }
    }
    public async Task<float> GetMonthlyExpenses(int Id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select m.id, m.expensesid, sum (e.housing + e.groceries + e.utilities + e.vacation 
                                        + e.transportation + e.medicine + e.clothing + e.media 
                                        + e.insuranses) as monthlyExpenses, e.id 
                            from months as m
                            join expenses as e on m.expensesid = e.id
                            where m.expensesid = @ExpensesId
                            group by m.id, e.id
                            order by m.date;";

            var result = await connection.QueryAsync<BudgetModel, ExpensesModel, BudgetModel>(sql, (month, expenses) =>
            {
                month.Expenses = expenses;
                return month;
            }, new { ExpensesId = Id });

            return result.Select(expenses => expenses.MonthlyExpenses).FirstOrDefault();
        }
    }

    public async Task<float> GetYearlyUndistributedIncome(int Id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select m.id, sum(i.employment + i.sidehustle + i.dividends) as monthlyIncome,
                                        sum (s.emergencyfund + s.retirementaccount + s.vacation + s.healthneeds) as monthlySavings, 
                                        sum (e.housing + e.groceries + e.utilities + e.vacation 
                                        + e.transportation + e.medicine + e.clothing + e.media 
                                        + e.insuranses) as monthlyExpenses, i.id, s.id, e.id 
                            from months as m
                            join income as i on m.incomeid = i.id
                            join savings as s on m.savingsid = s.id
                            join expenses as e on m.expensesid = e.id
                            where m.yearid = @YearId
                            group by m.id, i.id, s.id, e.id
                            order by m.date;";

            var result = await connection.QueryAsync<BudgetModel, IncomeModel, SavingsModel, ExpensesModel, BudgetModel>(sql, (months, income, savings, expenses) =>
            {
                months.Income = income;
                months.Savings = savings;
                months.Expenses = expenses;
                return months;
            }, new { YearId = Id });

            float yearlyIncome = result.Select(income => income.MonthlyIncome).Sum();
            float yearlySavings = result.Select(savings => savings.MonthlySavings).Sum();
            float yearlyExpenses = result.Select(expenses => expenses.MonthlyExpenses).Sum();
            float undistributedIncome = yearlyIncome - (yearlySavings + yearlyExpenses);

            return undistributedIncome;
        }
    }

    public async Task<float> GetMonthlyUndistributedIncome(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select m.id, sum(i.employment + i.sidehustle + i.dividends) as monthlyIncome,
                                        sum (s.emergencyfund + s.retirementaccount + s.vacation + s.healthneeds) as monthlySavings, 
                                        sum (e.housing + e.groceries + e.utilities + e.vacation 
                                        + e.transportation + e.medicine + e.clothing + e.media 
                                        + e.insuranses) as monthlyExpenses, i.id, s.id, e.id 
                            from months as m
                            full outer join income as i on m.incomeid = i.id
                            full outer join savings as s on m.savingsid = s.id
                            full outer join expenses as e on m.expensesid = e.id
                            where i.monthid = @id or s.monthid = @id or e.monthid = @id
                            group by m.id, i.id, s.id, e.id
                            order by m.date;";

            var result = await connection.QueryAsync<BudgetModel, IncomeModel, SavingsModel, ExpensesModel, BudgetModel>(sql, (months, income, savings, expenses) =>
            {
                months.Income = income;
                months.Savings = savings;
                months.Expenses = expenses;
                return months;
            }, new { Id = id });

            float monthlyIncome = result.Select(income => income.MonthlyIncome).FirstOrDefault();
            float monthlySavings = result.Select(savings => savings.MonthlySavings).FirstOrDefault();
            float monthlyExpenses = result.Select(expenses => expenses.MonthlyExpenses).FirstOrDefault();

            float undistributedMonthlyIncome = monthlyIncome - (monthlySavings + monthlyExpenses);

            return undistributedMonthlyIncome;
        }
    }

}

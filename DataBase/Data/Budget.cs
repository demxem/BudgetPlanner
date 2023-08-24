using DataBase.Access;
using DataBase.Models;

namespace DataBase.Data;

public class Budget : IBudget
{
    private readonly IPostgreSQL _dataAccess;

    public Budget(IPostgreSQL dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<IEnumerable<BudgetModel>> GetMonths()
    {
        string sql = @"select * from months 
                            order by number Asc;";

        var result = await _dataAccess.LoadData<BudgetModel, dynamic>(sql, new { });
        return result;
    }

    public async Task<IEnumerable<BudgetModel>> GetIncome()
    {
        string sql = @"select m.*, sum (i.employment + i.sidehustle + i.dividends) as monthlyIncome, 
                            sum (i.trackedemployment + i.trackedsidehustle + i.trackeddividends) as TrackedMonthlyIncome, i.* 
                            from months as m
                            join income as i on m.incomeid = i.id
                            group by m.id, i.id
                            order by m.date;";

        var result = await _dataAccess.LoadData<BudgetModel, IncomeModel, BudgetModel, dynamic>(sql, (month, income) =>
        {
            month.Income = income;
            return month;
        }, new { });

        return result;
    }

    public async Task<IEnumerable<BudgetModel>> Get()
    {
        string sql = @"select m.*, sum(i.employment + i.sidehustle + i.dividends) as monthlyIncome,
                                        sum (s.emergencyfund + s.retirementaccount + s.vacation + s.healthneeds) as monthlySavings, 
                                        sum (e.housing + e.groceries + e.utilities + e.vacation 
                                        + e.transportation + e.medicine + e.clothing + e.media 
                                        + e.insuranses) as monthlyExpenses, i.*, s.*, e.* 
                            from months as m
                            full outer join income as i on m.incomeid = i.id
                            full outer join savings as s on m.savingsid = s.id
                            full outer join expenses as e on m.expensesid = e.id
                            group by m.id, i.id, s.id, e.id
                            order by m.date;";

        var result = await _dataAccess.LoadData<BudgetModel, IncomeModel, SavingsModel, ExpensesModel, BudgetModel, dynamic>(sql, (month, income, savings, expenses) =>
        {
            month.Income = income;
            month.Savings = savings;
            month.Expenses = expenses;
            return month;
        }, new { });

        return result;
    }
    public async Task<IEnumerable<BudgetModel>> GetByMonthId(int id)
    {
        string sql = @"select m.*, sum(i.employment + i.sidehustle + i.dividends) as monthlyIncome,
                                        sum (s.emergencyfund + s.retirementaccount + s.vacation + s.healthneeds) as monthlySavings, 
                                        sum (e.housing + e.groceries + e.utilities + e.vacation 
                                        + e.transportation + e.medicine + e.clothing + e.media 
                                        + e.insuranses) as monthlyExpenses, i.*, s.*, e.* 
                            from months as m
                            full outer join income as i on m.incomeid = i.id
                            full outer join savings as s on m.savingsid = s.id
                            full outer join expenses as e on m.expensesid = e.id
                            where i.monthid = @MonthId and s.monthid = @MonthId and e.monthid = @MonthId
                            group by m.id, i.id, s.id, e.id
                            order by m.date;";

        var result = await _dataAccess.LoadData<BudgetModel, IncomeModel, SavingsModel, ExpensesModel, BudgetModel, dynamic>(sql, (month, income, savings, expenses) =>
        {
            month.Income = income;
            month.Savings = savings;
            month.Expenses = expenses;
            return month;
        }, new { MonthId = id });

        return result;
    }
    public async Task<IEnumerable<BudgetModel>> GetByYearId(int id)
    {
        string sql = @"select m.*, sum(i.employment + i.sidehustle + i.dividends) as monthlyIncome,
                                        sum (s.emergencyfund + s.retirementaccount + s.vacation + s.healthneeds) as monthlySavings, 
                                        sum (e.housing + e.groceries + e.utilities + e.vacation 
                                        + e.transportation + e.medicine + e.clothing + e.media 
                                        + e.insuranses) as monthlyExpenses, i.*, s.*, e.* 
                            from months as m
                            full outer join income as i on m.incomeid = i.id
                            full outer join savings as s on m.savingsid = s.id
                            full outer join expenses as e on m.expensesid = e.id
                            where i.yearid = @YearId and s.yearid = @YearId and e.yearid = @YearId
                            group by m.id, i.id, s.id, e.id
                            order by m.date;";

        var result = await _dataAccess.LoadData<BudgetModel, IncomeModel, SavingsModel, ExpensesModel, BudgetModel, dynamic>(sql, (month, income, savings, expenses) =>
        {
            month.Income = income;
            month.Savings = savings;
            month.Expenses = expenses;
            return month;
        }, new { YearId = id });

        return result;
    }

    public async Task<IEnumerable<BudgetModel>> GetSavings()
    {
        string sql = @"select m.*, sum (s.emergencyfund + s.retirementaccount + s.vacation + s.healthneeds) as monthlySavings, 
                            sum (s.trackedemergencyfund + s.trackedretirementaccount + s.trackedvacation + s.trackedhealthneeds) as TrackedMonthlySavings, s.* 
                            from months as m
                            join savings as s on m.savingsid = s.id
                            group by m.id, s.id
                            order by m.date;";

        var result = await _dataAccess.LoadData<BudgetModel, SavingsModel, BudgetModel, dynamic>(sql, (month, savings) =>
        {
            month.Savings = savings;
            return month;
        }, new { });

        return result;
    }

    public async Task<IEnumerable<BudgetModel>> GetExpenses()
    {
        string sql = @"select m.*, sum (e.housing + e.groceries + e.utilities + e.vacation 
                                        + e.transportation + e.medicine + e.clothing + e.media 
                                        + e.insuranses) as monthlyExpenses, 
                                        sum (e.trackedhousing + e.trackedgroceries + e.trackedutilities + e.vacation 
                                        + e.transportation + e.medicine + e.clothing + e.media 
                                        + e.insuranses) as TrackedMonthlyExpenses, e.* 
                            from months as m
                            join expenses as e on m.expensesid = e.id
                            group by m.id, e.id
                            order by m.date;";

        var result = await _dataAccess.LoadData<BudgetModel, ExpensesModel, BudgetModel, dynamic>(sql, (month, expenses) =>
        {
            month.Expenses = expenses;
            return month;
        }, new { });

        return result;
    }

    public async Task<IEnumerable<BudgetModel?>> GetIncomeByYearId(int id)
    {
        string sql = @"select m.*, sum (i.employment + i.sidehustle + i.dividends) as monthlyIncome, 
                            sum (i.trackedemployment + i.trackedsidehustle + i.trackeddividends) as TrackedMonthlyIncome, i.* 
                            from months as m
                            join income as i on m.incomeid = i.id
                            where m.yearid = @YearId
                            group by m.id, i.id
                            order by m.date;";

        var result = await _dataAccess.LoadData<BudgetModel, IncomeModel, BudgetModel, dynamic>(sql, (month, income) =>
        {
            month.Income = income;
            return month;
        }, new { YearId = id });

        return result;
    }

    public async Task<BudgetModel?> GetIncomeByMonthId(int id)
    {
        string sql = @"select m.*, sum (i.employment + i.sidehustle + i.dividends) as monthlyIncome,
                            sum (i.trackedemployment + i.trackedsidehustle + i.trackeddividends) as TrackedMonthlyIncome, i.* 
                            from months as m
                            join income as i on m.incomeid = i.id
                            where m.id = @MonthId
                            group by m.id, i.id
                            order by m.date;";

        var result = await _dataAccess.LoadData<BudgetModel, IncomeModel, BudgetModel, dynamic>(sql, (month, income) =>
        {
            month.Income = income;
            return month;
        }, new { MonthId = id });

        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<BudgetModel>> GetSavingsByYearId(int id)
    {
        string sql = @"select m.*, sum (s.emergencyfund + s.retirementaccount + s.vacation + s.healthneeds) as monthlySavings, 
                            sum (s.trackedemergencyfund + s.trackedretirementaccount + s.trackedvacation + s.trackedhealthneeds) as TrackedMonthlySavings, s.* 
                            from months as m
                            join savings as s on m.savingsid = s.id
                            where m.yearid = @YearId
                            group by m.id, s.id
                            order by m.date;";

        var result = await _dataAccess.LoadData<BudgetModel, SavingsModel, BudgetModel, dynamic>(sql, (month, savings) =>
        {
            month.Savings = savings;
            return month;
        }, new { YearId = id });

        return result;
    }

    public async Task<BudgetModel> GetSavingsByMonthId(int id)
    {
        string sql = @"select m.*, sum (s.emergencyfund + s.retirementaccount + s.vacation + s.healthneeds) as monthlySavings, 
                            sum (s.trackedemergencyfund + s.trackedretirementaccount + s.trackedvacation + s.trackedhealthneeds) as TrackedMonthlySavings, s.* 
                            from months as m
                            join savings as s on m.savingsid = s.id
                            where m.id = @MonthId
                            group by m.id, s.id
                            order by m.date;";

        var result = await _dataAccess.LoadData<BudgetModel, SavingsModel, BudgetModel, dynamic>(sql, (month, savings) =>
        {
            month.Savings = savings;
            return month;
        }, new { MonthId = id });

        return result.FirstOrDefault()!;
    }

    public async Task<IEnumerable<BudgetModel?>> GetBudgetExpensesByYearId(int id)
    {
        string sql = @"select m.*, sum (e.housing + e.groceries + e.utilities + e.vacation 
                                        + e.transportation + e.medicine + e.clothing + e.media 
                                        + e.insuranses) as monthlyExpenses, 
                                        sum (e.trackedhousing + e.trackedgroceries + e.trackedutilities + e.trackedvacation 
                                        + e.trackedtransportation + e.trackedmedicine + e.trackedclothing + e.trackedmedia 
                                        + e.trackedinsuranses) as TrackedMsonthlyExpenses, e.* 
                            from months as m
                            join expenses as e on m.expensesid = e.id
                            where m.yearid = @YearId
                            group by m.id, e.id
                            order by m.date;";

        var result = await _dataAccess.LoadData<BudgetModel, ExpensesModel, BudgetModel, dynamic>(sql, (month, expenses) =>
                {
                    month.Expenses = expenses;
                    return month;
                }, new { YearId = id });

        return result;
    }

    public async Task<BudgetModel> GetExpensesByMonthId(int id)
    {
        string sql = @"select m.*, sum (e.housing + e.groceries + e.utilities + e.vacation 
                                        + e.transportation + e.medicine + e.clothing + e.media 
                                        + e.insuranses) as monthlyExpenses,
                                        sum (e.trackedhousing + e.trackedgroceries + e.trackedutilities + e.trackedvacation 
                                        + e.trackedtransportation + e.trackedmedicine + e.trackedclothing + e.trackedmedia 
                                        + e.trackedinsuranses) as TrackedMonthlyExpenses, e.* 
                            from months as m
                            join expenses as e on m.expensesid = e.id
                            where m.id = @MonthId
                            group by m.id, e.id
                            order by m.date;";

        var result = await _dataAccess.LoadData<BudgetModel, ExpensesModel, BudgetModel, dynamic>(sql, (month, expenses) =>
        {
            month.Expenses = expenses;
            return month;
        }, new { MonthId = id });

        return result.FirstOrDefault()!;
    }

    public async Task<IEnumerable<BudgetModel?>> GetMonthByYearId(int id)
    {
        string sql = @"select * 
                            from months 
                            where yearid = @id;";

        var result = await _dataAccess.LoadData<BudgetModel, dynamic>(sql, new { YearId = id });
        return result;
    }

    public async Task<IEnumerable<BudgetModel>> GetSavingsById(int id)
    {
        string sql = @"select * 
                            from months as m
                            join savings as s on m.id = s.id
                            where m.id = @Id;";

        var result = await _dataAccess.LoadData<BudgetModel, SavingsModel, BudgetModel, dynamic>(sql, (month, savings) =>
        {
            month.Savings = savings;
            return month;
        }, new { Id = id });

        return result;
    }

    public async Task AddMonth(BudgetModel month)
    {
        string sql = @"insert into months(name, yearid, date)
                            values(@Name, @YearId, @Date);";

        await _dataAccess.SafeData(sql, new { month.Name, month.YearId, Date = DateTime.Now });
    }

    public async Task UpdateMonth(BudgetModel month)
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

        await _dataAccess.SafeData(sql, month);
    }

    public async Task DeleteMonthById(int id)
    {
        string sql = @"delete from months
                            where id = @Id";

        await _dataAccess.SafeData(sql, new { Id = id });
    }
}


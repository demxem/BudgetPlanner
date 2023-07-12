using System;
using DAL.DbAccess;
using DAL.Models;

namespace DAL.Data;

public class Expenses : IExpenses
{
    private readonly IPgsqlAccess _dataAccess;

    public Expenses(IPgsqlAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public Task<IEnumerable<ExpensesModel>> GetExpenses()
    {
        string sql = @"select id,housing, groceries,utilities,
                              vacation,transportation,medicine,
                              clothing,media,insuranses, date, monthid, yearId
                       from expenses
                       order by date;";

        return _dataAccess.LoadData<ExpensesModel, dynamic>(sql, new { });
    }

    public async Task<ExpensesModel?> GetExpensesById(int id)
    {
        string sql = @"select id,housing, groceries,utilities,
                                vacation,transportation,medicine,
                                clothing,media,insuranses, date, monthid
                       from expenses
                       where id = @id;";

        var result = await _dataAccess.LoadData<ExpensesModel, dynamic>(sql, new { id = id });
        return result.FirstOrDefault();
    }

    public Task InsertExpenses(ExpensesModel expenses)
    {
        string sql = @"insert into expenses (housing, groceries,utilities,
                                            vacation,transportation,medicine,
                                            clothing,media,insuranses, monthid, yearid)
                           values (@Housing, @Groceries, @Utilities, @Vacation,@Transportation,@Medicine,@Clothing,@Media,@Insuranses, @MonthId, @YearId);";

        return _dataAccess.SafeData(sql, new
        {
            expenses.Housing,
            expenses.Groceries,
            expenses.Utilities,
            expenses.Vacation,
            expenses.Transportation,
            expenses.Medicine,
            expenses.Clothing,
            expenses.Media,
            expenses.Insuranses,
            expenses.MonthId,
            expenses.YearId,
            Date = DateTime.Now
        });
    }

    public async Task UpdateExpenses(ExpensesModel expenses)
    {
        expenses.Date = DateTime.Now;
        string sql = @"update expenses
                       set housing = @Housing, 
                            groceries = @Groceries, 
                            utilities = @Utilities,
                            vacation = @Vacation,
                            transportation = @Transportation,
                            medicine = @Medicine,
                            clothing = @Clothing,
                            media = @Media,
                            insuranses = @insuranses,
                            date = @Date,
                            monthid = @MonthId,
                            yearid = @YearId
                        where id = @Id;";

        await _dataAccess.SafeData(sql, expenses);
    }

    public async Task DeleteExpenses(int id)
    {
        string sql = @"delete 
                       from expenses
                       where id = @id;
                    update months
                    set expensesid = 0
                    where expensesid = @id;";

        await _dataAccess.SafeData(sql, new { id = id });
    }
}
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
        string sql = @"SELECT id,housing, groceries,utilities,
                                vacation,transportation,medicine,
                                clothing,media,insurances, date
                    from expenses;";

        return _dataAccess.LoadData<ExpensesModel, dynamic>(sql, new { });
    }

    public async Task<ExpensesModel?> GetExpensesById(int id)
    {
        string sql = @"SELECT id,housing, groceries,utilities,
                                vacation,transportation,medicine,
                                clothing,media,insurances, date
                    from expenses
                    where id = @id;";

        var result = await _dataAccess.LoadData<ExpensesModel, dynamic>(sql, new { id = id });
        return result.FirstOrDefault();
    }

    public Task InsertExpenses(ExpensesModel expenses)
    {
        string sql = @"insert into expenses (housing, groceries,utilities,
                                            vacation,transportation,medicine,
                                            clothing,media,insurances, date)
                           values (@Housing, @Groceries, @Utilities, @Vacation,@Transportation,@Medicine,@Clothing,@Media,@Insuranses, @Date);";

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
            Date = DateTime.Now,
        });
    }

    public async Task UpdateExpenses(ExpensesModel expenses)
    {
        string sql = @"update expenses
                       set housing = @Housing, 
                            groceries = @Groceries, 
                            utilities = @Utilities,
                            vacation = @Vacation,
                            transportation = @Transportation,
                            medicine = @Medicine,
                            clothing = @Clothing,
                            media = @Media,
                            insurances = @Insurances,
                            date = @Date
                        where id = @id;";

        await _dataAccess.SafeData(sql, new
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
            Date = DateTime.Now,
        });
    }

    public async Task DeleteExpenses(int id)
    {
        string sql = @"delete 
                       from expenses
                       where id = @id;";

        await _dataAccess.SafeData(sql, new { id = id });
    }
}
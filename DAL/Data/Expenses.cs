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
        string sql = @"SELECT expensesid,housing, groceries,utilities,
                                vacation,transportation,medicine,
                                clothing,media,insurances
                    from expenses;";

        return _dataAccess.LoadData<ExpensesModel, dynamic>(sql, new { });
    }

    public async Task<ExpensesModel?> GetExpensesById(int id)
    {
        string sql = @"SELECT expensesid,housing, groceries,utilities,
                                vacation,transportation,medicine,
                                clothing,media,insurances
                    from expenses
                    where expensesid = @ExpensesId;";

        var result = await _dataAccess.LoadData<ExpensesModel, dynamic>(sql, new { expensesId = id });
        return result.FirstOrDefault();
    }

    public Task InsertExpenses(ExpensesModel expenses)
    {
        string sql = @"insert into expenses (housing, groceries,utilities,
                                            vacation,transportation,medicine,
                                            clothing,media,insurances)
                           values (@Housing, @Groceries, @Utilities, @Vacation,@Transportation,@Medicine,@Clothing,@Media,@Insuranses);";

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
            expenses.Insuranses
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
                            insurances = @Insurances
                        where expensesId = @ExpensesId;";

        await _dataAccess.SafeData(sql, expenses);
    }

    public async Task DeleteExpenses(int id)
    {
        string sql = @"delete 
                       from expenses
                       where expensesId = @ExpensesId;";

        await _dataAccess.SafeData(sql, new { ExpensesId = id });
    }
}
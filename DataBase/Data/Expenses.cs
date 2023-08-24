using DataBase.Access;
using DataBase.Models;

namespace DataBase.Data;

public class Expenses : IExpenses
{
    private readonly IPostgreSQL _dataAccess;

    public Expenses(IPostgreSQL dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public Task<IEnumerable<ExpensesModel>> Get()
    {
        string sql = @"select id,housing, groceries,utilities,
                              vacation,transportation,medicine,
                              clothing,media,insuranses, date, monthid, yearId
                       from expenses
                       order by id asc;";

        return _dataAccess.LoadData<ExpensesModel, dynamic>(sql, new { });
    }

    public async Task<ExpensesModel?> GetById(int id)
    {
        string sql = @"select id,housing, groceries,utilities,
                                vacation,transportation,medicine,
                                clothing,media,insuranses, date, monthid
                       from expenses
                       where id = @id;";

        var result = await _dataAccess.LoadData<ExpensesModel, dynamic>(sql, new { id = id });
        return result.FirstOrDefault();
    }

    public Task Add(ExpensesModel expenses)
    {
        string sql = @"insert into expenses (housing, groceries,utilities,
                                            vacation,transportation,medicine,
                                            clothing,media,insuranses,date,trackedhousing,trackedgroceries,trackedutilities,
                                            trackedvacation,trackedtransportation,trackedmedicine,
                                            trackedclothing,trackedmedia,trackedinsuranses, monthid, yearid)
                           values (@Housing, @Groceries, @Utilities, @Vacation,@Transportation,@Medicine,@Clothing,@Media,@Insuranses,@Date,@TrackedHousing, @TrackedGroceries, @TrackedUtilities, @TrackedVacation,@TrackedTransportation,@TrackedMedicine,@TrackedClothing,@TrackedMedia,@TrackedInsuranses, @MonthId, @YearId);";

        return _dataAccess.SafeData(sql, new
        {
            expenses.Id,
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
            expenses.TrackedHousing,
            expenses.TrackedGroceries,
            expenses.TrackedUtilities,
            expenses.TrackedVacation,
            expenses.TrackedTransportation,
            expenses.TrackedMedicine,
            expenses.TrackedClothing,
            expenses.TrackedMedia,
            expenses.TrackedInsuranses,
            expenses.MonthId,
            expenses.YearId
        });
    }

    public async Task Update(ExpensesModel expenses)
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
                            trackedhousing = @TrackedHousing, 
                            trackedgroceries = @TrackedGroceries, 
                            trackedutilities = @TrackedUtilities,
                            trackedvacation = @TrackedVacation,
                            trackedtransportation = @TrackedTransportation,
                            trackedmedicine = @TrackedMedicine,
                            trackedclothing = @TrackedClothing,
                            trackedmedia = @TrackedMedia,
                            trackedinsuranses = @TrackedInsuranses,
                            monthid = @MonthId,
                            yearid = @YearId
                        where id = @Id;";

        await _dataAccess.SafeData(sql, expenses);
    }

    public async Task Delete(int id)
    {
        string sql = @"with delete_expenses as
                        (
                            delete from budget where monthid = (select monthid from expenses where id = @id) AND type='Expenses'
                        ), delete_expeses as 
                        (
                            delete from expenses where id = @id
                        ) update months
                            set expensesid = 0
                        where expensesid = @id;";

        await _dataAccess.SafeData(sql, new { id = id });
    }
}
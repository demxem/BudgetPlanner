using DataBase.Access;
using DataBase.Models;

namespace DataBase.Data;

public class Years : IYears
{
    private readonly IPostgreSQL _dataAccess;

    public Years(IPostgreSQL dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<IEnumerable<YearModel>> Get()
    {
        string sql = @"select id, name 
                            from years
                            order by name;";

        var result = await _dataAccess.LoadData<YearModel, dynamic>(sql, new { });
        return result;
    }

    public async Task<YearModel?> GetById(int id)
    {
        string sql = @"select id, name 
                    from years 
                    where id = @id;";

        var result = await _dataAccess.LoadData<YearModel, dynamic>(sql, new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task Add(YearModel year)
    {
        string sql = @"insert into years (name, date)
                            values (@Name, @Date);
                            insert into months(name, yearid, date, number)
                            values('January', (select id from years where years.name = @Name), @Date, 1),
                            ('February', (select id from years where years.name = @Name), @Date, 2),
                            ('March', (select id from years where years.name = @Name), @Date, 3),
                            ('April', (select id from years where years.name = @Name), @Date, 4),
                            ('May', (select id from years where years.name = @Name), @Date, 5),
                            ('June', (select id from years where years.name = @Name), @Date, 6),
                            ('July', (select id from years where years.name = @Name), @Date, 7),
                            ('August', (select id from years where years.name = @Name), @Date, 8),
                            ('September', (select id from years where years.name = @Name), @Date, 9),
                            ('October', (select id from years where years.name = @Name), @Date, 10),
                            ('November', (select id from years where years.name = @Name), @Date, 11),
                            ('December', (select id from years where years.name = @Name), @Date, 12);";

        await _dataAccess.SafeData(sql, new { year.Name, Date = DateTime.Now });
    }

    public async Task Delete(int id)
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

        await _dataAccess.SafeData(sql, new { Id = id });
    }
}

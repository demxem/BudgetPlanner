using DataBase.Access;
using DataBase.Models;

namespace DataBase.Data;

public class Date : IDate
{
    private readonly IPostgreSQL _dataAccess;

    public Date(IPostgreSQL dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<IEnumerable<DateModel>> Get()
    {
        string sql = @"select max(max) as LatestDate from 
                            (
	                            select max(date) from savings 
	                            union
	                            select max(date) from expenses
	                            union 
	                            select max(date) from income
                                )as my_tab;";

        return await _dataAccess.LoadData<DateModel, dynamic>(sql, new { });
    }
}


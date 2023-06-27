using DAL.DbAccess;
using DAL.Models;

namespace DAL.Data;

public class Date : IDate
{
    private readonly IPgsqlAccess _dataAccess;

    public Date(IPgsqlAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<IEnumerable<DateModel>> GetLatestDate()
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


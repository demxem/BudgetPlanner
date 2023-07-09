﻿using DAL.DbAccess;
using DAL.Models;

namespace DAL.Data;

public class Savings : ISavings
{
    private readonly IPgsqlAccess _dataAccess;

    public Savings(IPgsqlAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public Task<IEnumerable<SavingsModel>> GetSavings()
    {
        string sql = @"select id,
                              emergencyfund, 
                              retirementaccount, 
                              vacation,
                              healthneeds,
                              monthid,
                              yearid
                    from savings;";

        return _dataAccess.LoadData<SavingsModel, dynamic>(sql, new { });
    }

    public async Task<SavingsModel?> GetSavingsById(int id)
    {
        string sql = @"select id,
                              emergencyfund , 
                              retirementaccount , 
                              vacation,
                              healthneeds, 
                              date,
                              monthid
                       from savings where Id = @Id;";

        var result = await _dataAccess.LoadData<SavingsModel, dynamic>(sql, new { Id = id });
        return result.FirstOrDefault();
    }

    public Task InsertSavings(SavingsModel savings)
    {
        string sql = @"insert into savings (id, emergencyfund, retirementaccount, vacation, healthneeds, date, monthid, yearid)
                           values ((select max(id) + 1 from savings), @EmergencyFund, @RetirementAccount, @Vacation, @HealthNeeds, @Date, @MonthId, @YearId);";

        return _dataAccess.SafeData(sql, new
        {
            savings.EmergencyFund,
            savings.RetirementAccount,
            savings.Vacation,
            savings.HealthNeeds,
            Date = DateTime.Now,
            savings.MonthId,
            savings.YearId
        });
    }

    public async Task UpdateSavings(SavingsModel savings)
    {
        savings.Date = DateTime.Now;

        string sql = @"update savings
                        set emergencyfund = @EmergencyFund, 
                            retirementaccount = @RetirementAccount, 
                            vacation = @Vacation,
                            healthneeds = @HealthNeeds, 
                            date = @Date,
                            monthid = @MonthId
                        where id = @Id;";

        await _dataAccess.SafeData(sql, savings);
    }

    public async Task DeleteSavings(int id)
    {
        string sql = @"delete 
                       from savings
                       where Id = @Id;";

        await _dataAccess.SafeData(sql, new { Id = id });
    }
}


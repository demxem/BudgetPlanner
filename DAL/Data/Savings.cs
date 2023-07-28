using DAL.DbAccess;
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
                    from savings
                    order by date;";

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
        string sql = @"insert into savings (emergencyfund, retirementaccount, vacation, healthneeds,trackedemergencyfund, trackedretirementaccount, trackedvacation, trackedhealthneeds, date, monthid, yearid)
                           values (@EmergencyFund, @RetirementAccount, @Vacation, @HealthNeeds,@TrackedEmergencyFund, @TrackedRetirementAccount, @TrackedVacation, @TrackedHealthNeeds @Date, @MonthId, @YearId);";

        return _dataAccess.SafeData(sql, new
        {
            savings.EmergencyFund,
            savings.RetirementAccount,
            savings.Vacation,
            savings.HealthNeeds,
            savings.TrackedEmergencyFund,
            savings.TrackedRetirementAccount,
            savings.TrackedVacation,
            savings.TrackedHealthNeeds,
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
                            trackedemergencyfund = @TrackedEmergencyFund, 
                            trackedretirementaccount = @TrackedRetirementAccount, 
                            trackedvacation = @TrackedVacation,
                            trackedhealthneeds = @TrackedHealthNeeds, 
                            date = @Date,
                            monthid = @MonthId,
                            yearid = @YearId
                        where id = @Id;";

        await _dataAccess.SafeData(sql, savings);
    }

    public async Task DeleteSavings(int id)
    {
        string sql = @"delete 
                       from savings
                       where Id = @Id;
                       update months
                        set savingsid = 0
                        where savingsid = @id;";

        await _dataAccess.SafeData(sql, new { Id = id });
    }
}


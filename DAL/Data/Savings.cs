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
        string sql = @"select d,
                              emergencyfund, 
                              retirementaccount, 
                              vacation,
                              healthneeds 
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
                              date
                       from savings where Id = @Id;";

        var result = await _dataAccess.LoadData<SavingsModel, dynamic>(sql, new { Id = id });
        return result.FirstOrDefault();
    }

    public Task InsertSavings(SavingsModel savings)
    {
        string sql = @"insert into savings (emergencyfund, retirementaccount, vacation, healthneeds, date)
                           values (@EmergencyFund, @RetirementAccount, @Vacation, @HealthNeeds, @Date);";

        return _dataAccess.SafeData(sql, new { savings.EmergencyFund, savings.RetirementAccount, savings.Vacation, savings.HealthNeeds, Date = DateTime.Now });
    }

    public async Task UpdateSavings(SavingsModel savings)
    {
        string sql = @"update savings
                       set emergencyfund = @EmergencyFund, 
                            retirementaccount = @RetirementAccount, 
                            vacation = @Vacation,
                            healthneeds = @HealthNeeds, 
                            date = @Date
                        where Id = @Id;";

        await _dataAccess.SafeData(sql, new { savings.EmergencyFund, savings.RetirementAccount, savings.Vacation, savings.HealthNeeds, Date = DateTime.Now });
    }

    public async Task DeleteSavings(int id)
    {
        string sql = @"delete 
                       from savings
                       where Id = @Id;";

        await _dataAccess.SafeData(sql, new { Id = id });
    }
}


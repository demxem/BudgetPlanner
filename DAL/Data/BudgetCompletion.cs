using DAL.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DAL.Data;

public class BudgetCompletion : IBudgetCompletion
{
    private IConfiguration _config;

    public BudgetCompletion(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<BudgetCompletionModel?>> GetBudgetCompletionByYearId(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select m.id as MonthId, m.yearid,
                            (i.employment - i.trackedemployment) as CompletedEmployment, 
                            (i.sidehustle - i.trackedsidehustle) as CompletedSidehustle, 
                            (i.dividends - i.trackeddividends) as CompletedDividends,
                            (e.housing - e.trackedhousing) as CompletedHousing,
                            (e.groceries - e.trackedgroceries) as CompletedGroceries, 
                            (e.utilities - e.trackedutilities) as CompletedUtilities,
                            (e.vacation - e.trackedvacation) as CompletedExpensesVacation,
                            (e.transportation - e.trackedtransportation) as CompletedTransportation,
                            (e.medicine - e.trackedmedicine) as CompletedMedicine,
                            (e.clothing - e.trackedclothing) as CompletedClothing,
                            (e.media - e.trackedmedia) as CompletedMedia,
                            (e.insuranses - e.trackedinsuranses) as CompletedInsuranses,
                            (s.emergencyfund - s.trackedemergencyfund) as CompletedEmergencyFund,
                            (s.retirementaccount - s.trackedretirementaccount) as CompletedRetirementAccount,
                            (s.vacation - s.trackedvacation) as CompletedSavingsVacation,
                            (s.healthneeds - s.trackedhealthneeds) as CompletedHealthNeeds 
                            from months as m
                            full outer join income as i on m.incomeid = i.id
                            full outer join savings as s on m.savingsid= s.id
                            full outer join expenses as e on m.expensesid = e.id
                            where m.yearid = @Id and employment is not null and housing is not null and emergencyfund is not null;";

            var result = await connection.QueryAsync<BudgetCompletionModel>(sql, new { Id = id });
            return result;
        }
    }

    public async Task<BudgetCompletionModel?> GetBudgetCompletionByMonthId(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select m.id as MonthId, m.yearid,
                            (i.employment - i.trackedemployment) as CompletedEmployment, 
                            (i.sidehustle - i.trackedsidehustle) as CompletedSidehustle, 
                            (i.dividends - i.trackeddividends) as CompletedDividends,
                            (e.housing - e.trackedhousing) as CompletedHousing,
                            (e.groceries - e.trackedgroceries) as CompletedGroceries, 
                            (e.utilities - e.trackedutilities) as CompletedUtilities,
                            (e.vacation - e.trackedvacation) as CompletedExpensesVacation,
                            (e.transportation - e.trackedtransportation) as CompletedTransportation,
                            (e.medicine - e.trackedmedicine) as CompletedMedicine,
                            (e.clothing - e.trackedclothing) as CompletedClothing,
                            (e.media - e.trackedmedia) as CompletedMedia,
                            (e.insuranses - e.trackedinsuranses) as CompletedInsuranses,
                            (s.emergencyfund - s.trackedemergencyfund) as CompletedEmergencyFund,
                            (s.retirementaccount - s.trackedretirementaccount) as CompletedRetirementAccount,
                            (s.vacation - s.trackedvacation) as CompletedSavingsVacation,
                            (s.healthneeds - s.trackedhealthneeds) as CompletedHealthNeeds 
                            from months as m
                            full outer join income as i on m.incomeid = i.id
                            full outer join savings as s on m.savingsid= s.id
                            full outer join expenses as e on m.expensesid = e.id
                            where m.id = @Id and employment is not null and housing is not null and emergencyfund is not null;";

            var result = await connection.QueryAsync<BudgetCompletionModel>(sql, new { Id = id });
            return result.FirstOrDefault();
        }
    }
    public async Task<BudgetCompletionModel?> GetBudgetCompletionByMonthIdInPercent(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select m.id as MonthId, m.yearid,
                            (i.trackedemployment/NULLIF(i.Employment, 0) * 100) as CompletedEmployment, 
                            (i.trackedsidehustle/NULLIF(i.sidehustle, 0) * 100) as CompletedSidehustle, 
                            (i.trackeddividends/NULLIF(i.dividends, 0) * 100) as CompletedDividends,
                            (e.trackedhousing/NULLIF(e.housing, 0) * 100) as CompletedHousing,
                            (e.trackedgroceries/NULLIF(e.groceries, 0) * 100) as CompletedGroceries, 
                            (e.trackedutilities/NULLIF(e.utilities, 0) * 100) as CompletedUtilities,
                            (e.trackedvacation/NULLIF(e.vacation, 0) * 100) as CompletedExpensesVacation,
                            (e.trackedtransportation/NULLIF(e.transportation, 0) * 100) as CompletedTransportation,
                            (e.trackedmedicine/NULLIF(e.medicine, 0) * 100) as CompletedMedicine,
                            (e.trackedclothing/NULLIF(e.clothing, 0) * 100) as CompletedClothing,
                            (e.trackedmedia/NULLIF(e.media, 0) * 100) as CompletedMedia,
                            (e.trackedinsuranses/NULLIF(e.insuranses, 0) * 100) as CompletedInsuranses,
                            (s.emergencyfund/NULLIF(s.emergencyfund, 0) * 100) as CompletedEmergencyFund,
                            (s.trackedretirementaccount/NULLIF(s.retirementaccount, 0) * 100) as CompletedRetirementAccount,
                            (s.trackedvacation/NULLIF(s.vacation, 0) * 100) as CompletedSavingsVacation,
                            (s.trackedhealthneeds/NULLIF(s.healthneeds, 0) * 100) as CompletedHealthNeeds 
                            from months as m
                            full outer join income as i on m.incomeid = i.id
                            full outer join savings as s on m.savingsid= s.id
                            full outer join expenses as e on m.expensesid = e.id
                            where m.yearid = 17 and employment is not null and housing is not null and emergencyfund is not null;";

            var result = await connection.QueryAsync<BudgetCompletionModel>(sql, new { Id = id });
            return result.FirstOrDefault();
        }
    }
}
using DataBase.Access;
using DataBase.Models;

namespace DataBase.Data;

public class BudgetCompletion : IBudgetCompletion
{
    private readonly IPostgreSQL _dataAccess;

    public BudgetCompletion(IPostgreSQL dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<IEnumerable<BudgetCompletionModel?>> GetByYearId(int id)
    {
        string sql = @"select 
                            (i.employment - i.trackedemployment) as IncomeCompletedEmployment, 
                            (i.sidehustle - i.trackedsidehustle) as IncomeCompletedSidehustle, 
                            (i.dividends - i.trackeddividends) as IncomeCompletedDividends,
                            (e.housing - e.trackedhousing) as ExpensesCompletedHousing,
                            (e.groceries - e.trackedgroceries) as ExpensesCompletedGroceries, 
                            (e.utilities - e.trackedutilities) as ExpensesCompletedUtilities,
                            (e.vacation - e.trackedvacation) as ExpensesCompletedVacation,
                            (e.transportation - e.trackedtransportation) as ExpensesCompletedTransportation,
                            (e.medicine - e.trackedmedicine) as ExpensesCompletedMedicine,
                            (e.clothing - e.trackedclothing) as ExpensesCompletedClothing,
                            (e.media - e.trackedmedia) as ExpensesCompletedMedia,
                            (e.insuranses - e.trackedinsuranses) as ExpensesCompletedInsuranses,
                            (s.emergencyfund - s.trackedemergencyfund) as SavingsCompletedEmergencyFund,
                            (s.retirementaccount - s.trackedretirementaccount) as SavingsCompletedRetirementAccount,
                            (s.vacation - s.trackedvacation) as SavingsCompletedVacation,
                            (s.healthneeds - s.trackedhealthneeds) as SavingsCompletedHealthNeeds 
                            from months as m
                            full outer join income as i on m.incomeid = i.id
                            full outer join savings as s on m.savingsid= s.id
                            full outer join expenses as e on m.expensesid = e.id
                            where m.yearid = @Id and employment is not null and housing is not null and emergencyfund is not null;";

        var result = await _dataAccess.LoadData<BudgetCompletionModel, dynamic>(sql, new { Id = id });
        return result;
    }

    public async Task<BudgetCompletionModel?> GetByMonthId(int id)
    {
        string sql = @"select (i.employment - i.trackedemployment) as IncomeCompletedEmployment, 
                            (i.sidehustle - i.trackedsidehustle) as IncomeCompletedSidehustle, 
                            (i.dividends - i.trackeddividends) as IncomeCompletedDividends,
                            (e.housing - e.trackedhousing) as ExpensesCompletedHousing,
                            (e.groceries - e.trackedgroceries) as ExpensesCompletedGroceries, 
                            (e.utilities - e.trackedutilities) as ExpensesCompletedUtilities,
                            (e.vacation - e.trackedvacation) as ExpensesCompletedVacation,
                            (e.transportation - e.trackedtransportation) as ExpensesCompletedTransportation,
                            (e.medicine - e.trackedmedicine) as ExpensesCompletedMedicine,
                            (e.clothing - e.trackedclothing) as ExpensesCompletedClothing,
                            (e.media - e.trackedmedia) as ExpensesCompletedMedia,
                            (e.insuranses - e.trackedinsuranses) as ExpensesCompletedInsuranses,
                            (s.emergencyfund - s.trackedemergencyfund) as SavingsCompletedEmergencyFund,
                            (s.retirementaccount - s.trackedretirementaccount) as SavingsCompletedRetirementAccount,
                            (s.vacation - s.trackedvacation) as SavingsCompletedVacation,
                            (s.healthneeds - s.trackedhealthneeds) as SavingsCompletedHealthNeeds 
                            from months as m
                            full outer join income as i on m.incomeid = i.id
                            full outer join savings as s on m.savingsid= s.id
                            full outer join expenses as e on m.expensesid = e.id
                            where m.id = @Id and employment is not null and housing is not null and emergencyfund is not null;";

        var result = await _dataAccess.LoadData<BudgetCompletionModel, dynamic>(sql, new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task<BudgetCompletionModel?> GetPercentByMonthId(int id)
    {
        string sql = @"select (i.trackedemployment/NULLIF(i.Employment, 0) * 100) as IncomeCompletedEmployment, 
                            (i.trackedsidehustle/NULLIF(i.sidehustle, 0) * 100) as IncomeCompletedSidehustle, 
                            (i.trackeddividends/NULLIF(i.dividends, 0) * 100) as IncomeCompletedDividends,
                            (e.trackedhousing/NULLIF(e.housing, 0) * 100) as ExpensesCompletedHousing,
                            (e.trackedgroceries/NULLIF(e.groceries, 0) * 100) as ExpensesCompletedGroceries, 
                            (e.trackedutilities/NULLIF(e.utilities, 0) * 100) as ExpensesCompletedUtilities,
                            (e.trackedvacation/NULLIF(e.vacation, 0) * 100) as ExpensesCompletedVacation,
                            (e.trackedtransportation/NULLIF(e.transportation, 0) * 100) as ExpensesCompletedTransportation,
                            (e.trackedmedicine/NULLIF(e.medicine, 0) * 100) as ExpensesCompletedMedicine,
                            (e.trackedclothing/NULLIF(e.clothing, 0) * 100) as ExpensesCompletedClothing,
                            (e.trackedmedia/NULLIF(e.media, 0) * 100) as ExpensesCompletedMedia,
                            (e.trackedinsuranses/NULLIF(e.insuranses, 0) * 100) as ExpensesCompletedInsuranses,
                            (s.trackedemergencyfund/NULLIF(s.emergencyfund, 0) * 100) as SavingsCompletedEmergencyFund,
                            (s.trackedretirementaccount/NULLIF(s.retirementaccount, 0) * 100) as SavingsCompletedRetirementAccount,
                            (s.trackedvacation/NULLIF(s.vacation, 0) * 100) as SavingsCompletedVacation,
                            (s.trackedhealthneeds/NULLIF(s.healthneeds, 0) * 100) as SavingsCompletedHealthNeeds 
                            from months as m
                            full outer join income as i on m.incomeid = i.id
                            full outer join savings as s on m.savingsid= s.id
                            full outer join expenses as e on m.expensesid = e.id
                            where m.id = @id and employment is not null and housing is not null and emergencyfund is not null;";

        var result = await _dataAccess.LoadData<BudgetCompletionModel, dynamic>(sql, new { Id = id });
        return result.FirstOrDefault();
    }
}
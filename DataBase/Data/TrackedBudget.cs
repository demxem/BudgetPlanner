using DataBase.Access;
using DataBase.Models;

namespace DataBase.Data;

public class TrackedBudget : IBudgetTracked
{
    private readonly IPostgreSQL _dataAccess;

    public TrackedBudget(IPostgreSQL dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<IEnumerable<BudgetTrackedModel>> Get()
    {
        string sql = @"select * from budget
                            order by date desc;";

        var result = await _dataAccess.LoadData<BudgetTrackedModel, dynamic>(sql, new { });
        return result;
    }

    public async Task<IEnumerable<BudgetTrackedModel>> GetByMonthId(int id)
    {
        string sql = @"select * from budget
                            where monthid = @id
                            order by date desc;";

        var result = await _dataAccess.LoadData<BudgetTrackedModel, dynamic>(sql, new { id });
        return result;
    }

    public async Task Add(BudgetTrackedModel budget)
    {
        string sql = @"insert into budget(date, type, category, amount, details, balance, monthid, yearid)
                            values(@Date, @Type, @Category, @Amount, @Details, @Balance, @MonthId, @YearId);";

        await _dataAccess.SafeData(sql, new BudgetTrackedModel
        {
            Date = budget.Date,
            Type = budget.Type,
            Category = budget.Category,
            Amount = budget.Amount,
            Details = budget.Details,
            Balance = budget.Balance,
            MonthId = budget.MonthId,
            YearId = budget.YearId,
        });
    }

    public async Task Update(BudgetTrackedModel budget)
    {
        budget.Date = DateTime.Now;
        string sql = @"update budget
                            set date = @Date,
                                type = @Type,
                                category = @Category,
                                amount = @Amount,
                                details = @Details,
                                balance = @Balance,
                                incomeid = @IncomeId,
                                savingsid = @SavingsId,
                                expensesid = @ExpensesId
                            where id = @Id;";

        await _dataAccess.SafeData(sql, budget);
    }

    public async Task Delete(int id)
    {
        string sql = @"delete from budget
                            where id = @Id";

        await _dataAccess.SafeData(sql, new { Id = id });
    }
}


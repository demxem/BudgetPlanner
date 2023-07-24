using DAL.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DAL.Data;

public class Budget : IBudget
{
    private readonly IConfiguration _config;

    public Budget(IConfiguration config)
    {
        _config = config;
    }

    // public async Task GetAllMonths()
    // {
    //     using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
    //     {
    //         string sql = @"select * from months 
    //                         order by date;";

    //         connection.Open();

    //         using (var transaction = await connection.BeginTransactionAsync())
    //         {
    //             await connection.ExecuteAsync(sql, transaction);
    //             try
    //             {
    //                 var rowsEffected = connection.Execute("update months set name=@Name", transaction: transaction);
    //                 transaction.Commit();
    //             }
    //             catch (Exception ex)
    //             {
    //                 Console.WriteLine(ex.Message);
    //                 transaction.Rollback();
    //             }
    //         }
    //     }
    // }

    public async Task<IEnumerable<BudgetModel>> GetBudget()
    {

        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"select * from budget
                            order by id;";

            var result = await connection.QueryAsync<BudgetModel>(sql);
            return result;
        }
    }

    public async Task InsertBudget(BudgetModel budget)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"insert into budget(date, type, category, amount, details, balance, incomeid, savingsid, expensesid)
                            values(@Date, @Type, @Category, @Amount, @Details, @Balance, @IncomeId, @SavingsId, @ExpensesId);";

            await connection.ExecuteAsync(sql, new BudgetModel
            {
                Date = budget.Date,
                Type = budget.Type,
                Category = budget.Category,
                Amount = budget.Amount,
                Details = budget.Details,
                Balance = budget.Balance,
                IncomeId = budget.IncomeId,
                SavingsId = budget.SavingsId,
                ExpensesId = budget.ExpensesId
            });
        }
    }

    public async Task UpdateBudget(BudgetModel budget)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
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

            await connection.ExecuteAsync(sql, budget);
        }
    }

    public async Task DeleteBudgetById(int id)
    {
        using (var connection = new NpgsqlConnection(_config.GetConnectionString("Default")))
        {
            string sql = @"delete from budget
                            where id = @Id";

            await connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}


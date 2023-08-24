using DataBase.Data;
using DataBase.Models;

namespace Api.Modules
{
    public static class BudgetModule
    {
        public static void RegisterBudgetEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //Income
            endpoints.MapGet("/budget/income/{id}", GetBudgetIncomeByMonthIdAsync);
            endpoints.MapGet("/budget/income", GetBudgetIncomeAsync);
            endpoints.MapGet("/budget/years/income/{id}", GetBudgetIncomeByYearIdAsync);
            endpoints.MapGet("/budget/years/months/income/{id}", GetBudgetIncomeByMonthIdAsync);
            //Savings
            endpoints.MapGet("/budget/savings", GetBudgetSavingsAsync);
            endpoints.MapGet("/budget/years/savings/{id}", GetBudgetSavingsByYearIdAsync);
            endpoints.MapGet("/budget/years/months/savings/{id}", GetBudgetSavingsByMonthIdAsync);
            //Expenses
            endpoints.MapGet("/budget/expenses", GetBudgetExpensesAsync);
            endpoints.MapGet("/budget/years/expenses/{id}", GetBudGetBudgetExpensesByYearIdAsync);
            endpoints.MapGet("/budget/years/months/expenses/{id}", GetBudGetBudgetExpensesByMonthIdAsync);
            //Budget
            endpoints.MapGet("/budget", GetBudgetAsync);
            endpoints.MapGet("/years/months/budget/{id}", GetBudgetByMonthIdAsync);
            endpoints.MapGet("/years/budget/{id}", GetBudgetByYearIdAsync);
            //Months
            endpoints.MapGet("/years/months/{id}", GetMonthByYearIdAsync);
            endpoints.MapGet("/years/months", GetMonthsAsync);
            endpoints.MapPost("/years/months", AddMonth);
            endpoints.MapPut("/years/months/{id}", UpdateMonth);
            
            endpoints.MapDelete("/years/months/{id}", DeleteMonthByIdAsync);
        }

        private static async Task<IResult> GetMonthByYearIdAsync(IBudget data, int id)
        {
            try
            {
                return Results.Ok(await data.GetMonthByYearId(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetMonthsAsync(IBudget data)
        {
            try
            {
                return Results.Ok(await data.GetMonths());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetBudgetIncomeAsync(IBudget data)
        {
            try
            {
                return Results.Ok(await data.GetIncome());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetBudgetSavingsAsync(IBudget data)
        {
            try
            {
                return Results.Ok(await data.GetSavings());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetBudgetExpensesAsync(IBudget data)
        {
            try
            {
                return Results.Ok(await data.GetExpenses());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetBudgetAsync(IBudget data)
        {
            try
            {
                return Results.Ok(await data.Get());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetBudgetIncomeByMonthIdAsync(IBudget data, int id)
        {
            try
            {
                return Results.Ok(await data.GetIncomeByMonthId(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetBudgetIncomeByYearIdAsync(IBudget data, int id)
        {
            try
            {
                return Results.Ok(await data.GetIncomeByYearId(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetBudgetSavingsByYearIdAsync(IBudget data, int id)
        {
            try
            {
                return Results.Ok(await data.GetSavingsByYearId(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetBudgetSavingsByMonthIdAsync(IBudget data, int id)
        {
            try
            {
                return Results.Ok(await data.GetSavingsByMonthId(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetBudGetBudgetExpensesByYearIdAsync(IBudget data, int id)
        {
            try
            {
                return Results.Ok(await data.GetBudgetExpensesByYearId(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetBudGetBudgetExpensesByMonthIdAsync(IBudget data, int id)
        {
            try
            {
                return Results.Ok(await data.GetExpensesByMonthId(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetBudgetByMonthIdAsync(IBudget data, int id)
        {
            try
            {
                return Results.Ok(await data.GetByMonthId(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetBudgetByYearIdAsync(IBudget data, int id)
        {
            try
            {
                return Results.Ok(await data.GetByYearId(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> AddMonth(IBudget data, BudgetModel BudgetModel)
        {
            try
            {
                await data.AddMonth(BudgetModel);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> UpdateMonth(IBudget data, BudgetModel BudgetModel)
        {
            try
            {
                await data.UpdateMonth(BudgetModel);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> DeleteMonthByIdAsync(IBudget data, int id)
        {
            try
            {
                await data.DeleteMonthById(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}

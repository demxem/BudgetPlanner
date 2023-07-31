using DAL.ComplexData;
using DAL.Models;

namespace Api.Modules
{
    public static class BudgetModule
    {
        public static void RegisterBudgetEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //endpoints
            endpoints.MapGet("/months/income/{id}", GetIncomeByMonthId);
            endpoints.MapGet("/years/months/total/{id}", GetAllByMonthId);
            endpoints.MapGet("/years/months/income", GetIncomeByMonth);
            endpoints.MapGet("/years/months/savings", GetSavingsByMonth);
            endpoints.MapGet("/years/months/expenses", GetExpensesByMonth);
            endpoints.MapGet("/years/months/income/{id}", GetIncomeByYearId);
            endpoints.MapGet("/years/months/income/month/{id}", GetIncomeByMonthId);
            endpoints.MapGet("/years/months/savings/month/{id}", GetSavingsByMonthId);
            endpoints.MapGet("/years/months/expenses/month/{id}", GetExpensesByMonthId);
            endpoints.MapGet("/years/months/expenses/{id}", GetExpensesByYearId);
            endpoints.MapGet("/years/months/savings/{id}", GetSavingsByYearId);
            endpoints.MapGet("/years/months/{id}", GetMonthByYearId);
            endpoints.MapGet("/years/months", GetMonths);
            endpoints.MapPost("/years/months", InsertMonth);
            endpoints.MapPut("/years/months/{id}", UpdateMonth);
            endpoints.MapPost("/years/months/incomeByYearId/", InsertIncomeByYearId);
            endpoints.MapDelete("/years/months/{id}", DeleteMonthById);
            endpoints.MapGet("/months/budget", GetBudget);
        }

        private static async Task<IResult> GetMonthByYearId(IBudget data, int id)
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

        private static async Task<IResult> GetMonths(IBudget data)
        {
            try
            {
                return Results.Ok(await data.GetAllMonths());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetIncomeByMonth(IBudget data)
        {
            try
            {
                return Results.Ok(await data.GetIncomeByMonth());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetSavingsByMonth(IBudget data)
        {
            try
            {
                return Results.Ok(await data.GetSavingsByMonth());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetExpensesByMonth(IBudget data)
        {
            try
            {
                return Results.Ok(await data.GetExpensesByMonth());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetBudget(IBudget data)
        {
            try
            {
                return Results.Ok(await data.GetBudget());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetIncomeByMonthId(IBudget data, int id)
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
        private static async Task<IResult> GetIncomeByYearId(IBudget data, int id)
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
        private static async Task<IResult> GetSavingsByYearId(IBudget data, int id)
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
        private static async Task<IResult> GetSavingsByMonthId(IBudget data, int id)
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
        private static async Task<IResult> GetExpensesByYearId(IBudget data, int id)
        {
            try
            {
                return Results.Ok(await data.GetExpensesByYearId(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetExpensesByMonthId(IBudget data, int id)
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

        private static async Task<IResult> GetAllByMonthId(IBudget data, int id)
        {
            try
            {
                return Results.Ok(await data.GetAllByMonthId(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> InsertMonth(IBudget data, BudgetModel BudgetModel)
        {
            try
            {
                await data.InsertMonth(BudgetModel);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> InsertIncomeByYearId(IBudget data, BudgetModel BudgetModel)
        {
            try
            {
                await data.InsertIncomeByYearId(BudgetModel);
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

        private static async Task<IResult> DeleteMonthById(IBudget data, int id)
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

using DAL.ComplexData;
using DAL.Models;

namespace Api.Modules
{
    public static class MonthModule
    {
        public static void RegisterMonthsEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //endpoints
            // endpoints.MapGet("/years/months/savings/{id}", GetSavingsByMonthId);
            endpoints.MapGet("/years/months/total/{id}", GetAllByMonthId);
            endpoints.MapGet("/years/months/income", GetIncomeByMonth);
            endpoints.MapGet("/years/months/savings", GetSavingsByMonth);
            endpoints.MapGet("/years/months/expenses", GetExpensesByMonth);
            endpoints.MapGet("/years/months/income/{id}", GetIncomeByYearId);
            endpoints.MapGet("/years/months/expenses/{id}", GetExpensesByYearId);
            endpoints.MapGet("/years/months/savings/{id}", GetSavingsByYearId);
            endpoints.MapGet("/years/months/{id}", GetMonthById);
            endpoints.MapGet("/years/months", GetMonths);
            endpoints.MapPost("/years/months", InsertMonth);
            endpoints.MapPut("/years/months/{id}", UpdateMonth);
            endpoints.MapPost("/years/months/incomeByYearId/", InsertIncomeByYearId);
            endpoints.MapDelete("/years/months/{id}", DeleteMonthById);
        }

        private static async Task<IResult> GetMonthById(IMonth data, int id)
        {
            try
            {
                return Results.Ok(await data.GetMonthById(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetMonths(IMonth data)
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

        private static async Task<IResult> GetIncomeByMonth(IMonth data)
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

        private static async Task<IResult> GetSavingsByMonth(IMonth data)
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

        private static async Task<IResult> GetExpensesByMonth(IMonth data)
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

        private static async Task<IResult> GetSavingsByMonthId(IMonth data, int id)
        {
            try
            {
                return Results.Ok(await data.GetSavingsByid(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetIncomeByYearId(IMonth data, int id)
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
        private static async Task<IResult> GetSavingsByYearId(IMonth data, int id)
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
        private static async Task<IResult> GetExpensesByYearId(IMonth data, int id)
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

        private static async Task<IResult> GetAllByMonthId(IMonth data, int id)
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

        private static async Task<IResult> InsertMonth(IMonth data, MonthModel monthModel)
        {
            try
            {
                await data.InsertMonth(monthModel);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> InsertIncomeByYearId(IMonth data, MonthModel monthModel)
        {
            try
            {
                await data.InsertIncomeByYearId(monthModel);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> UpdateMonth(IMonth data, MonthModel monthModel)
        {
            try
            {
                await data.UpdateMonth(monthModel);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> DeleteMonthById(IMonth data, int id)
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

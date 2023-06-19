using DAL.ComplexData;
using DAL.Models;

namespace Api.Modules
{
    public static class MonthModule
    {
        public static void RegisterMonthsEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //endpoints
            endpoints.MapGet("/years/months/{id}/savings", GetSavingsByMonthId);
            endpoints.MapGet("/years/months/{id}/total", GetAllByMonthId);
            endpoints.MapGet("/years/months/{id}/totalincome", GetTotalIncomeByMonthId);
            endpoints.MapGet("/years/months/{id}/totalsavings", GetTotalSavingsByMonthId);
            endpoints.MapGet("/years/months/{id}/totalexpenses", GetTotalExpensesByMonthId);
            endpoints.MapPost("/years/month/{id}", InsertMonth);

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

        private static async Task<IResult> GetTotalIncomeByMonthId(IMonth data, int id)
        {
            try
            {
                return Results.Ok(await data.GetTotalIncomeByMonthId(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetTotalSavingsByMonthId(IMonth data, int id)
        {
            try
            {
                return Results.Ok(await data.GetTotalSavingsByMonthId(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetTotalExpensesByMonthId(IMonth data, int id)
        {
            try
            {
                return Results.Ok(await data.GetTotalExpensesByMonthId(id));
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
    }

}

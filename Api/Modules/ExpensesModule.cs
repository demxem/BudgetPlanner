using DAL.Models;
using DAL.Data;

namespace Api.Modules
{
    public static class ExpensesModule
    {
        public static void RegisterExpensesEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //endpoints
            // endpoints.MapGet("/years/months/expenses", GetExpenses);
            endpoints.MapGet("/years/months/expenses/{id}", GetExpensesById);
            endpoints.MapPost("/years/months/expenses/", InsertExpenses);
            endpoints.MapPut("/years/months/expenses/{id}", UpdateExpenses);
            endpoints.MapDelete("/years/months/expenses/{id}", DeleteExpenses);
        }

        private static async Task<IResult> GetExpenses(IExpenses data)
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


        private static async Task<IResult> GetExpensesById(int id, IExpenses data)
        {
            try
            {
                var results = await data.GetExpensesById(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }

            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }


        private static async Task<IResult> InsertExpenses(ExpensesModel expenses, IExpenses data)
        {
            try
            {
                await data.InsertExpenses(expenses);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> UpdateExpenses(ExpensesModel expenses, IExpenses data)
        {
            try
            {
                await data.UpdateExpenses(expenses);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> DeleteExpenses(IExpenses data, int id)
        {
            try
            {
                await data.DeleteExpenses(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}

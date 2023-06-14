using DAL.Models;
using DAL.Data;

namespace Api.Modules
{
    public static class ExpensesModule
    {
        public static void RegisterExpensesEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //endpoints
            endpoints.MapGet("/expenses", Getexpenses);
            endpoints.MapGet("/expenses/{id}", GetexpensesById);
            endpoints.MapPost("/expenses/", Insertexpenses);
            endpoints.MapPut("/expenses", Updateexpenses);
            endpoints.MapDelete("/expenses", DeleteExpenses);
        }


        private static async Task<IResult> Getexpenses(IExpenses data)
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


        private static async Task<IResult> GetexpensesById(int id, IExpenses data)
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


        private static async Task<IResult> Insertexpenses(ExpensesModel expenses, IExpenses data)
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

        private static async Task<IResult> Updateexpenses(ExpensesModel expenses, IExpenses data)
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

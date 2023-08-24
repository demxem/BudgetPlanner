using DataBase.Models;
using DataBase.Data;

namespace Api.Modules
{
    public static class ExpensesModule
    {
        public static void RegisterExpensesEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //endpoints
            endpoints.MapGet("/expenses", GetAsync);
            endpoints.MapPost("/years/months/expenses/", AddAsync);
            endpoints.MapPut("/years/months/expenses/{id}", UpdateAsync);
            endpoints.MapDelete("/years/months/expenses/{id}", DeleteAsync);
        }

        private static async Task<IResult> GetAsync(IExpenses data)
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


        private static async Task<IResult> GetByIdAsync(int id, IExpenses data)
        {
            try
            {
                var results = await data.GetById(id);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }

            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }


        private static async Task<IResult> AddAsync(ExpensesModel expenses, IExpenses data)
        {
            try
            {
                await data.Add(expenses);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> UpdateAsync(ExpensesModel expenses, IExpenses data)
        {
            try
            {
                await data.Update(expenses);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> DeleteAsync(IExpenses data, int id)
        {
            try
            {
                await data.Delete(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}

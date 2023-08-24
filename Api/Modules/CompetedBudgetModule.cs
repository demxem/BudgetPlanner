using DataBase.Data;

namespace Api.Modules
{
    public static class CompetedBudgetModule
    {
        public static void RegisterBudgetCompletionEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //endpoints
            endpoints.MapGet("/years/BudgetCompletion/{id}", GetByYearIdAsync);
            endpoints.MapGet("/years/months/completed/{id}", GetByMonthIdAsync);
            endpoints.MapGet("/years/months/percentcompleted/{id}", GetPercentByMonthIdAsync);
        }

        private static async Task<IResult> GetByYearIdAsync(IBudgetCompletion data, int id)
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

        private static async Task<IResult> GetByMonthIdAsync(IBudgetCompletion data, int id)
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
        private static async Task<IResult> GetPercentByMonthIdAsync(IBudgetCompletion data, int id)
        {
            try
            {
                return Results.Ok(await data.GetPercentByMonthId(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}


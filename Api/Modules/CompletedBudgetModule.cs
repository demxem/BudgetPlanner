using DAL.Data;

namespace Api.Modules
{
    public static class CompetedBudgetModule
    {
        public static void RegisterCompletedBudgetEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //endpoints
            endpoints.MapGet("/years/completed/{id}", GetBudgetCompletionByYearIdAsync);
            endpoints.MapGet("/years/months/completed/{id}", GetBudgetCompletionByMonthIdAsync);
            endpoints.MapGet("/years/months/percentCompleted/{id}", GetBudgetCompletionByMonthIdInPercentAsync);

        }

        private static async Task<IResult> GetBudgetCompletionByYearIdAsync(IBudgetCompletion data, int id)
        {
            try
            {
                return Results.Ok(await data.GetBudgetCompletionByYearId(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetBudgetCompletionByMonthIdAsync(IBudgetCompletion data, int id)
        {
            try
            {
                return Results.Ok(await data.GetBudgetCompletionByMonthId(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetBudgetCompletionByMonthIdInPercentAsync(IBudgetCompletion data, int id)
        {
            try
            {
                return Results.Ok(await data.GetBudgetCompletionByMonthIdInPercent(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}


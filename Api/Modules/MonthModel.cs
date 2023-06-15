using DAL.ComplexData;

namespace Api.Modules
{
    public static class MonthModel
    {
        public static void RegisterMonthsEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //endpoints
            endpoints.MapGet("/monthSavings/{id}", GetSavingsByMonthId);
            endpoints.MapGet("/monthAgregate/{id}", GetAllByMonthId);
            endpoints.MapGet("/monthTotalIncome/{id}", GetTotalIncomeByMonthId);
            endpoints.MapGet("/monthTotalSavings/{id}", GetTotalSavingsByMonthId);
            endpoints.MapGet("/monthTotalExpenses/{id}", GetTotalExpensesByMonthId);
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
    }
}

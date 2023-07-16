using DAL.Data;

namespace Api.Modules
{
    public static class CalculationsModule
    {
        public static void RegisterCalculationsEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //endpoints

            endpoints.MapGet("/months/income/totalIncome/{id}", GetYearlyIncome);
            endpoints.MapGet("/months/savings/totalSavings/{id}", GetYearlySavings);
            endpoints.MapGet("/months/expenses/totalExpenses/{id}", GetYearlyExpenses);
            endpoints.MapGet("/months/income/monthlyIncome/{id}", GetMonthlyIncome);
            endpoints.MapGet("/months/savings/monthlySavings/{id}", GetMonthlySavings);
            endpoints.MapGet("/months/expenses/monthlyExpenses/{id}", GetMonthlyExpenses);
            endpoints.MapGet("/months/income/yearlyUndistributedIncome/{id}", GetYearlyUndistributedIncome);
            endpoints.MapGet("/months/income/monthlyUndistributedIncome/{id}", GetMonthlyUndistributedIncome);
        }

        private static async Task<IResult> GetYearlyIncome(ICalculations data, int id)
        {
            try
            {
                return Results.Ok(await data.GetYearlyIncome(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetYearlySavings(ICalculations data, int id)
        {
            try
            {
                return Results.Ok(await data.GetYearlySavings(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetYearlyExpenses(ICalculations data, int id)
        {
            try
            {
                return Results.Ok(await data.GetYearlyExpenses(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetMonthlyIncome(ICalculations data, int id)
        {
            try
            {
                return Results.Ok(await data.GetMonthlyIncome(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetMonthlySavings(ICalculations data, int id)
        {
            try
            {
                return Results.Ok(await data.GetMonthlySavings(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetMonthlyExpenses(ICalculations data, int id)
        {
            try
            {
                return Results.Ok(await data.GetMonthlyExpenses(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> GetYearlyUndistributedIncome(ICalculations data, int id)
        {
            try
            {
                return Results.Ok(await data.GetYearlyUndistributedIncome(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetMonthlyUndistributedIncome(ICalculations data, int id)
        {
            try
            {
                return Results.Ok(await data.GetMonthlyUndistributedIncome(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}

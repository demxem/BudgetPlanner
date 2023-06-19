using DAL.ComplexData;

namespace Api.Modules
{
    public static class YearModule
    {
        public static void RegisterYearsEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //endpoints
            endpoints.MapGet("/years/{id}", GetYearById);
            endpoints.MapGet("/years", Get);
        }

        private static async Task<IResult> GetYearById(IYears data, int id)
        {
            try
            {
                return Results.Ok(await data.GetYearById(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> Get(IYears data)
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
    }
}

using DAL.ComplexData;

namespace Api.Modules
{
    public static class YearModule
    {
        public static void RegisterYearsEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //endpoints
            endpoints.MapGet("/getYearById/{id}", GetYearById);
            endpoints.MapGet("/getAll", GetAll);

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

        private static async Task<IResult> GetAll(IYears data)
        {
            try
            {
                return Results.Ok(await data.GetAll());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}

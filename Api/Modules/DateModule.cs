using DAL.Data;

namespace Api.Modules
{
    public static class DateModule
    {
        public static void RegisterDateEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //endpoints
            endpoints.MapGet("/years/months/date", GetLatestDate);

        }

        private static async Task<IResult> GetLatestDate(IDate data)
        {
            try
            {
                return Results.Ok(await data.GetLatestDate());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
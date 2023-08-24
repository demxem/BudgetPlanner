using DataBase.Data;

namespace Api.Modules
{
    public static class DateModule
    {
        public static void RegisterDateEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //endpoints
            endpoints.MapGet("/years/months/date", GetAsync);
        }

        private static async Task<IResult> GetAsync(IDate data)
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
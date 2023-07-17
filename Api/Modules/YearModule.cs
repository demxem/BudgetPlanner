using DAL.Data;
using DAL.Models;

namespace Api.Modules
{
    public static class YearModule
    {
        public static void RegisterYearsEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //endpoints
            endpoints.MapGet("/years/{id}", GetYearByIdAsync);
            endpoints.MapPost("/years", InsertYearAsync);
            endpoints.MapGet("/years", GetYearsAsync);
            endpoints.MapDelete("/years/{id}", DeleteYearByIdAsync);
        }

        private static async Task<IResult> GetYearsAsync(IYears data)
        {
            try
            {
                return Results.Ok(await data.GetYears());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetYearByIdAsync(IYears data, int id)
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

        private static async Task<IResult> InsertYearAsync(IYears data, YearModel year)
        {
            try
            {
                await data.InsertYear(year);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> DeleteYearByIdAsync(IYears Data, int id)
        {
            try
            {
                await Data.DeleteYearById(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}

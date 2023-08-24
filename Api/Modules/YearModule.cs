
using DataBase.Data;
using DataBase.Models;

namespace Api.Modules
{
    public static class YearModule
    {
        public static void RegisterYearsEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //endpoints
            endpoints.MapGet("/years", GetAsync);
            endpoints.MapGet("/years/{id}", GetByIdAsync);
            endpoints.MapPost("/years", AddAsync);
            endpoints.MapDelete("/years/{id}", DeleteAsync);
        }

        private static async Task<IResult> GetAsync(IYears data)
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

        private static async Task<IResult> GetByIdAsync(IYears data, int id)
        {
            try
            {
                return Results.Ok(await data.GetById(id));
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> AddAsync(IYears data, YearModel year)
        {
            try
            {
                await data.Add(year);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        private static async Task<IResult> DeleteAsync(IYears Data, int id)
        {
            try
            {
                await Data.Delete(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}

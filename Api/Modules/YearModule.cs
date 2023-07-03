using System.ComponentModel.Design;
using System.Runtime.Intrinsics.X86;
using DAL.ComplexData;
using DAL.Models;

namespace Api.Modules
{
    public static class YearModule
    {
        public static void RegisterYearsEndpoints(this IEndpointRouteBuilder endpoints)
        {
            //endpoints
            endpoints.MapGet("/years/{id}", GetYearById);
            endpoints.MapPost("/years", InsertYear);
            endpoints.MapGet("/years", GetYears);
            endpoints.MapDelete("/years/{id}", DeleteYearById);
        }

        private static async Task<IResult> GetYears(IYears data)
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

        // private static async Task<IResult> Get(IYears data)
        // {
        //     try
        //     {
        //         return Results.Ok(await data.Get());
        //     }
        //     catch (Exception ex)
        //     {
        //         return Results.Problem(ex.Message);
        //     }
        // }
        private static async Task<IResult> InsertYear(IYears data, YearModel year)
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

        private static async Task<IResult> DeleteYearById(IYears Data, int id)
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

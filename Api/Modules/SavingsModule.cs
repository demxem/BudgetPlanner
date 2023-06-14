using DAL.Data;
using DAL.Models;

namespace Api.Modules;

public static class SavingsModule
{
    public static void RegisterSavingsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        //endpoints
        endpoints.MapGet("/savings", GetSavings);
        endpoints.MapGet("/savings/{id}", GetSavingsById);
        endpoints.MapPost("/savings/", InsertSavings);
        endpoints.MapPut("/savings", UpdateSavings);
        endpoints.MapDelete("/savings", DeleteSavings);
    }


    private static async Task<IResult> GetSavings(ISavings data)
    {
        try
        {
            return Results.Ok(await data.GetSavings());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }


    private static async Task<IResult> GetSavingsById(int id, ISavings data)
    {
        try
        {
            var results = await data.GetSavingsById(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }

        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }


    private static async Task<IResult> InsertSavings(SavingsModel savings, ISavings data)
    {
        try
        {
            await data.InsertSavings(savings);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateSavings(SavingsModel savings, ISavings data)
    {
        try
        {
            await data.UpdateSavings(savings);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteSavings(ISavings data, int id)
    {
        try
        {
            await data.DeleteSavings(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}


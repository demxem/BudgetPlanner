using DAL.Data;
using DAL.Models;

namespace Api.Modules;

public static class SavingsModule
{
    public static void RegisterSavingsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        //endpoints
        endpoints.MapGet("/years/months/savings", GetSavings);
        endpoints.MapGet("/years/months/savings/{id}", GetSavingsById);
        endpoints.MapPost("/years/months/savings/", InsertSavings);
        endpoints.MapPut("/years/months/savings/{id}", UpdateSavings);
        endpoints.MapDelete("/years/months/savings/{id}", DeleteSavings);
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


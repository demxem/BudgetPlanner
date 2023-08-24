using DataBase.Data;
using DataBase.Models;

namespace Api.Modules;

public static class SavingsModule
{
    public static void RegisterSavingsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        //endpoints
        endpoints.MapGet("/savings", GetAsync);
        endpoints.MapPost("/years/months/savings/", AddAsync);
        endpoints.MapPut("/years/months/savings/{id}", UpdateAsync);
        endpoints.MapDelete("/years/months/savings/{id}", DeleteAsync);
    }

    private static async Task<IResult> GetAsync(ISavings data)
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

    private static async Task<IResult> GetByIdAsync(int id, ISavings data)
    {
        try
        {
            var results = await data.GetById(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }

        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }


    private static async Task<IResult> AddAsync(SavingsModel savings, ISavings data)
    {
        try
        {
            await data.Add(savings);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateAsync(SavingsModel savings, ISavings data)
    {
        try
        {
            await data.Update(savings);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteAsync(ISavings data, int id)
    {
        try
        {
            await data.Delete(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}


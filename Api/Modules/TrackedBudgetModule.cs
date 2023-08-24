using DataBase.Data;
using DataBase.Models;

namespace Api.Modules;

public static class TrackedBudgetModule 
{
    public static void RegisterTrackedBudgetEndpoints(this IEndpointRouteBuilder endpoints)
    {
        //endpoints
        endpoints.MapGet("/years/months/trackedbudget/", GetAsync);
        endpoints.MapGet("/years/months/trackedbudget/{id}", GetByMonthIdAsync);
        endpoints.MapPost("/years/months/trackedbudget/", AddAsync);
        endpoints.MapPut("/years/months/trackebudget/{id}", UpdateAsync);
        endpoints.MapDelete("/years/months/trackedbudget/{id}", DeleteAsync);
    }

    private static async Task<IResult> GetAsync(IBudgetTracked data)
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

    private static async Task<IResult> GetByMonthIdAsync(int id, IBudgetTracked data)
    {
        try
        {
            var results = await data.GetByMonthId(id);
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> AddAsync(BudgetTrackedModel budget, IBudgetTracked data)
    {
        try
        {
            await data.Add(budget);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateAsync(BudgetTrackedModel budget, IBudgetTracked data)
    {
        try
        {
            await data.Update(budget);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteAsync(IBudgetTracked data, int id)
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
using DAL.Data;
using DAL.Models;

namespace Api.Modules;

public static class BudgetModule
{
    public static void RegisterDetailedBudgetEndpoints(this IEndpointRouteBuilder endpoints)
    {
        //endpoints
        endpoints.MapGet("/years/months/budget/", GetBudget);
        // endpoints.MapGet("/years/months/budget/{id}", GetbudgetById);
        endpoints.MapPost("/years/months/budget/", InsertBudget);
        endpoints.MapPut("/years/months/budget/{id}", UpdateBudget);
        endpoints.MapDelete("/years/months/budget/{id}", DeleteBudget);
    }
    private static async Task<IResult> GetBudget(IDetailedBudget data)
    {
        try
        {
            return Results.Ok(await data.GetBudget());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    // private static async Task<IResult> GetbudgetById(int id, Ibudget data)
    // {
    //     try
    //     {
    //         var results = await data.GetbudgetById(id);
    //         if (results == null) return Results.NotFound();
    //         return Results.Ok(results);
    //     }

    //     catch (Exception ex)
    //     {
    //         return Results.Problem(ex.Message);
    //     }
    // }

    private static async Task<IResult> InsertBudget(DetailedBudgetModel budget, IDetailedBudget data)
    {
        try
        {
            await data.InsertBudget(budget);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateBudget(DetailedBudgetModel budget, IDetailedBudget data)
    {
        try
        {
            await data.UpdateBudget(budget);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteBudget(IDetailedBudget data, int id)
    {
        try
        {
            await data.DeleteBudgetById(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
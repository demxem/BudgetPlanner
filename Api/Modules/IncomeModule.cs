using DAL.Data;
using DAL.Models;

namespace Api.Modules;

public static class IncomeModule
{
    public static void RegisterIncomeEndpoints(this IEndpointRouteBuilder endpoints)
    {
        //endpoints
        endpoints.MapGet("/years/months/income", GetIncome);
        endpoints.MapGet("/years/months/income/{id}", GetIncomeById);
        endpoints.MapPost("/years/months/income/", InsertIncome);
        endpoints.MapPut("/years/months/income/{id}", UpdateIncome);
        endpoints.MapDelete("/years/months/income/{id}", DeleteIncome);
    }
    private static async Task<IResult> GetIncome(IIncome data)
    {
        try
        {
            return Results.Ok(await data.GetIncome());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetIncomeById(int id, IIncome data)
    {
        try
        {
            var results = await data.GetIncomeById(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }

        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertIncome(IncomeModel Income, IIncome data)
    {
        try
        {
            await data.InsertIncome(Income);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateIncome(IncomeModel income, IIncome data)
    {
        try
        {
            await data.UpdateIncome(income);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteIncome(IIncome data, int id)
    {
        try
        {
            await data.DeleteIncome(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
using DataBase.Data;
using DataBase.Models;

namespace Api.Modules;

public static class IncomeModule
{
    public static void RegisterIncomeEndpoints(this IEndpointRouteBuilder endpoints)
    {
        //endpoints
        endpoints.MapGet("/income", GetIncome);
        endpoints.MapPost("/years/months/income/", AddAsync);
        endpoints.MapPut("/years/months/income/{id}", UpdateAsync);
        endpoints.MapDelete("/years/months/income/{id}", DeleteAsync);
    }

    private static async Task<IResult> GetIncome(IIncome data)
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

    private static async Task<IResult> AddAsync(IncomeModel Income, IIncome data)
    {
        try
        {
            await data.Add(Income);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateAsync(IncomeModel income, IIncome data)
    {
        try
        {
            await data.Update(income);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteAsync(IIncome data, int id)
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
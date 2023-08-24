using DataBase.Data;
using Api.Modules;
using DataBase.Access;

namespace Api.Api;

public static class AppBuilder
{
    public static WebApplication GetApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddTransient<IPostgreSQL, PostgreSQL>();
        builder.Services.AddTransient<ISavings, Savings>();
        builder.Services.AddTransient<IExpenses, Expenses>();
        builder.Services.AddTransient<IIncome, Income>();
        builder.Services.AddTransient<IBudget, Budget>();
        builder.Services.AddTransient<IYears, Years>();
        builder.Services.AddTransient<IDate, Date>();
        builder.Services.AddTransient<IBudgetTracked, TrackedBudget>();
        builder.Services.AddTransient<IBudgetCompletion, BudgetCompletion>();
        builder.Services.AddCors();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        //Endpoints
        app.RegisterSavingsEndpoints();
        app.RegisterExpensesEndpoints();
        app.RegisterDateEndpoints();
        app.RegisterIncomeEndpoints();
        app.RegisterTrackedBudgetEndpoints();
        app.RegisterBudgetEndpoints();
        app.RegisterYearsEndpoints();
        app.RegisterBudgetCompletionEndpoints();

        app.UseCors(builder => builder
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());

        return app;
    }

}



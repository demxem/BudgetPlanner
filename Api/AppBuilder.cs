using DAL.Data;
using DAL.DbAccess;
using Api.Modules;

namespace Api.Api;

public static class AppBuilder
{
    public static WebApplication GetApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddTransient<IPgsqlAccess, PgsqlAccess>();
        builder.Services.AddTransient<ISavings, Savings>();
        builder.Services.AddTransient<IExpenses, Expenses>();
        builder.Services.AddTransient<IIncome, Income>();
        builder.Services.AddCors();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        //Endpoints
        app.RegisterSavingsEndpoints();
        app.RegisterExpensesEndpoints();
        app.RegisterIncomeEndpoints();


        app.UseCors(builder => builder
                   .AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader());

        return app;
    }

}



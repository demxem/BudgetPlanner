using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client;
using MudBlazor.Services;
using Client.Services;
using Client.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


//Host and port where API is hosted
var apiBaseAddress = "http://localhost:5555";
builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseAddress) });

builder.Services.AddScoped<DetailedBudgetApiClient>();
builder.Services.AddScoped<ExpensesApiClient>();
builder.Services.AddScoped<SavingsApiClient>();
builder.Services.AddScoped<IncomeApiClient>();
builder.Services.AddScoped<YearApiClient>();
builder.Services.AddScoped<MonthsApiClient>();
builder.Services.AddScoped<DateApiClient>();
builder.Services.AddScoped<CompletedBudgetApiService>();
builder.Services.AddScoped<DatePicker>();
builder.Services.AddSingleton<SharedState>();
builder.Services.AddSingleton<IMessageService, MessageService>();

await builder.Build().RunAsync();

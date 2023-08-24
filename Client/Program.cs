using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Client.Services;
using Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


//Host and port where API is hosted
var apiBaseAddress = "http://localhost:5555";
builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseAddress) });

builder.Services.AddScoped<TrackedBudgetApiClient>();
builder.Services.AddScoped<ExpensesApiClient>();
builder.Services.AddScoped<SavingsApiClient>();
builder.Services.AddScoped<IncomeApiClient>();
builder.Services.AddScoped<YearApiClient>();
builder.Services.AddScoped<DateApiClient>();
builder.Services.AddScoped<BudgetCompletionApiClient>();
builder.Services.AddScoped<BudgetApiClient>();
builder.Services.AddScoped<DateApiClient>();
builder.Services.AddSingleton<SharedState>();
builder.Services.AddSingleton<IMessageService, MessageService>();
builder.Services.AddSingleton<Charts>();
builder.Services.AddSingleton<DatePicker>();
builder.Services.AddSingleton<Charts>();


await builder.Build().RunAsync();

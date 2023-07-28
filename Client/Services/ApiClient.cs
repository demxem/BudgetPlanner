// using System.Net.Http.Json;
// using Client.Models;

// namespace Client.Services
// {
//     public class ApiClient
//     {
//         private readonly HttpClient httpClient;

//         public ApiClient(HttpClient httpClient)
//         {
//             this.httpClient = httpClient;
//         }

//         public async Task<List<BudgetModel>?> GetMonthsAsync()
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync("/years/months");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var months = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

//                     return months;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }

//             return new List<BudgetModel>();
//         }

//         public async Task<List<DateModel>?> GetLatestDateAsync()
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync("/years/months/date");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var date = await response.Content.ReadFromJsonAsync<List<DateModel>>();

//                     return date;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new List<DateModel>();
//         }

//         public async Task<List<IncomeModel>?> GetIncomeAsync()
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync("/income");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var income = await response.Content.ReadFromJsonAsync<List<IncomeModel>>();

//                     return income;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new List<IncomeModel>();
//         }
//         public async Task<List<SavingsModel>?> GetSavingsAsync()
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync("/savings");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var savings = await response.Content.ReadFromJsonAsync<List<SavingsModel>>();

//                     return savings;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new List<SavingsModel>();
//         }
//         public async Task<List<ExpensesModel>?> GetExpensesAsync()
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync("/expenses");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var expenses = await response.Content.ReadFromJsonAsync<List<ExpensesModel>>();

//                     return expenses;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new List<ExpensesModel>();
//         }
//         public async Task<List<BudgetModel>?> GetDataAsync()
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync("months/budget");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var data = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

//                     return data;
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new List<BudgetModel>();
//         }
//         public async Task<List<BudgetModel>?> GetExpensesByEachMonthAsync()
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync("years/months/expenses");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var expenses = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

//                     return expenses;
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new List<BudgetModel>();
//         }
//         public async Task<List<BudgetModel>?> GetIncomeByEachMonthAsync()
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync("years/months/income");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var income = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

//                     return income;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new List<BudgetModel>();
//         }
//         public async Task<BudgetModel?> GetLatestIncomeAsync()
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync("years/months/income");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var income = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();
//                     var latestIncome = income?.LastOrDefault();

//                     return latestIncome;
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new BudgetModel();
//         }

//         public async Task<BudgetModel?> GetLatestSavingsAsync()
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync("years/months/savings");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var savings = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();
//                     var latestSavings = savings?.LastOrDefault();

//                     return latestSavings;
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new BudgetModel();
//         }

//         public async Task<BudgetModel?> GetLatestExpensesAsync()
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync("years/months/expenses");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var expenses = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();
//                     var latestExpenses = expenses?.LastOrDefault();

//                     return latestExpenses;
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new BudgetModel();
//         }

//         public async Task<List<BudgetModel>?> GetSavingByEachMonthAsync()
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync("years/months/savings");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var savings = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

//                     return savings;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new List<BudgetModel>();
//         }

//         public async Task<List<YearModel>?> GetYearsAsync()
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync("/years");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var years = await response.Content.ReadFromJsonAsync<List<YearModel>>();

//                     return years;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new List<YearModel>();
//         }
//         public async Task<List<BudgetModel>?> GetIncomeByYearId(int id)
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync($"/years/months/income/{id}");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var income = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

//                     return income;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new List<BudgetModel>();
//         }
//         public async Task<BudgetModel?> GetIncomeByMonthIdAsync(int id)
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync($"/years/months/income/month/{id}");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var income = await response.Content.ReadFromJsonAsync<BudgetModel>();

//                     return income;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new BudgetModel();
//         }

//         public async Task<List<BudgetModel>?> GetExpensesByYearId(int id)
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync($"/years/months/expenses/{id}");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var expenses = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

//                     return expenses;
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new List<BudgetModel>();
//         }
//         public async Task<BudgetModel?> GetExpensesByMonthIdAsync(int id)
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync($"/years/months/expenses/month/{id}");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var expenses = await response.Content.ReadFromJsonAsync<BudgetModel>();

//                     return expenses;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new BudgetModel();
//         }

//         public async Task<List<BudgetModel>?> GetSavingsByYearId(int id)
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync($"/years/months/savings/{id}");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var savings = await response.Content.ReadFromJsonAsync<List<BudgetModel>>();

//                     return savings;
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new List<BudgetModel>();
//         }
//         public async Task<BudgetModel?> GetSavingsByMonthIdAsync(int id)
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync($"/years/months/savings/month/{id}");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var savings = await response.Content.ReadFromJsonAsync<BudgetModel>();

//                     return savings;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new BudgetModel();
//         }

//         public async Task UpdateIncomeAsync(IncomeModel? item)
//         {
//             await httpClient.PutAsJsonAsync($"/years/months/income/{item?.Id}", item);
//         }
//         public async Task UpdateSavingsAsync(SavingsModel? item)
//         {
//             await httpClient.PutAsJsonAsync($"/years/months/savings/{item?.Id}", item);
//         }
//         public async Task UpdateExpensesAsync(ExpensesModel? item)
//         {
//             await httpClient.PutAsJsonAsync($"/years/months/expenses/{item?.Id}", item);
//         }
//         public async Task UpdateMonthAsync(BudgetModel month)
//         {
//             await httpClient.PutAsJsonAsync($"/years/months/{month.Id}", month);
//         }

//         public async Task DeleteIncomeByIdAsync(int Id)
//         {
//             await httpClient.DeleteAsync($"/years/months/income/{Id}");
//         }
//         public async Task DeleteSavingsByIdAsync(int Id)
//         {
//             await httpClient.DeleteAsync($"/years/months/savings/{Id}");
//         }
//         public async Task DeleteExpensesByIdAsync(int Id)
//         {
//             await httpClient.DeleteAsync($"/years/months/expenses/{Id}");
//         }

//         public async Task DeleteYearByIdAsync(int id)
//         {
//             await httpClient.DeleteAsync($"/years/{id}");
//         }

//         public async Task PostIncomeAsync(IncomeModel income)
//         {
//             await httpClient.PostAsJsonAsync($"/years/months/income/", income);
//         }
//         public async Task PostExpensesAsync(ExpensesModel expenses)
//         {
//             await httpClient.PostAsJsonAsync($"/years/months/expenses/", expenses);
//         }
//         public async Task PostSavingsAsync(SavingsModel savings)
//         {
//             await httpClient.PostAsJsonAsync($"/years/months/savings/", savings);
//         }
//         public async Task PostIncomeByYearIdAsync(BudgetModel month)
//         {
//             await httpClient.PostAsJsonAsync($"/years/months/incomeByYearId", month);
//         }

//         public async Task PostYearAsync(YearModel year)
//         {
//             await httpClient.PostAsJsonAsync($"/years", year);
//         }
//         public async Task PostMonthAsync(BudgetModel month)
//         {
//             await httpClient.PostAsJsonAsync($"/years/months", month);
//         }
//         public async Task<float> GetMonthlyIncome(int id)
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync($"/months/income/monthlyIncome/{id}");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var monthlyIncome = await response.Content.ReadFromJsonAsync<float>();

//                     return monthlyIncome;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return 0;
//         }

//         public async Task<float> GetMonthlySavings(int id)
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync($"/months/income/monthlySavings/{id}");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var monthlyIncome = await response.Content.ReadFromJsonAsync<float>();

//                     return monthlyIncome;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return 0;
//         }
//         public async Task<float> GetMonthlyExpenses(int id)
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync($"/months/income/monthlyExpenses/{id}");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var monthlyIncome = await response.Content.ReadFromJsonAsync<float>();

//                     return monthlyIncome;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return 0;
//         }
//         public async Task<float> GetMonthlyUndistributedIncome(int id)
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync($"/months/income/monthlyUndistributedIncome/{id}");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var monthlyUndistributedIncome = await response.Content.ReadFromJsonAsync<float>();

//                     return monthlyUndistributedIncome;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return 0;
//         }

//         public async Task<float> GetYearlyIncome(int id)
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync($"/months/income/totalIncome/{id}");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var monthlyIncome = await response.Content.ReadFromJsonAsync<float>();

//                     return monthlyIncome;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return 0;
//         }

//         public async Task<float> GetYearlySavings(int id)
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync($"/months/savings/totalSavings/{id}");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var yearlySavings = await response.Content.ReadFromJsonAsync<float>();

//                     return yearlySavings;
//                 }

//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return 0;
//         }
//         public async Task<float> GetYearlyExpenses(int id)
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync($"/months/expenses/totalExpenses/{id}");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var yearlyExpenses = await response.Content.ReadFromJsonAsync<float>();

//                     return yearlyExpenses;
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return 0;
//         }
//         public async Task<float> GetYearlyUndistributedIncome(int id)
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync($"/months/income/yearlyUndistributedIncome/{id}");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var yearlyUndistributedIncome = await response.Content.ReadFromJsonAsync<float>();

//                     return yearlyUndistributedIncome;
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return 0;
//         }

//         public async Task<List<DetailedBudgetModel>?> GetBudgetAsync()
//         {
//             try
//             {
//                 var response = await httpClient.GetAsync($"/years/months/budget");

//                 if (response.IsSuccessStatusCode)
//                 {
//                     var budget = await response.Content.ReadFromJsonAsync<List<DetailedBudgetModel>>();

//                     return budget;
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//             return new List<DetailedBudgetModel>();
//         }

//         public async Task InsertBudgetAsync(DetailedBudgetModel budget)
//         {
//             try
//             {
//                 await httpClient.PostAsJsonAsync("/years/months/budget/", budget);
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//         }

//         public async Task UpdateBudgetAsync(int id)
//         {
//             try
//             {
//                 await httpClient.PutAsJsonAsync($"/years/months/budget/{id}", id);
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//         }
//         public async Task DeleteBudgetAsync(int id)
//         {
//             try
//             {
//                 await httpClient.DeleteAsync($"/years/months/budget/{id}");
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex.Message.ToString());
//             }
//         }
//     }
// }
using System.Reflection;
using ApexCharts;
using Client.Models;
using Client.Services;

namespace Tests.Client;


public class BudgetDashboardTest
    {
        [Fact]
        public async void TestDashBoard()
        {
            var apiBaseAddress = "http://localhost:5555";
            var yearApiClient = new YearApiClient(new HttpClient { BaseAddress = new Uri(apiBaseAddress) });
            var budgetApiClient = new BudgetApiClient(new HttpClient { BaseAddress = new Uri(apiBaseAddress) });
            var budgetCompletionApiClient = new BudgetCompletionApiClient(new HttpClient{BaseAddress = new Uri(apiBaseAddress)});
            var datePicker = new DatePicker();
            var charts = new Charts();

            PieChartModel[]? _trackedChartPlot = new PieChartModel[3]
            {
                    new PieChartModel { Name = "Income", Value = 0 },
                    new PieChartModel { Name = "Expenses", Value = 0 },
                    new PieChartModel { Name = "Savings", Value = 0 }
            };
            PieChartModel[]? _actualChartPlot = new PieChartModel[3]
            {
                new PieChartModel { Name = "Income", Value = 0 },
                new PieChartModel { Name = "Expenses", Value = 0 },
                new PieChartModel { Name = "Savings", Value = 0 }
            };

            IEnumerable<BudgetModel>? months = await budgetApiClient.GetMonthsAsync();
            IEnumerable<YearModel>? years = await yearApiClient.GetYearsAsync();
            BudgetModel? income = await budgetApiClient.GetIncomeByMonthIdAsync(months!.Select(month => month.Id).LastOrDefault());
            BudgetModel? savings = await budgetApiClient.GetSavingsByMonthIdAsync(months!.Select(month => month.Id).LastOrDefault()!);
            BudgetModel? expenses = await budgetApiClient.GetExpensesByMonthIdAsync(months!.Select(month => month.Id).LastOrDefault()!);
            BudgetCompletionModel? budgetCompletion =  await budgetCompletionApiClient.GetByMonthIdAsync(months!.Select(months => months.Id).LastOrDefault());
            BudgetCompletionModel? budgetCompletionPercent = await budgetCompletionApiClient.GetPercentByMonthIdAsync(months!.Select(month => month.Id).LastOrDefault());

            // Data from Api Call
            Assert.NotNull(months);
            Assert.NotNull(income);
            Assert.NotNull(savings);
            Assert.NotNull(expenses);
            Assert.NotNull(years);
            Assert.NotNull(budgetCompletion);
            Assert.NotNull(budgetCompletionPercent);

            // Method properly finds month id in Db based on Selected date in Calendar/DatePicker
            int result = datePicker.GetMonthId(new DateTime(2023, 08, 01), years, months);

            Assert.Equal(171, result);

            // Checks if Copy method properly updates Charts
            var actualChartBeforeUpdate = _trackedChartPlot;
            var groupChartBeforeUpdate = _actualChartPlot;
            var resultChartGroup = charts.SetTrackedBudgetForGroupBarChart(income,savings,expenses);
            var resultChartActual = charts.SetActualBudgetForGroupBarChart(income, savings, expenses);
            
            Array.Copy(resultChartGroup, _trackedChartPlot!, 3);
            Array.Copy(resultChartActual, _actualChartPlot!, 3);
            
            Assert.NotEqual(actualChartBeforeUpdate, _actualChartPlot);
            Assert.NotEqual(groupChartBeforeUpdate, resultChartGroup);

        }
    }

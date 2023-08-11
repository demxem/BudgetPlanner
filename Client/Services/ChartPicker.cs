using ApexCharts;
using Client.Models;

namespace Client.Services
{
    public class ChartPicker
    {
        public List<PieChartModel> SetIncomePieChart(BudgetModel income)
        {
            List<PieChartModel> Chart = new List<PieChartModel>();
            Chart.Add(new PieChartModel { Name = "TrackedEmployment", Value = income.Income.TrackedEmployment });
            Chart.Add(new PieChartModel { Name = "TrackedDividends", Value = income.Income.Dividends });
            Chart.Add(new PieChartModel { Name = "TrackedSideHustle", Value = income.Income.TrackedSideHustle });
            return Chart;
        }

        public List<PieChartModel> SetSavingsPieChart(BudgetModel savings)
        {
            List<PieChartModel> Chart = new List<PieChartModel>();
            Chart.Add(new PieChartModel
            {
                Name = "TrackedEmergencyFund",
                Value = savings.Savings.TrackedEmergencyFund
            });
            Chart.Add(new PieChartModel
            {
                Name = "TrackedRetirementAccount",
                Value =
                savings.Savings.TrackedRetirementAccount
            });
            Chart.Add(new PieChartModel { Name = "TrackedVacation", Value = savings.Savings.TrackedVacation });
            Chart.Add(new PieChartModel { Name = "TrackedHealthNeeds", Value = savings.Savings.TrackedHealthNeeds });

            return Chart;
        }
        public PieChartModel[] SetExpensesPieChart(BudgetModel expenses)
        {
            PieChartModel[] Chart = new PieChartModel[9];
            Chart[0] = new PieChartModel { Name = "TrackedHousing", Value = expenses.Expenses.TrackedHousing };
            Chart[1] = new PieChartModel { Name = "TrackedGroceries", Value = expenses.Expenses.TrackedGroceries };
            Chart[2] = new PieChartModel { Name = "TrackedUtilities", Value = expenses.Expenses.TrackedUtilities };
            Chart[3] = new PieChartModel { Name = "TrackedVacation", Value = expenses.Expenses.TrackedVacation };
            Chart[4] = new PieChartModel
            {
                Name = "TrackedTransportation",
                Value = expenses.Expenses.TrackedTransportation
            };
            Chart[5] = new PieChartModel { Name = "TrackedMedicine", Value = expenses.Expenses.TrackedMedicine };
            Chart[6] = new PieChartModel { Name = "TrackedClothing", Value = expenses.Expenses.TrackedClothing };
            Chart[7] = new PieChartModel { Name = "TrackedMedia", Value = expenses.Expenses.TrackedMedia };
            Chart[8] = new PieChartModel { Name = "TrackedInsuranses", Value = expenses.Expenses.TrackedInsuranses };

            return Chart;
        }

        public PieChartModel[] SetActualGroupBarChart(BudgetModel income, BudgetModel savings, BudgetModel expenses)
        {
            PieChartModel[] Chart = new PieChartModel[3];
            Chart[0] = new PieChartModel { Name = "Income", Value = income.MonthlyIncome };
            Chart[1] = new PieChartModel { Name = "Expenses", Value = expenses.MonthlyExpenses };
            Chart[2] = new PieChartModel { Name = "Savings", Value = savings.MonthlySavings };
            return Chart;
        }

        public PieChartModel[] SetTrackedGroupBarChart(BudgetModel income, BudgetModel savings, BudgetModel expenses)
        {
            PieChartModel[] Chart = new PieChartModel[3];
            Chart[0] = new PieChartModel { Name = "Income", Value = income.TrackedMonthlyIncome };
            Chart[1] = new PieChartModel { Name = "Expenses", Value = expenses.TrackedMonthlyExpenses };
            Chart[2] = new PieChartModel { Name = "Savings", Value = savings.TrackedMonthlySavings };
            return Chart;
        }

        public ApexChartOptions<PieChartModel> SetOptionsForBarChart(ApexChartOptions<PieChartModel> options)
        {
            options = new ApexChartOptions<PieChartModel>
            {
                PlotOptions = new PlotOptions
                {
                    Bar = new PlotOptionsBar
                    {
                        Horizontal = true
                    }
                }
            };

            return options;
        }

        public string GetPointColor(PieChartModel model)
        {
            switch (model.Name)
            {
                case "TrackedEmployment":
                    return "#e3001b";
                case "TrackedSideHustle":
                    return "#005ba3";
                case "TrackedDividends":
                    return "#ffd500";
                case "TrackedEmergencyFund":
                    return "#e3001b";
                case "TrackedRetirementAccount":
                    return "#005ba3";
                case "TrackedVacation":
                    return "#ffd500";
                case "TrackedHealthNeeds":
                    return "#00783c";
                case "TrackedHousing":
                    return "#87bde4";
                case "TrackedGroceries":
                    return "#fbb4c0";
                case "TrackedUtilities":
                    return "#bbabe5";
                case "TrackedMedicine":
                    return "#f1e0c8";
                case "TrackedClothing":
                    return "#89d9d6";
                case "TrackedMedia":
                    return "#dae6a3";
                case "TrackedInsuranses":
                    return "#c1d6d5";
                case "TrackedTransportation":
                    return "#f29b9b";
                case "Income":
                    return "#bbabe5";
                case "Savings":
                    return "#87bde4";
                case "Expenses":
                    return "#fbb4c0";
                default:
                    return "#87775d";
            }
        }
    }
}
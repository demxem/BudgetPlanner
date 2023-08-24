using ApexCharts;
using Client.Models;

namespace Client.Services;

public class Charts
{
    public PieChartModel[] SetActualBudgetForGroupBarChart(BudgetModel income, BudgetModel savings, BudgetModel expenses)
    {
        PieChartModel[] Chart = new PieChartModel[3];

        Chart[0] = new PieChartModel { Name = "Income", Value = income.MonthlyIncome };
        Chart[1] = new PieChartModel { Name = "Expenses", Value = expenses.MonthlyExpenses };
        Chart[2] = new PieChartModel { Name = "Savings", Value = savings.MonthlySavings };

        return Chart;
    }

    public PieChartModel[] SetTrackedBudgetForGroupBarChart(BudgetModel income, BudgetModel savings, BudgetModel expenses)
    {
        PieChartModel[] Chart = new PieChartModel[3];

        Chart[0] = new PieChartModel { Name = "Income", Value = income.TrackedMonthlyIncome };
        Chart[1] = new PieChartModel { Name = "Expenses", Value = expenses.TrackedMonthlyExpenses };
        Chart[2] = new PieChartModel { Name = "Savings", Value = savings.TrackedMonthlySavings };

        return Chart;
    }

    public ApexChartOptions<PieChartModel> MakeBarChartHorizontal(ApexChartOptions<PieChartModel> options)
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

    public string GetPointColor(PieChartModel chart)
    {
        switch (chart.Name)
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

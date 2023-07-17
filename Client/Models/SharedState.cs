using Client.Models;

namespace Client.Services;

public class SharedState
{
    public MonthModel? SelectedIncome { get; set; }
    public MonthModel? SelectedSavings { get; set; }
    public MonthModel? SelectedExpenses { get; set; }
}

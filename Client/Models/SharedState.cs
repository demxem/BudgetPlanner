using Client.Models;

namespace Client.Services;

public class SharedState
{
    public BudgetModel? SelectedIncome { get; set; }
    public BudgetModel? SelectedSavings { get; set; }
    public BudgetModel? SelectedExpenses { get; set; }
}

using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Client.Services;

public class NavMenue
{
    private string _selectedMonth;
    private string _selectedYear;

    public NavMenue(string selectedMonth)
    {
        _selectedMonth = selectedMonth;
    }
    public NavMenue(string selectedYear, string selectedMonth)
    {
        _selectedYear = selectedYear;
        _selectedMonth = selectedMonth;
    }

    [CascadingParameter] MudDialogInstance MudDialog { get; set; }
    public void Submit()
    {
        MudDialog.Close(DialogResult.Ok(true));
    }
    public void Cancel() => MudDialog.Cancel();

}

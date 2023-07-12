using Client.Models;

namespace Client.Services;

public class DataFilter
{

    public IList<YearModel>? Years = new List<YearModel>();
    public IList<MonthModel>? IncomeByEachMonth = new List<MonthModel>();
    public IList<MonthModel>? SavingsByEachMonth = new List<MonthModel>();
    public IList<MonthModel>? ExpensesByEachMonth = new List<MonthModel>();
    public List<MonthModel>? Months = new List<MonthModel>();
    public IList<IncomeModel>? Income = new List<IncomeModel>();
    private int _selectedYearId;
    private int _selectedMonthId;
    public MonthModel? _filteredIncome { get; set; }
    public MonthModel? _filteredSavings { get; set; }
    public MonthModel? _filteredExpenses { get; set; }

    // public DataFilter(List<MonthModel> income, List<MonthModel> savings, List<MonthModel> expenses, List<MonthModel> months)
    // {
    //     IncomeByEachMonth = income;
    //     SavingsByEachMonth = savings;
    //     ExpensesByEachMonth = expenses;
    //     Months = months;
    // }

    public void SetSelectedYear(YearModel year)
    {
        _selectedYearId = year.Id;
    }

    public void FilterMonthOnSelect(string _selectedMonth)
    {
        _selectedMonthId = Months.Where(m => m.Name == _selectedMonth && m.YearId == _selectedYearId).Select(m
        => m.Id).FirstOrDefault();
    }
    public void FilterIncomeOnSelect()
    {
        _filteredIncome = IncomeByEachMonth.Where(i => i.Id == _selectedMonthId && i.YearId == _selectedYearId).Select(i =>
        i).FirstOrDefault();
    }
    public void FilterSavingsOnSelect()
    {
        _filteredSavings = SavingsByEachMonth.Where(s => s.Id == _selectedMonthId && s.YearId == _selectedYearId).Select(s =>
        s).FirstOrDefault();

    }
    public void FilterExpensesOnSelect()
    {
        _filteredExpenses = ExpensesByEachMonth.Where(e => e.Id == _selectedMonthId && e.YearId == _selectedYearId).Select(e
        => e).FirstOrDefault();
    }
}

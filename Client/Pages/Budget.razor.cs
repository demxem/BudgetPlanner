using MudBlazor;
using Client.Models;

namespace Client.Pages
{
    public partial class Budget
    {
        private IEnumerable<BudgetModel>? Expenses = new List<BudgetModel>();
        private IEnumerable<BudgetModel>? Savings = new List<BudgetModel>();
        private IEnumerable<BudgetModel>? Income = new List<BudgetModel>();
        private IEnumerable<YearModel>? Years = new List<YearModel>();
        private YearModel? inputYear;
        private YearModel? selectedYear = new YearModel { Name = "" };

        private TableApplyButtonPosition applyButtonPosition = TableApplyButtonPosition.Start;
        private TableEditButtonPosition editButtonPosition = TableEditButtonPosition.Start;
        private TableEditTrigger editTrigger = TableEditTrigger.EditButton;
        private List<string> editEvents = new();
        private List<string> messages = new List<string>();

        private int activeTabNumber = 0;
        private bool dense = true;
        private bool hover = true;
        private bool ronly = false;
        private bool canCancelEdit = true;
        private bool blockSwitch = false;
        private string searchString = "";
        private BudgetModel incomeSelectedOnRowClick = new BudgetModel { Name = "" };
        private BudgetModel savingsSelectedOnRowClick = new BudgetModel { Name = "" };
        private BudgetModel expensesSelectedOnRowClick = new BudgetModel { Name = "" };

        protected override async Task OnInitializedAsync()
        {
            Savings = await savingsApiClient.GetSavingByEachMonthAsync();
            Income = await incomeApiClient.GetIncomeByEachMonthAsync();
            Years = await yearsApiClient.GetYearsAsync();
            Expenses = await expensesApiClient.GetExpensesByEachMonthAsync();
            MessageService.OnMessage += MessageHandler;
        }

        public void Dispose()
        {
            MessageService.OnMessage -= MessageHandler;
        }

        private async void MessageHandler(string message)
        {
            if (message != null)
                messages.Add(message);
            else
                messages.Clear();
            StateHasChanged();
            if (message!.Equals("YearPosted") || message.Equals("yearDeleted"))
            {
                await GetYearsAsync();
            }
        }
        public async Task GetExpensesAsync()
        {
            Expenses = await expensesApiClient.GetExpensesByEachMonthAsync();
            StateHasChanged();
        }

        public async Task GetYearsAsync()
        {
            Years = await yearsApiClient.GetYearsAsync();
        }

        public async Task GetSavingsAsync()
        {
            Savings = await savingsApiClient.GetSavingByEachMonthAsync();
        }

        public async Task GetIncomeAsync()
        {
            Income = await incomeApiClient.GetIncomeByEachMonthAsync();
        }

        public async Task GetIncomeByYearIdAsync(int yearId)
        {
            Income = await incomeApiClient.GetIncomeByYearId(yearId);
            StateHasChanged();
        }

        public async Task GetExpensesByYearIdAsync(int yearId)
        {
            Expenses = await expensesApiClient.GetExpensesByYearId(yearId);
            StateHasChanged();
        }

        public async Task GetSavingsByYearIdAsync(int yearId)
        {
            Savings = await savingsApiClient.GetSavingsByYearId(yearId);
            StateHasChanged();
        }

        public async Task DeleteIncomeAsync(int id)
        {
            await incomeApiClient.DeleteIncomeByIdAsync(id);
            await GetIncomeAsync();
        }

        public async Task DeleteSavingsAsync(int id)
        {
            await savingsApiClient.DeleteSavingsByIdAsync(id);
            await GetSavingsAsync();
        }

        public async Task DeleteExpensesAsync(int id)
        {
            await expensesApiClient.DeleteExpensesByIdAsync(id);
            await GetExpensesAsync();
        }

        private void ClearEventLog()
        {
            editEvents.Clear();
        }

        private void AddEditionEvent(string message)
        {
            editEvents.Add(message);
            StateHasChanged();
        }

        private async void SavingsCommited(object savings)
        {
            await savingsApiClient.UpdateSavingsAsync(savingsSelectedOnRowClick.Savings);
            await GetSavingsAsync();
            AddEditionEvent($"RowEditCommit event: Changes to Element {((BudgetModel)savings).Name} committed");
        }

        private async void IncomeCommited(object income)
        {
            await incomeApiClient.UpdateIncomeAsync(incomeSelectedOnRowClick.Income);
            await GetIncomeAsync();
            AddEditionEvent($"RowEditCommit event: Changes to Element {((BudgetModel)income).Name} committed");
        }

        private async void ExpensesCommited(object expenses)
        {
            await expensesApiClient.UpdateExpensesAsync(expensesSelectedOnRowClick.Expenses);
            await GetExpensesAsync();
            AddEditionEvent($"RowEditCommit event: Changes to Element {((BudgetModel)expenses).Name} committed");
        }

        private void OpenSubmitIncomeDialog()
        {
            DialogOptions closeOnEscapeKey = new DialogOptions()
            {
                CloseOnEscapeKey = true
            };
            DialogService.Show<IncomeSubmitForm>("Add Income", closeOnEscapeKey);
        }

        private void OpenSubmitExpensesDialog()
        {
            DialogOptions closeOnEscapeKey = new DialogOptions()
            {
                CloseOnEscapeKey = true
            };
            DialogService.Show<ExpensesSubmitForm>("Add Expenses", closeOnEscapeKey);
        }

        private void OpenSubmitSavingsDialog()
        {
            DialogOptions closeOnEscapeKey = new DialogOptions()
            {
                CloseOnEscapeKey = true
            };
            DialogService.Show<SavingsSubmitForm>("Add Savings", closeOnEscapeKey);
        }

        private void OpenSubmitYearDialog()
        {
            DialogOptions closeOnEscapeKey = new DialogOptions()
            {
                CloseOnEscapeKey = true
            };
            DialogService.Show<YearSubmitForm>("Add Year", closeOnEscapeKey);
        }

        private void OpenDeleteYearDialog()
        {
            DialogOptions closeOnEscapeKey = new DialogOptions()
            {
                CloseOnEscapeKey = true
            };
            DialogService.Show<YearDeleteForm>(@"This action will delete complete year budget plan", closeOnEscapeKey);
        }

        //Method for button selector//
        public async void SetSelectedYear(YearModel year)
        {
            selectedYear = year;
            await GetIncomeByYearIdAsync(selectedYear.Id);
            await GetExpensesByYearIdAsync(selectedYear.Id);
            await GetSavingsByYearIdAsync(selectedYear.Id);
            CalculateYearlyIncome();
            CalculateYearlyExpenses();
            CalculateYearlySavings();
        }

        public decimal CalculateYearlyUndistributedIncome()
        {
            var totalIncome = CalculateYearlyIncome();
            var totalSavings = CalculateYearlySavings();
            var totalExpenses = CalculateYearlyExpenses();
            var undistributedIncome = totalIncome - (totalSavings + totalExpenses);
            return undistributedIncome;
        }

        public decimal CalculateMonthlyUndistributedIncome()
        {
            var montlhlyIncome = CalculateMonthlyIncome();
            var monthlySavings = CalculateMonthlySavings();
            var monthlyExpenses = CalculateMonthlyExpenses();
            var undistributedMonthlyIncome = montlhlyIncome - (monthlySavings + monthlyExpenses);
            return undistributedMonthlyIncome;
        }

        public decimal CalculateMonthlyIncome()
        {
            if (activeTabNumber == 0)
            {
                return Income!.Where(income => income.Equals(incomeSelectedOnRowClick)).Select(income => income.MonthlyIncome).FirstOrDefault(0);
            }

            if (activeTabNumber == 1)
            {
                return Income!.Where(income => income!.Name!.Equals(savingsSelectedOnRowClick.Name)).Select(income => income.MonthlyIncome).FirstOrDefault(0);
            }

            return Income!.Where(income => income!.Name!.Equals(expensesSelectedOnRowClick.Name)).Select(income => income.MonthlyIncome).FirstOrDefault(0);
        }

        public decimal CalculateMonthlySavings()
        {
            if (activeTabNumber == 0)
            {
                return Savings!.Where(savings => savings!.Name!.Equals(incomeSelectedOnRowClick.Name)).Select(savings => savings.MonthlySavings).FirstOrDefault(0);
            }

            if (activeTabNumber == 1)
            {
                return Savings!.Where(savings => savings.Equals(savingsSelectedOnRowClick)).Select(savings => savings.MonthlySavings).FirstOrDefault(0);
            }

            return Savings!.Where(savings => savings!.Name!.Equals(expensesSelectedOnRowClick.Name)).Select(savings => savings.MonthlySavings).FirstOrDefault(0);
        }

        public decimal CalculateMonthlyExpenses()
        {
            if (activeTabNumber == 0)
            {
                return Expenses!.Where(expenses => expenses!.Name!.Equals(incomeSelectedOnRowClick.Name)).Select(expenses => expenses.MonthlyExpenses).FirstOrDefault(0);
            }

            if (activeTabNumber == 1)
            {
                return Expenses!.Where(expenses => expenses!.Name!.Equals(savingsSelectedOnRowClick.Name)).Select(expenses => expenses.MonthlyExpenses).FirstOrDefault(0);
            }

            return Expenses!.Where(expenses => expenses.Equals(expensesSelectedOnRowClick)).Select(expenses => expenses.MonthlyExpenses).FirstOrDefault(0);
        }

        public decimal CalculateYearlyIncome()
        {
            return Income!.Select(income => income.MonthlyIncome).Sum();
        }

        public decimal CalculateYearlySavings()
        {
            return Savings!.Select(savings => savings.MonthlySavings).Sum();
        }

        public decimal CalculateYearlyExpenses()
        {
            return Expenses!.Select(expenses => expenses.MonthlyExpenses).Sum();
        }

        private bool FilterSavings(BudgetModel savings)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (savings.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (savings.Savings.EmergencyFund.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (savings.Savings.Vacation.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (savings.Savings.HealthNeeds.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (savings.Savings.RetirementAccount.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (savings.Savings.Date.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (savings.MonthlySavings.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{savings.Name} {savings.MonthlySavings.ToString()} {savings.Savings.EmergencyFund.ToString()} {savings.Savings.Vacation.ToString()} {savings.Savings.HealthNeeds.ToString()} {savings.Savings.Vacation.ToString()}".Contains(searchString))
                return true;
            return false;
        }

        private bool FilterIncome(BudgetModel income)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (income.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (income.Income.Employment.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (income.Income.SideHustle.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (income.Income.Dividends.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (income.Income.Date.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (income.MonthlyIncome.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{income.Name} {income.MonthlySavings.ToString()} {income.Income.Employment.ToString()} {income.Income.SideHustle.ToString()} {income.Income.Dividends.ToString()}".Contains(searchString))
                return true;
            return false;
        }

        private bool FilterExpenses(BudgetModel expenses)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (expenses.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (expenses.Expenses.Clothing.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (expenses.Expenses.Groceries.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (expenses.Expenses.Housing.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (expenses.Expenses.Insuranses.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (expenses.Expenses.Media.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (expenses.Expenses.Medicine.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (expenses.Expenses.Transportation.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (expenses.Expenses.Utilities.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (expenses.Expenses.Vacation.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (expenses.Expenses.Date.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (expenses.MonthlyIncome.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ($"{expenses.Name} {expenses.MonthlySavings.ToString()} {expenses.Expenses.Clothing.ToString()} {expenses.Expenses.Groceries.ToString()} {expenses.Expenses.Housing.ToString()} {expenses.Expenses.Insuranses.ToString()} {expenses.Expenses.Media.ToString()} {expenses.Expenses.Medicine.ToString()} {expenses.Expenses.Transportation.ToString()} {expenses.Expenses.Utilities.ToString()} {expenses.Expenses.Vacation.ToString()}".Contains(searchString))
                return true;
            return false;
        }
    }
}
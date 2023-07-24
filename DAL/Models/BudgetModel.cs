namespace DAL.Models
{
    public class BudgetModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } = "";
        public string Category { get; set; } = "";
        public double Amount { get; set; }
        public string Details { get; set; } = "";
        public double Balance { get; set; }
        public int IncomeId { get; set; }
        public int SavingsId { get; set; }
        public int ExpensesId { get; set; }
    }
}
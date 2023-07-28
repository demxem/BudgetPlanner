namespace DAL.Models
{
    public class DetailedBudgetModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } = "";
        public string Category { get; set; } = "";
        public double Amount { get; set; }
        public string Details { get; set; } = "";
        public double Balance { get; set; }
        public double Tracked { get; set; }
        public int MonthId { get; set; }
        public int YearId { get; set; }
    }
}
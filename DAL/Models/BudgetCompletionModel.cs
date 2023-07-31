namespace DAL.Models
{
    public class BudgetCompletionModel
    {
        public int MonthId { get; set; }
        public int YearId { get; set; }
        public float CompletedEmployment { get; set; }
        public float CompletedSidehustle { get; set; }
        public float CompletedDividends { get; set; }
        public float CompletedHousing { get; set; }
        public float CompletedGroceries { get; set; }
        public float CompletedUtilities { get; set; }
        public float CompletedExpensesVacation { get; set; }
        public float CompletedTransportation { get; set; }
        public float CompletedMedicine { get; set; }
        public float CompletedClothing { get; set; }
        public float CompletedMedia { get; set; }
        public float CompletedInsuranses { get; set; }
        public float CompletedEmergencyFund { get; set; }
        public float CompletedRetirementAccount { get; set; }
        public float CompletedSavingsVacation { get; set; }
        public float CompletedHealthNeeds { get; set; }
    }
}
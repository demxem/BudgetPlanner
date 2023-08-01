namespace DAL.Models;

public class ExpensesModel
{
    public int Id { get; set; }
    public decimal Housing { get; set; }
    public decimal Groceries { get; set; }
    public decimal Utilities { get; set; }
    public decimal Vacation { get; set; }
    public decimal Transportation { get; set; }
    public decimal Medicine { get; set; }
    public decimal Clothing { get; set; }
    public decimal Media { get; set; }
    public decimal Insuranses { get; set; }
    public decimal TrackedHousing { get; set; }
    public decimal TrackedGroceries { get; set; }
    public decimal TrackedUtilities { get; set; }
    public decimal TrackedVacation { get; set; }
    public decimal TrackedTransportation { get; set; }
    public decimal TrackedMedicine { get; set; }
    public decimal TrackedClothing { get; set; }
    public decimal TrackedMedia { get; set; }
    public decimal TrackedInsuranses { get; set; }
    public DateTime Date { get; set; }
    public int MonthId { get; set; }
    public int YearId { get; set; }
}


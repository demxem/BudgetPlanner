namespace DAL.Models;

public class IncomeModel
{
    public int Id { get; set; }
    public decimal Employment { get; set; }
    public decimal SideHustle { get; set; } // paritial empoyment
    public decimal Dividends { get; set; }
    public decimal TrackedEmployment { get; set; }
    public decimal TrackedSideHustle { get; set; } // paritial empoyment
    public decimal TrackedDividends { get; set; }
    public DateTime Date { get; set; }
    public int MonthId { get; set; }
    public int YearId { get; set; }
}


namespace Client.Models;

public class IncomeModel
{
    public int Id { get; set; }
    public float Employment { get; set; }
    public float SideHustle { get; set; } // paritial empoyment
    public float Dividends { get; set; }
    public float TrackedEmployment { get; set; }
    public float TrackedSideHustle { get; set; } // paritial empoyment
    public float TrackedDividends { get; set; }
    public DateTime Date { get; set; }
    public int MonthId { get; set; }
    public int YearId { get; set; }

}

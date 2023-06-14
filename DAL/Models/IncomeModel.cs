namespace DAL.Models;

public class IncomeModel
{
    public int IncomeId { get; set; }
    public string? Employments { get; set; }
    public string? SideHustle { get; set; } // paritial empoyment
    public string? Dividends { get; set; }
}


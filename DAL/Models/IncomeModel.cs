namespace DAL.Models;

public class IncomeModel
{
    public int Id { get; set; }
    public float Employment { get; set; }
    public float SideHustle { get; set; } // paritial empoyment
    public float Dividends { get; set; }
    public DateTime Date { get; set; }
}


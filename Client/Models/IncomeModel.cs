namespace Client.Models;

public class IncomeModel
{
    public int Id { get; set; }
    public double Employment { get; set; }
    public double SideHustle { get; set; } // paritial empoyment
    public double Dividends { get; set; }
    public DateTime Date { get; set; }
}


namespace Client.Models;

public class ExpensesModel
{
    public int Id { get; set; }
    public double Housing { get; set; }
    public double Groceries { get; set; }
    public double Utilities { get; set; }
    public double Vacation { get; set; }
    public double Transportation { get; set; }
    public double Medicine { get; set; }
    public double Clothing { get; set; }
    public double Media { get; set; }
    public double Insuranses { get; set; }
    public DateTime Date { get; set; }
    public int MonthId { get; set; }
}


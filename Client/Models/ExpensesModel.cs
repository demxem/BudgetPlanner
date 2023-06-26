namespace Client.Models;

public class ExpensesModel
{
    public int Id { get; set; }
    public float Housing { get; set; }
    public float Groceries { get; set; }
    public float Utilities { get; set; }
    public float Vacation { get; set; }
    public float Transportation { get; set; }
    public float Medicine { get; set; }
    public float Clothing { get; set; }
    public float Media { get; set; }
    public float Insuranses { get; set; }
    public DateTime Date { get; set; }
    public int MonthId { get; set; }
}


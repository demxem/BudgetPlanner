namespace Client.Models;

public class SavingsModel
{
    public int Id { get; set; }
    public double EmergencyFund { get; set; }
    public double RetirementAccount { get; set; }
    public double Vacation { get; set; }
    public double HealthNeeds { get; set; }
    public DateTime Date { get; set; }
    public int MonthId { get; set; }
}


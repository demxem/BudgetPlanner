namespace DAL.Models;

public class SavingsModel
{
    public int SavingsId { get; set; }
    public float EmergencyFund { get; set; }
    public float RetirementAccount { get; set; }
    public float Vacation { get; set; }
    public float HealthNeeds { get; set; }
    public DateTime Date { get; set; }
}


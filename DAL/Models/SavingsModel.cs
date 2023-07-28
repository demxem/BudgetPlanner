namespace DAL.Models;

public class SavingsModel
{
    public int Id { get; set; }
    public float EmergencyFund { get; set; }
    public float RetirementAccount { get; set; }
    public float Vacation { get; set; }
    public float HealthNeeds { get; set; }
    public float TrackedEmergencyFund { get; set; }
    public float TrackedRetirementAccount { get; set; }
    public float TrackedVacation { get; set; }
    public float TrackedHealthNeeds { get; set; }
    public DateTime Date { get; set; }
    public int MonthId { get; set; }
    public int YearId { get; set; }
}


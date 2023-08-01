namespace Client.Models;

public class SavingsModel
{
    public int Id { get; set; }
    public decimal EmergencyFund { get; set; }
    public decimal RetirementAccount { get; set; }
    public decimal Vacation { get; set; }
    public decimal HealthNeeds { get; set; }
    public decimal TrackedEmergencyFund { get; set; }
    public decimal TrackedRetirementAccount { get; set; }
    public decimal TrackedVacation { get; set; }
    public decimal TrackedHealthNeeds { get; set; }
    public DateTime Date { get; set; }
    public int MonthId { get; set; }
    public int YearId { get; set; }
}


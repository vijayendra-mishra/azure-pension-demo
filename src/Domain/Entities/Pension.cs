namespace Domain.Entities;

public class Pension
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public DateTime PensionStartDate { get; set; }
    public decimal MonthlyAmount { get; set; }
    public decimal TotalContributions { get; set; }
    public string PensionType { get; set; } = string.Empty;
    public string EmployerName { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? LastUpdated { get; set; }
}

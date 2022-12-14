namespace PoSSapi.Domain.Entities;

public class StaffMember
{
    public Guid Id { get; set; }
    public string Position { get; set; } // Enum?
    public decimal Salary { get; set; }
}

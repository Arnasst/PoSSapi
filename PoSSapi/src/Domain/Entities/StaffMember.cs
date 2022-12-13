namespace PoSSapi.Domain.Entities;

public class StaffMember
{
    public Guid Id { get; set; }
    public string position { get; set; } // Enum?
    public float salary { get; set; }
}

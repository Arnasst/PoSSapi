namespace PoSSapi.Domain.Entities;

public class StaffMember : BaseAuditableEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
}

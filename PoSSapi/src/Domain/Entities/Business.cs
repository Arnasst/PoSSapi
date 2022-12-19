namespace PoSSapi.Domain.Entities;

public class Business : BaseAuditableEntity
{
    public Guid Id { get; set; }
    public ICollection<BusinessLocation> Locations { get; set; }
    public Guid ManagerId { get; set; }
}

namespace PoSSapi.Domain.Entities;

public class Business
{
    public Guid Id { get; set; }
    public ICollection<BusinessLocation> Locations { get; set; }
    public Guid? ManagerId { get; set; }
    public User? Manager { get; set; }
}

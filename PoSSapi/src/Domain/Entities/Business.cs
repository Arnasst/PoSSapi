namespace PoSSapi.Domain.Entities;

public class Business
{
    public Guid Id { get; set; }
    public ICollection<BusinessLocation> Location { get; set; }
    //Needs BusinessType enum but I am unsure what values it could have
}

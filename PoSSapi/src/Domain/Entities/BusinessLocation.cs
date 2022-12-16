namespace PoSSapi.Domain.Entities;

public class BusinessLocation
{
    public Guid Id { get; set; }
    public string Location { get; set; }
    public Business Business { get; set; }
}

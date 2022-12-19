namespace PoSSapi.Domain.Entities;

public class BusinessLocation
{
    public Guid Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int BuildingNumber { get; set; }
    public int Floor { get; set; }
    public string PostCode { get; set; }
    public Business Business { get; set; }
    public Guid BusinessId { get; set; }
}

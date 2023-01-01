using AutoMapper;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.BusinessLocations.Dtos;

public class BusinessLocationDto : IMapFrom<BusinessLocation>
{
    public Guid Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int BuildingNumber { get; set; }
    public int Floor { get; set; }
    public string PostCode { get; set; }
    public Guid BusinessId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<BusinessLocation, BusinessLocationDto>();
    }
}
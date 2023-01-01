using AutoMapper;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Businesses.Dtos;

public class BusinessDto : IMapFrom<Business>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? ManagerId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Business, BusinessDto>();
    }
}

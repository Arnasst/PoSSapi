using AutoMapper;
using PoSSapi.Domain.Enums;
using PoSSapi.Application.Common.Mappings;
using PoSSapi.Domain.Entities;

namespace PoSSapi.Application.Users.Dtos;

public class UserDto : IMapFrom<User>
{
    public Guid Id { get; set; }
    public Guid BusinessId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserType UserType { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserDto>();
    }
}

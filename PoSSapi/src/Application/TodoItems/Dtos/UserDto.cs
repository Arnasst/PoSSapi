using PoSSapi.Domain.Enums;

namespace PoSSapi.Application.TodoItems.Dtos;

public class UserDto
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
}

namespace PoSSapi.Domain.Entities;

using PoSSapi.Domain.Enums;

public class User
{
    public Guid Id { get; set; }
    public int BusinessId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserType UserType { get; set; }
}

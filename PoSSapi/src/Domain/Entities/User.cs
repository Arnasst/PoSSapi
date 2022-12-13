namespace PoSSapi.Domain.Entities;

public class User
{
    public int ID { get; set; }
    public int BusinessId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserType { get; set; } // Enum
}

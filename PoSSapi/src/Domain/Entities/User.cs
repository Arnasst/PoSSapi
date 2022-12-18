namespace PoSSapi.Domain.Entities;

using PoSSapi.Domain.Enums;

public class User : BaseAuditableEntity
{
    public Guid Id { get; set; }
    public Business Business { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserType UserType { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<Payment> Payments { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}

using PoSSapi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PoSSapi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Business> Businesses { get; set; }
    DbSet<BusinessLocation> BusinesseLocations { get; set; }
    DbSet<Dish> Dishes { get; set; }
    DbSet<DishIngredient> DishIngredients { get; set; }
    DbSet<Ingredient> Ingredients { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<OrderedDish> OrderedDishes { get; set; }
    DbSet<Payment> Payments { get; set; }
    DbSet<Reservation> Reservations { get; set; }
    DbSet<User> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

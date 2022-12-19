using System.Reflection;
using PoSSapi.Application.Common.Interfaces;
using PoSSapi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace PoSSapi.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IMediator _mediator;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IMediator mediator)
        : base(options)
    {
        _mediator = mediator;
    }

    public DbSet<Business> Businesses { get; set; }
    public DbSet<BusinessLocation> BusinessLocations { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<DishIngredient> DishIngredients { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderedDish> OrderedDishes { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        var dishIngredient = builder.Entity<DishIngredient>();
        var payment = builder.Entity<Payment>();
        var orderedDish = builder.Entity<OrderedDish>();
        var business = builder.Entity<Business>();

        dishIngredient
            .HasOne<Dish>(x => x.Dish)
            .WithMany(x => x.Ingredients)
            .HasForeignKey(x => x.DishId);

        dishIngredient
            .HasOne<Ingredient>(x => x.Ingredient)
            .WithMany()
            .HasForeignKey(x => x.IngredientId);

        orderedDish
            .HasOne<Order>(x => x.Order)
            .WithMany(x => x.Dishes)
            .HasForeignKey(x => x.OrderId);

        orderedDish
            .HasOne<Dish>(x => x.Dish)
            .WithMany()
            .HasForeignKey(x => x.DishId);

        payment
            .HasOne<Order>(x => x.Order)
            .WithMany(x => x.Payments)
            .HasForeignKey(x => x.OrderId);

        payment
            .HasOne<User>(x => x.Customer)
            .WithMany()
            .HasForeignKey(x => x.CustomerId);

        business
            .HasMany<User>()
            .WithOne(x => x.Business)
            .HasForeignKey(x => x.BusinessId);

        business
            .HasMany<BusinessLocation>(x => x.Locations)
            .WithOne(x => x.Business)
            .HasForeignKey(x => x.BusinessId);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);

        return await base.SaveChangesAsync(cancellationToken);
    }
}

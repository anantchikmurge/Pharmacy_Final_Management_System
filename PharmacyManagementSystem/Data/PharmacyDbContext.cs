using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Data;

// DbContext connects the application with the database
// IdentityDbContext is used so we can use ASP.NET Identity for users
public class PharmacyDbContext : IdentityDbContext<AppUser>
{
    // Constructor used by Entity Framework to configure the database connection
    public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options)
        : base(options)
    {
    }

    // Table for storing drugs
    public DbSet<Drug> Drugs { get; set; }

    // Table for storing supplier details
    public DbSet<Supplier> Suppliers { get; set; }

    // Table for storing orders placed by doctors
    public DbSet<Order> Orders { get; set; }

    // Table for storing items inside an order
    public DbSet<OrderItem> OrderItems { get; set; }

    // Table used for generating sales reports
    public DbSet<Sale> Sales { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Store all money values with a consistent SQL Server precision/scale.
        builder.Entity<Drug>()
            .Property(drug => drug.Price)
            .HasPrecision(18, 2);

        builder.Entity<Order>()
            .Property(order => order.TotalAmount)
            .HasPrecision(18, 2);

        builder.Entity<OrderItem>()
            .Property(orderItem => orderItem.UnitPrice)
            .HasPrecision(18, 2);

        builder.Entity<OrderItem>()
            .Property(orderItem => orderItem.Subtotal)
            .HasPrecision(18, 2);

        builder.Entity<Sale>()
            .Property(sale => sale.SaleAmount)
            .HasPrecision(18, 2);
    }
}

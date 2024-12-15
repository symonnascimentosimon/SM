using Microsoft.EntityFrameworkCore;
using SM.Shared.Entities.Orders;

namespace SM.DbMigrator;

public class SmDbcontext : DbContext
{
    public SmDbcontext(DbContextOptions<SmDbcontext> options)
        : base(options)
    { }
    
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
 //   public DbSet<Payment> Payments { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .IsRequired(true)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .IsRequired(true)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Product)
            .WithMany(p => p.OrderItems)
            .IsRequired(true)
            .HasForeignKey(oi => oi.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // modelBuilder.Entity<Payment>()
        //     .HasOne(p => p.Order)
        //     .WithOne(o => o.Payment)
        //     .IsRequired(true)
        //     .HasForeignKey<Payment>(p => p.OrderId);
    }
}
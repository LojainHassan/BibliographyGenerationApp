using BibliographyGenerationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliographyGenerationApp.Data;

public class BibliographyDbContext : DbContext
{
    public BibliographyDbContext(DbContextOptions<BibliographyDbContext> options)
        : base(options)
    {
    }

    public DbSet<DepositOrder> DepositOrders => Set<DepositOrder>();

    public DbSet<DepositOrderToBook> DepositOrderToBooks => Set<DepositOrderToBook>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepositOrder>(entity =>
        {
            entity.ToTable("DepositOrder");
            entity.HasKey(order => order.Id);
            entity.Property(order => order.OrderNumber).IsRequired().HasMaxLength(50);
            entity.HasIndex(order => order.OrderNumber).IsUnique();
            entity.Property(order => order.DepositorName).IsRequired().HasMaxLength(200);
            entity.Property(order => order.Notes).HasMaxLength(1000);
            entity.Property(order => order.Status).HasConversion<string>().HasMaxLength(32);
            entity.HasMany(order => order.Books)
                .WithOne(line => line.DepositOrder)
                .HasForeignKey(line => line.DepositOrderId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<DepositOrderToBook>(entity =>
        {
            entity.ToTable("DepositOrderToBook");
            entity.HasKey(line => line.Id);
            entity.Property(line => line.Title).IsRequired().HasMaxLength(500);
            entity.Property(line => line.Author).HasMaxLength(300);
            entity.Property(line => line.Isbn).HasMaxLength(20);
            entity.Property(line => line.Publisher).HasMaxLength(300);
            entity.Property(line => line.Quantity).HasDefaultValue(1);
            entity.HasIndex(line => line.DepositOrderId);
        });
    }
}

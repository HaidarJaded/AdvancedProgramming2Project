using APP2EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace APP2EFCore;

public class AppDBContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "Data source=WIN-ABOALAA\\SQLEXPRESS;Initial Catalog=APP2EFCore;integrated security=true;encrypt=false;";
        optionsBuilder.UseSqlServer(connectionString);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().Property(c => c.ProductsCount).HasDefaultValue(0);

        modelBuilder.Entity<Product>().Property(p => p.Count).HasDefaultValue(1);

        modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(10, 2)");

        modelBuilder.Entity<Invoice>().Property(i => i.Date).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Invoice>().Property(i => i.Total).HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Sale>().Property(s => s.Date).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Sale>().Property(s => s.ProductsTotalPrice).HasComputedColumnSql("[ProductsCount]*[ProductPrice]");

        modelBuilder.Entity<Sale>().Property(s => s.ProductPrice).HasColumnType("decimal(10, 2)");

        modelBuilder.Entity<Sale>().Property(s => s.ProductsTotalPrice).HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Sale>().Property(s => s.ProductsCount).HasDefaultValue(1);

        modelBuilder.Entity<Sale>().Property(s => s.profitRatio).HasColumnType("decimal(10, 2)");

        modelBuilder.Entity<Sale>().Property(s => s.profitRatio).HasDefaultValue(0);

        modelBuilder.Entity<Purchase>().Property(p => p.ProductsCount).HasDefaultValue(1);

        modelBuilder.Entity<Purchase>().Property(p => p.ProductsTotalPrice).HasComputedColumnSql("[ProductsCount]*[ProductPrice]");

        modelBuilder.Entity<Purchase>().Property(p => p.Date).HasDefaultValueSql("getdate()");

        modelBuilder.Entity<Purchase>().Property(p => p.ProductPrice).HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Purchase>().Property(p => p.ProductsTotalPrice).HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Center>().Property(p => p.ProfitRatio).HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Center>().Property(p => p.ProfitRatio).HasDefaultValue(0);

        modelBuilder.Entity<Center>().HasData(new Center()
        {
            Id = 1,
            ProfitRatio = 0,
        });
    }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Center> Centers { get; set; }
}


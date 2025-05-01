using Microsoft.EntityFrameworkCore;
using SnapCash.Domain.Entities;

namespace SnapCash.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Register> Registers { get; set; }
    public DbSet<Transfer> Transfers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=SnapCash.sqlite");
        base.OnConfiguring(optionsBuilder);   
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Register>().Property(user => user.UserType).HasConversion<string>();
    }
}
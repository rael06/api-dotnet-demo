using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;

namespace MyWebAPI.Infrastructure.Database;

public class AppDbContext : DbContext
{
  public DbSet<User> Users { get; set; }

  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<User>().HasKey(u => u.Id);
    modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();
    modelBuilder.Entity<User>().Property(u => u.Username).IsRequired();
    modelBuilder.Entity<User>().Property(u => u.Age).IsRequired();
    modelBuilder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
  }
}
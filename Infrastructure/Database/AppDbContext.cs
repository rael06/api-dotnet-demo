using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;

namespace MyWebAPI.Infrastructure.Database;

public class AppDbContext : DbContext
{
  public DbSet<User> Users { get; set; }
  public DbSet<Todo> Todos { get; set; }

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

    modelBuilder.Entity<Todo>().HasKey(t => t.Id);
    modelBuilder.Entity<Todo>().Property(t => t.Id).ValueGeneratedOnAdd();
    modelBuilder.Entity<Todo>().Property(t => t.Title).IsRequired();
    modelBuilder.Entity<Todo>().Property(t => t.Description).IsRequired(false);
    modelBuilder.Entity<Todo>().Property(t => t.CreationDate).IsRequired();
    modelBuilder.Entity<Todo>().Property(t => t.UpdateDate).IsRequired(false);
    modelBuilder.Entity<Todo>().Property(t => t.DueDate).IsRequired();
    modelBuilder.Entity<Todo>().Property(t => t.IsDone).IsRequired();
    modelBuilder.Entity<Todo>()
      .HasOne(t => t.User)
      .WithMany(u => u.Todos)
      .HasForeignKey(t => t.UserId)
      .IsRequired()
      .OnDelete(DeleteBehavior.Cascade);
  }
}
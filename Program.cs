using Microsoft.EntityFrameworkCore;
using MyWebAPI.Infrastructure.Database;
using MyWebAPI.Infrastructure.Database.Repositories;
using MyWebAPI.Services.TodoService;
using MyWebAPI.Services.UserService;

namespace MyWebAPI;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllers();

    // Add DbContext
    builder.Services.AddDbContext<AppDbContext>(options =>
      options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

    // Add Swagger/OpenAPI support
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IUserService, UserService>();

    builder.Services.AddScoped<ITodoRepository, TodoRepository>();
    builder.Services.AddScoped<ITodoService, TodoService>();

    var app = builder.Build();

    // Configure Swagger middleware
    if (app.Environment.IsDevelopment())
    {
      app.UseSwagger();
      app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
  }
}

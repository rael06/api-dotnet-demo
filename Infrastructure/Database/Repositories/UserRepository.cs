using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;
using MyWebAPI.Services.UserService;

namespace MyWebAPI.Infrastructure.Database.Repositories;

public class UserRepository : IUserRepository
{
  private readonly AppDbContext _context;

  public UserRepository(AppDbContext context)
  {
    _context = context;
  }

  public async Task<IEnumerable<User>> GetUsers(GetUsersInput input)
  {
    return await _context.Users.Where(u =>
      (input.MinAge == null || u.Age >= input.MinAge) &&
      (input.MaxAge == null || u.Age <= input.MaxAge)
    ).ToListAsync();
  }

  public async Task<User?> GetUserById(int userId)
  {
    return await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
  }

  public async Task<User> CreateUser(CreateUserInput input)
  {
    var passwordHash = input.Password + "_hashed";

    var newUser = new User(input.Username, input.Age, passwordHash);
    await _context.Users.AddAsync(newUser);
    await _context.SaveChangesAsync();

    return newUser;
  }

  public async Task DeleteUser(int userId)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

    if (user == null) return;

    _context.Users.Remove(user);
    await _context.SaveChangesAsync();
  }

  public async Task<User?> UpdateUser(UpdateUserInput input)
  {
    var user = await GetUserById(input.Id);

    if (user == null) return null;

    user.Username = input.Username;
    user.Age = input.Age;

    await _context.SaveChangesAsync();

    return user;
  }
}
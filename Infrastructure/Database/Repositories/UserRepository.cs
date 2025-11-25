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

  public IEnumerable<User> GetUsers(GetUsersInput input)
  {
    return _context.Users.Where(u =>
      (input.MinAge == null || u.Age >= input.MinAge) &&
      (input.MaxAge == null || u.Age <= input.MaxAge)
    );
  }

  public User? GetUserById(int userId)
  {
    return _context.Users.FirstOrDefault(u => u.Id == userId);
  }

  public User CreateUser(CreateUserInput input)
  {
    var passwordHash = input.Password + "_hashed";

    var newUser = new User(input.Username, input.Age, passwordHash);
    _context.Users.Add(newUser);
    _context.SaveChanges();

    return newUser;
  }

  public void DeleteUser(int userId)
  {
    var user = _context.Users.FirstOrDefault(u => u.Id == userId);

    if (user == null) return;

    _context.Users.Remove(user);
    _context.SaveChanges();
  }

  public User? UpdateUser(UpdateUserInput input)
  {
    var user = GetUserById(input.Id);

    if (user == null) return null;

    user.Username = input.Username;
    user.Age = input.Age;

    _context.SaveChanges();

    return user;
  }
}
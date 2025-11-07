using MyWebAPI.Models;
using MyWebAPI.Services;

namespace MyWebAPI.Repositories;

public class UserRepository : IUserRepository
{
  private static readonly List<User> users =
  [
    new User(1, "Alice", 30),
    new User(2, "Bob", 25),
    new User(3, "Charlie", 35)
  ];

  public IEnumerable<User> GetAllUsers()
  {
    return users;
  }
}
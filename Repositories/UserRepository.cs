using System.Collections;
using MyWebAPI.Models;
using MyWebAPI.Services;

namespace MyWebAPI.Repositories;

public class UserRepository : IUserRepository
{
  private static readonly IEnumerable<User> users =
  [
    new User(1, "Alice", 30, "hash1"),
    new User(2, "Bob", 25, "hash2"),
    new User(3, "Charlie", 35, "hash3")
  ];

  public IEnumerable<User> GetUsers(GetUsersInput input)
  {
    return users.Where(u =>
      (input.MinAge == null || u.Age >= input.MinAge) &&
      (input.MaxAge == null || u.Age <= input.MaxAge)
    );
  }

  public User? GetUserById(int userId)
  {
    return users.FirstOrDefault(u => u.Id == userId);
  }
}
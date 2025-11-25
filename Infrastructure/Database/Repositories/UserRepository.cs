using MyWebAPI.Models;
using MyWebAPI.Services.UserService;

namespace MyWebAPI.Infrastructure.Database.Repositories;

public class UserRepository : IUserRepository
{
  private static List<User> users =
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

  public User CreateUser(CreateUserInput input)
  {
    int newId = users.Max(u => u.Id) + 1;
    var passwordHash = input.Password + "_hashed";

    var newUser = new User(newId, input.Username, input.Age, passwordHash);
    users.Add(newUser);
    return newUser;
  }

  public void DeleteUser(int userId)
  {
    var user = users.FirstOrDefault(u => u.Id == userId);
    if (user == null) return;
    users.Remove(user);
  }

  public User? UpdateUser(UpdateUserInput input)
  {
    var user = users.FirstOrDefault(u => u.Id == input.Id);
    if (user == null) return null;

    user.Username = input.Username;
    user.Age = input.Age;

    return user;
  }
}
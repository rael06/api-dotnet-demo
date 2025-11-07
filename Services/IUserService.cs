using MyWebAPI.Models;

namespace MyWebAPI.Services;

public interface IUserService
{
  ICollection<User> GetUsers(GetUsersInput input);
  double GetAverageAge();
  User? GetUserById(int userId);
}

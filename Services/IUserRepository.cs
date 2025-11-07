using MyWebAPI.Models;

namespace MyWebAPI.Services;

public interface IUserRepository
{
  IEnumerable<User> GetUsers(GetUsersInput input);
  User? GetUserById(int userId);
}
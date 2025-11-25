using MyWebAPI.Models;

namespace MyWebAPI.Services.UserService;

public interface IUserRepository
{
  IEnumerable<User> GetUsers(GetUsersInput input);
  User? GetUserById(int userId);
  User CreateUser(CreateUserInput input);
  void DeleteUser(int userId);
  User? UpdateUser(UpdateUserInput input);
}
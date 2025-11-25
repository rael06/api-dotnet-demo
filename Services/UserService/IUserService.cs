using MyWebAPI.Models;

namespace MyWebAPI.Services.UserService;

public interface IUserService
{
  ICollection<User> GetUsers(GetUsersInput input);
  double GetAverageAge();
  User? GetUserById(int userId);
  User CreateUser(CreateUserInput input);
  DeleteUserOutput DeleteUser(int userId);
  UpdateUserOutput UpdateUser(UpdateUserInput input);
}

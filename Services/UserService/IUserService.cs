using MyWebAPI.Models;

namespace MyWebAPI.Services.UserService;

public interface IUserService
{
  Task<IEnumerable<User>> GetUsers(GetUsersInput input);
  Task<double> GetAverageAge();
  Task<User?> GetUserById(int userId);
  Task<User> CreateUser(CreateUserInput input);
  Task<DeleteUserOutput> DeleteUser(int userId);
  Task<User?> UpdateUser(UpdateUserInput input);
}

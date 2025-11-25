using MyWebAPI.Models;

namespace MyWebAPI.Services.UserService;

public interface IUserRepository
{
  Task<IEnumerable<User>> GetUsers(GetUsersInput input);
  Task<User?> GetUserById(int userId);
  Task<User> CreateUser(CreateUserInput input);
  Task DeleteUser(int userId);
  Task<User?> UpdateUser(UpdateUserInput input);
}
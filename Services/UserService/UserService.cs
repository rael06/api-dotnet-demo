using MyWebAPI.Models;

namespace MyWebAPI.Services.UserService;
public class UserService : IUserService
{
  private readonly IUserRepository _userRepository;
  public UserService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public async Task<IEnumerable<User>> GetUsers(GetUsersInput input)
  {
    var users = await _userRepository.GetUsers(input);
    return users;
  }

  public async Task<double> GetAverageAge()
  {
    var users = await _userRepository.GetUsers(new GetUsersInput());
    if (!users.Any())
    {
      return 0;
    }

    var averageAge = users.Average(u => u.Age);
    return averageAge;
  }

  public async Task<User?> GetUserById(int userId)
  {
    var user = await _userRepository.GetUserById(userId);
    return user;
  }

  public async Task<User> CreateUser(CreateUserInput input)
  {
    var user = await _userRepository.CreateUser(input);
    return user;
  }

  public async Task<DeleteUserOutput> DeleteUser(int userId)
  {
    var user = await _userRepository.GetUserById(userId);
    if (user == null)
    {
      return new DeleteUserOutput { Status = DeleteUserStatus.NotFound };
    }

    await _userRepository.DeleteUser(userId);
    return new DeleteUserOutput { Status = DeleteUserStatus.Success };
  }

  public async Task<User?> UpdateUser(UpdateUserInput input)
  {
    var updatedUser = await _userRepository.UpdateUser(input);
    if (updatedUser == null)
    {
      return null;
    }

    return updatedUser;
  }
}
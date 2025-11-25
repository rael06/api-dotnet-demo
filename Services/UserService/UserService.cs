using MyWebAPI.Models;

namespace MyWebAPI.Services.UserService;
public class UserService : IUserService
{
  private readonly IUserRepository _userRepository;
  public UserService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public ICollection<User> GetUsers(GetUsersInput input)
  {
    var users = _userRepository.GetUsers(input);
    return users.ToList();
  }

  public double GetAverageAge()
  {
    var users = _userRepository.GetUsers(new GetUsersInput()).ToList();
    if (users.Count == 0)
    {
      return 0;
    }

    var averageAge = users.Average(u => u.Age);
    return averageAge;
  }

  public User? GetUserById(int userId)
  {
    var user = _userRepository.GetUserById(userId);
    return user;
  }

  public User CreateUser(CreateUserInput input)
  {
    var user = _userRepository.CreateUser(input);
    return user;
  }

  public DeleteUserOutput DeleteUser(int userId)
  {
    var user = _userRepository.GetUserById(userId);
    if (user == null)
    {
      return new DeleteUserOutput { Status = DeleteUserStatus.NotFound };
    }
    _userRepository.DeleteUser(userId);
    return new DeleteUserOutput { Status = DeleteUserStatus.Success };
  }

  public UpdateUserOutput UpdateUser(UpdateUserInput input)
  {
    var updatedUser = _userRepository.UpdateUser(input);
    if (updatedUser == null)
    {
      return new UpdateUserOutput(status: UpdateUserStatus.NotFound, updatedUser: null);
    }

    return new UpdateUserOutput(status: UpdateUserStatus.Success, updatedUser: updatedUser);
  }
}
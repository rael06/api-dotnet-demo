using MyWebAPI.Models;
using MyWebAPI.Services;

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
}
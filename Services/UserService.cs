using MyWebAPI.Models;
using MyWebAPI.Services;

public class UserService : IUserService
{
  private readonly IUserRepository _userRepository;
  public UserService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }

  public ICollection<User> GetAllUsers()
  {
    var users = _userRepository.GetAllUsers();
    return users.ToList();
  }

  public double GetAverageAge()
  {
    var users = _userRepository.GetAllUsers().ToList();
    if (users.Count == 0)
    {
      return 0;
    }

    var averageAge = users.Average(u => u.Age);
    return averageAge;
  }
}
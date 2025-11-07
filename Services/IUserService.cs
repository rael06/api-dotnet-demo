using MyWebAPI.Models;

namespace MyWebAPI.Services;

public interface IUserService
{
  ICollection<User> GetAllUsers();
  double GetAverageAge();
}

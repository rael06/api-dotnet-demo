using MyWebAPI.Models;

namespace MyWebAPI.Services;

public interface IUserRepository
{
  IEnumerable<User> GetAllUsers();
}
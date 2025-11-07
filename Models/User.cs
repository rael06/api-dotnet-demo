namespace MyWebAPI.Models;

public class User
{
  public int Id { get; set; }
  public string Username { get; set; }
  public int Age { get; set; }
  public string PasswordHash { get; set; }

  public User(int id, string username, int age, string passwordHash)
  {
    Id = id;
    Username = username;
    Age = age;
    PasswordHash = passwordHash;
  }
}
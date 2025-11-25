namespace MyWebAPI.Models;

public class User
{
  public int Id { get; set; }
  public string Username { get; set; }
  public int Age { get; set; }
  public string PasswordHash { get; set; }

  public User(string username, int age, string passwordHash)
  {
    Username = username;
    Age = age;
    PasswordHash = passwordHash;
  }
}
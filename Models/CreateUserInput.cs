namespace MyWebAPI.Models;

public class CreateUserInput
{
  public string Username { get; set; }
  public int Age { get; set; }
  public string Password { get; set; }

  public CreateUserInput(string username, int age, string password)
  {
    Username = username;
    Age = age;
    Password = password;
  }
}
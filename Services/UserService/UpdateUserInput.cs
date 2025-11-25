namespace MyWebAPI.Services.UserService;

public class UpdateUserInput
{
  public int Id { get; set; }
  public string Username { get; set; }
  public int Age { get; set; }

  public UpdateUserInput(int id, string username, int age)
  {
    Id = id;
    Username = username;
    Age = age;
  }
}
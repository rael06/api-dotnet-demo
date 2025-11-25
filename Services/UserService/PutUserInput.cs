namespace MyWebAPI.Services.UserService;

public class PutUserInput
{
  public int Id { get; set; }
  public string Username { get; set; }
  public int Age { get; set; }

  public PutUserInput(int id, string username, int age)
  {
    Id = id;
    Username = username;
    Age = age;
  }
}
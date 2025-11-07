namespace MyWebAPI.DTO;

public class CreateUserRequestDto
{
  public string Username { get; set; }
  public int Age { get; set; }
  public string Password { get; set; }
}
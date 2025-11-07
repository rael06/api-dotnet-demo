namespace MyWebAPI.DTO;

public class GetUserResponseDto
{
  public int Id { get; set; }
  public string Username { get; set; }
  public int Age { get; set; }

  public GetUserResponseDto(int id, string username, int age)
  {
    Id = id;
    Username = username;
    Age = age;
  }
}
namespace MyWebAPI.Services.UserService;

public class GetUsersInput
{
  public int? MinAge { get; set; }
  public int? MaxAge { get; set; }
}
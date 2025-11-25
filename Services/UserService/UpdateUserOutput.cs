using MyWebAPI.Models;

namespace MyWebAPI.Services.UserService;

public enum PutUserStatus
{
  Success,
  NotFound
}

public class PutUserOutput
{
  public PutUserStatus Status { get; set; }
  public User? UpdatedUser { get; set; }

  public PutUserOutput(PutUserStatus status, User? updatedUser)
  {
    Status = status;
    UpdatedUser = updatedUser;
  }
}
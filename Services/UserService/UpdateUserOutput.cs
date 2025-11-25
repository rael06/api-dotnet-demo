using MyWebAPI.Models;

namespace MyWebAPI.Services.UserService;

public enum UpdateUserStatus
{
  Success,
  NotFound
}

public class UpdateUserOutput
{
  public UpdateUserStatus Status { get; set; }
  public User? UpdatedUser { get; set; }

  public UpdateUserOutput(UpdateUserStatus status, User? updatedUser)
  {
    Status = status;
    UpdatedUser = updatedUser;
  }
}
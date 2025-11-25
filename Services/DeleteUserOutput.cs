namespace MyWebAPI.Services;

public enum DeleteUserStatus
{
  Success,
  NotFound
}

public class DeleteUserOutput
{
  public DeleteUserStatus Status { get; set; }
}
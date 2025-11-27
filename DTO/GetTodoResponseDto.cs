namespace MyWebAPI.DTO;

public class GetTodoResponseDto
{
  public required int Id { get; set; }
  public required string Title { get; set; }
  public required string? Description { get; set; }
  public required DateTime CreationDate { get; set; }
  public required DateTime? UpdateDate { get; set; }
  public required DateTime DueDate { get; set; }
  public required bool IsDone { get; set; }
  public required int UserId { get; set; }
}
namespace MyWebAPI.Models;

public class Todo
{
  public int Id { get; set; }
  public required string Title { get; set; }
  public string? Description { get; set; }
  public DateTime CreationDate { get; set; }
  public DateTime? UpdateDate { get; set; }
  public DateTime DueDate { get; set; }
  public bool IsDone { get; set; }
}
namespace MyWebAPI.Services.TodoService;

public class CreateTodoInput
{
  public string Title { get; set; }
  public string? Description { get; set; }
  public DateTime DueDate { get; set; }

  public CreateTodoInput(string title, string? description, DateTime dueDate)
  {
    Title = title;
    Description = description;
    DueDate = dueDate;
  }
}
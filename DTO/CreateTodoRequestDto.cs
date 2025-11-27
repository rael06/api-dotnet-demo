using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.DTO;

public class CreateTodoRequestDto
{
  [Required]
  [MinLength(3, ErrorMessage = "Le titre doit contenir au moins 3 caractères.")]
  public required string Title { get; set; }
  public string? Description { get; set; }
  [Required]
  public required DateTime DueDate { get; set; }
  [Required]
  public required int UserId { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.DTO;

public class UpdateUserRequestDto
{
  [Required]
  public required int Id { get; set; }
  [Required]
  public required string Username { get; set; }
  [Required]
  [Range(0, 120, ErrorMessage = "Age doit être compris entre 0 et 120.")]
  public required int Age { get; set; }
}
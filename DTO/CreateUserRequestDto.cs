using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.DTO;

public class CreateUserRequestDto
{
  [Required]
  public string Username { get; set; }
  [Required]
  [Range(0, 120, ErrorMessage = "Age doit être compris entre 0 et 120.")]
  public int Age { get; set; }
  [Required]
  public string Password { get; set; }

  public CreateUserRequestDto(string username, int age, string password)
  {
    Username = username;
    Age = age;
    Password = password;
  }
}
using System.ComponentModel.DataAnnotations;

namespace UserApi.Data.Dtos;

public class CreateUserDto
{
    [Required]
    public string Username { get; set; }

    [Required]
    public DateTime DateBirth { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}

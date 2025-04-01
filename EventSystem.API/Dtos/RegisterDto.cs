namespace EventSystem.API.Dtos;

public class RegisterDto
{
    [Required]
    [EmailAddress]
    [MaxLength(50)]
    public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string Password { get; set; } = null!;
}

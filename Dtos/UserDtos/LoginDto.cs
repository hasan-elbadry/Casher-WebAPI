namespace Task1.Dtos.UserDtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Username feild is required")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password feild is required")]
        public string Password { get; set; } = string.Empty;
    }
}

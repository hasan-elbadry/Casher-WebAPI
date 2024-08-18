namespace Task1.Dtos.UserDtos
{
    public class RegisterDto
    {
        [Required(ErrorMessage ="Username feild is required")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email feild is required")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password feild is required")]
        public string Password { get; set; } = string.Empty;
    }
}

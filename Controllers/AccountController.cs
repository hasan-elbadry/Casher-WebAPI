namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<IdentityUser> userManager, ITokenService tokenService)
        {
            _UserManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var user = new IdentityUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
            };

           var result = await _UserManager.CreateAsync(user,registerDto.Password);
            if (result.Succeeded)
            {
                await _UserManager.AddToRoleAsync(user, "User");
            }
            else
                return BadRequest(result.Errors);

            return Ok("User have registered Seccuess");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _UserManager.FindByNameAsync(loginDto.Username);
            if (user == null)
                return Unauthorized("Invalid username or password");

            bool IsPasswordValid = await _UserManager.CheckPasswordAsync(user, loginDto.Password);
            if (!IsPasswordValid)
                return Unauthorized("Invalid username or password");

            return Ok(await _tokenService.GetToken(user));
        }
    }
}
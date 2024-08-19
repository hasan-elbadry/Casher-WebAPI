namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);

            var Result = await _accountService.Register(registerDto);
            if(Result == true)
                return Ok("User have registered Seccuessfully");

            return BadRequest(new { error = "user is already have an account, try to login"});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = await _accountService.Login(loginDto);

            if (token == null)
                return Unauthorized("Invalid username or password");

            return Ok(new { token = token });
        }
    }
}
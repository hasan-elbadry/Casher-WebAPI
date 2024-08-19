
using Microsoft.AspNetCore.Identity;

namespace Task1.Services
{
    public class AccountService : IAccountService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountService(ITokenService tokenService, UserManager<IdentityUser> userManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            if (user == null)
                return null!;

            bool IsPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!IsPasswordValid)
                return null!;

            return await _tokenService.GetToken(user);
        }

        public async Task<bool> Register(RegisterDto registerDto)
        {
            var newUser = new IdentityUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
            };
            var user = await _userManager.FindByEmailAsync(newUser.Email);
            if(user !=null) 
                return false;

            var result = await _userManager.CreateAsync(newUser, registerDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, "User");
            }
            else
                return false;

            return true;
        }
    }
}

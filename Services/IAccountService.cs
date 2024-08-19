namespace Task1.Services
{
    public interface IAccountService
    {
        public Task<string> Login(LoginDto loginDto);
        public Task<bool> Register(RegisterDto registerDto);
    }
}

namespace Task1.Services
{
    public interface ITokenService
    {
         Task<string> GetToken(IdentityUser user);
    }
}

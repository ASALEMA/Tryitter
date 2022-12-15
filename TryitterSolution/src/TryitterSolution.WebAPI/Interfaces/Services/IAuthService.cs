using TryitterSolution.WebAPI.Models;

namespace TryitterSolution.WebAPI.Interfaces.Services
{
    public interface IAuthService
    {
        string GenerateToken(string key, string issuer, string audience, User user);
    }
}

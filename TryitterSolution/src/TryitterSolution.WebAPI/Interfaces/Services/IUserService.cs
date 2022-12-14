using TryitterSolution.WebAPI.Models;

namespace TryitterSolution.WebAPI.Interfaces.Services
{
    public interface IUserService
    {
        Task AddAsync(User user, CancellationToken cancellationToken);
        Task ChangePasswordAsync(int userId, string password, CancellationToken cancellationToken);

        IEnumerable<User> GetAll(CancellationToken cancellationToken);

        Task DeleteAsync(int userId, CancellationToken cancellationToken);

    }
}

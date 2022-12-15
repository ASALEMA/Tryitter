using TryitterSolution.WebAPI.Models;

namespace TryitterSolution.WebAPI.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> ExistsAsync(User user, CancellationToken cancellationToken);

        Task AddAsync(User user, CancellationToken cancellationToken);

        void ChangePassword(User user, string password, CancellationToken cancellationToken);

        Task<User?> GetByIdAsync(int userId, CancellationToken cancellationToken);

        IEnumerable<User> GetAll(CancellationToken cancellationToken);

        void Delete(User user);

        Task<User?> GetByEmailAndPasswordAsync(string email, string password, CancellationToken cancellationToken);

    }
}

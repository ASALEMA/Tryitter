using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TryitterSolution.WebAPI.Interfaces.Repositories;
using TryitterSolution.WebAPI.Models;

namespace TryitterSolution.WebAPI.Repository
{
    [ExcludeFromCodeCoverage]
    public class UserRepository : IUserRepository
    {

        private readonly ITryitterContext _context;

        public UserRepository(ITryitterContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);

            _context.SaveChanges();

        }

        public void ChangePassword(User user, string password, CancellationToken cancellationToken)
        {
            user.Password = password;
            _context.SaveChanges();

        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public Task<bool> ExistsAsync(User user, CancellationToken cancellationToken)
        {
            return _context.Users.AnyAsync(c => c.Email == user.Email, cancellationToken);
        }

        public IEnumerable<User> GetAll(CancellationToken cancellationToken)
        {
            return _context.Users.ToList();
        }

        public Task<User?> GetByEmailAndPasswordAsync(string email, string password, CancellationToken cancellationToken)
        {
            return _context.Users.FirstOrDefaultAsync(c => c.Email == email && c.Password == password, cancellationToken);
        }

        public Task<User?> GetByIdAsync(int userId, CancellationToken cancellationToken)
        {
            return _context.Users.FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);
        }
    }
}

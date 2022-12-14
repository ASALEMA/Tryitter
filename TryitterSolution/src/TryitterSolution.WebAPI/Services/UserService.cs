using TryitterSolution.WebAPI.Excepitions;
using TryitterSolution.WebAPI.Extensions;
using TryitterSolution.WebAPI.Interfaces.Repositories;
using TryitterSolution.WebAPI.Interfaces.Services;
using TryitterSolution.WebAPI.Models;

namespace TryitterSolution.WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddAsync(User user, CancellationToken cancellationToken)
        {
            if (await _userRepository.ExistsAsync(user, cancellationToken))
            {
                throw new UserAlreadyExistsException($"O usuário {user.Email} já existe.");

            }
            await _userRepository.AddAsync(user, cancellationToken);
        }

        public async Task ChangePasswordAsync(int userId, string password, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
            
            if(user == null)
            {
                throw new UserNotExistsException($"Usuário de ID {userId} não existe!");
            }
            _userRepository.ChangePassword(user!, password, cancellationToken);
        }

        public async Task DeleteAsync(int userId, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(userId, cancellationToken);

            if (user == null)
            {
                throw new UserNotExistsException($"Usuário de ID {userId} não existe!");
            }
            _userRepository.Delete(user);
        }

        public IEnumerable<User> GetAll(CancellationToken cancellationToken)
        {
           return _userRepository.GetAll(cancellationToken);
        }
    }
}

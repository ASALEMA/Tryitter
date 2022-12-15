using AutoFixture;
using FluentAssertions;
using Moq;
using TryitterSolution.WebAPI.Exceptions;
using TryitterSolution.WebAPI.Interfaces.Repositories;
using TryitterSolution.WebAPI.Interfaces.Services;
using TryitterSolution.WebAPI.Models;
using TryitterSolution.WebAPI.Services;

namespace TryitterSolution.UnitTests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly IFixture _autoFixture;

        public UserServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _autoFixture = new Fixture();
        }

        public IUserService BuildUserService()
        {
            return new UserService(_mockUserRepository.Object);
        }

        [Fact]
        public async Task DeveSerPossivelAdicionarUmUsuario()
        {
            // Arrange
            var user = _autoFixture.Create<User>();
            var cancellationToken = new CancellationToken();


            var userService = BuildUserService();

            // Act
            await userService.AddAsync(user, cancellationToken);

            // Assert
            _mockUserRepository.Verify(c => c.AddAsync(user, cancellationToken), Times.Once);
        }

        [Fact]
        public async Task NaoDeveSerPossivelAdicionarUmUsuarioQuandoForInvalido()
        {
            // Arrange
            var user = _autoFixture.Create<User>();
            var cancellationToken = new CancellationToken();

            _mockUserRepository
              .Setup(c => c.ExistsAsync(user, cancellationToken))
              .ReturnsAsync(true);

            var userService = BuildUserService();

            // Act
            Func<Task> action = () => userService.AddAsync(user, cancellationToken);

            // Assert
            await action.Should()
                .ThrowAsync<UserAlreadyExistsException>()
                .WithMessage($"O usuário {user.Email} já existe.");

            _mockUserRepository.Verify(c => c.AddAsync(
                It.IsAny<User>(),
                It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task DeveSerPossivelAlterarSenhaDeUmUsuario()
        {
            // Arrange
            var user = _autoFixture.Create<User>();
            var password = _autoFixture.Create<string>();
            var cancellationToken = new CancellationToken();

            _mockUserRepository
                .Setup(c => c.GetByIdAsync(user.UserId, cancellationToken))
                .ReturnsAsync(user);

            var userService = BuildUserService();

            // Act
            await userService.ChangePasswordAsync(user.UserId, password, cancellationToken);

            // Assert
            _mockUserRepository.Verify(c => c.ChangePassword(user, password, cancellationToken), Times.Once);
        }

        [Fact]
        public async Task NaoDeveSerPossivelAlterarSenhaDeUmUsuarioQuandoForInvalido()
        {
            // Arrange
            var user = _autoFixture.Create<User>();
            var password = _autoFixture.Create<string>();
            var cancellationToken = new CancellationToken();

            var userService = BuildUserService();

            // Act
            Func<Task> action = () => userService.ChangePasswordAsync(user.UserId, password, cancellationToken);

            // Assert
            await action.Should()
                .ThrowAsync<UserNotExistsException>()
                .WithMessage($"Usuário de ID {user.UserId} não existe!");

            _mockUserRepository.Verify(c => c.ChangePassword(
                It.IsAny<User>(),
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task DeveSerPossivelDeletarUmUsuario()
        {
            // Arrange
            var user = _autoFixture.Create<User>();

            var cancellationToken = new CancellationToken();

            _mockUserRepository
                .Setup(c => c.GetByIdAsync(user.UserId, cancellationToken))
                .ReturnsAsync(user);

            var userService = BuildUserService();

            // Act
            await userService.DeleteAsync(user.UserId, cancellationToken);

            // Assert
            _mockUserRepository.Verify(c => c.Delete(user), Times.Once);
        }

        [Fact]
        public async Task NaoDeveSerPossivelDeletarUmUsuarioQuandoForInvalido()
        {
            // Arrange
            var user = _autoFixture.Create<User>();
            var cancellationToken = new CancellationToken();

            var userService = BuildUserService();

            // Act
            Func<Task> action = () => userService.DeleteAsync(user.UserId, cancellationToken);

            // Assert
            await action.Should()
                .ThrowAsync<UserNotExistsException>()
                .WithMessage($"Usuário de ID {user.UserId} não existe!");

            _mockUserRepository.Verify(c => c.Delete(
                It.IsAny<User>()), Times.Never);
        }
    }
}

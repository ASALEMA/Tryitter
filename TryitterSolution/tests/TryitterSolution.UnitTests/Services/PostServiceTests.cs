using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Hosting;
using Moq;
using TryitterSolution.WebAPI.Exceptions;
using TryitterSolution.WebAPI.Interfaces.Repositories;
using TryitterSolution.WebAPI.Interfaces.Services;
using TryitterSolution.WebAPI.Models;
using TryitterSolution.WebAPI.Services;

namespace TryitterSolution.UnitTests.Services
{
    public class PostServiceTests
    {
        private readonly Mock<IPostRepository> _mockPostRepository;
        private readonly IFixture _autoFixture;

        public PostServiceTests()
        {
            _mockPostRepository = new Mock<IPostRepository>();
            _autoFixture = new Fixture();
        }

        public IPostService BuildPostService()
        {
            return new PostService(_mockPostRepository.Object);
        }

        [Fact]
        public async Task DeveSerPossivelAdicionarUmPost()
        {
            // Arrange
            var post = _autoFixture.Create<Post>();
            var cancellationToken = new CancellationToken();

            var postService = BuildPostService();

            // Act
            await postService.AddAsync(post, cancellationToken);

            // Assert
            _mockPostRepository.Verify(c => c.AddAsync(post, cancellationToken), Times.Once);
        }

        [Fact]
        public async Task DeveSerPossivelAlterarUmPost()
        {
            // Arrange
            var post = _autoFixture.Create<Post>();
            var text = _autoFixture.Create<string>();
            var image = _autoFixture.Create<string>();

            var cancellationToken = new CancellationToken();

            _mockPostRepository
                .Setup(c => c.GetByIdAsync(post.PostId, cancellationToken))
                .ReturnsAsync(post);

            var postService = BuildPostService();

            // Act
            await postService.ChangePostAsync(post.PostId, text, image, cancellationToken);

            // Assert
            _mockPostRepository.Verify(c => c.ChangePost(post, text, image, cancellationToken), Times.Once);
        }

        [Fact]
        public async Task NaoDeveSerPossivelAlterarUmPostQuandoForInvalido()
        {
            // Arrange
            var post = _autoFixture.Create<Post>();
            var text = _autoFixture.Create<string>();
            var image = _autoFixture.Create<string>();

            var cancellationToken = new CancellationToken();

            var postService = BuildPostService();

            // Act
            Func<Task> action = () => postService.ChangePostAsync(post.PostId, text, image, cancellationToken);

            // Assert
            await action.Should()
                .ThrowAsync<PostNotExistsException>()
                .WithMessage($"Post de ID {post.PostId} não existe!");

            _mockPostRepository.Verify(c => c.ChangePost(
                It.IsAny<Post>(), 
                It.IsAny<string>(), 
                It.IsAny<string>(), 
                It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task DeveSerPossivelDeletarUmPost() 
        {

            // Arrange
            var post = _autoFixture.Create<Post>();
            
            var cancellationToken = new CancellationToken();

            _mockPostRepository
                .Setup(c => c.GetByIdAsync(post.PostId, cancellationToken))
                .ReturnsAsync(post);

            var postService = BuildPostService();

            // Act
            await postService.DeleteAsync(post.PostId, cancellationToken);

            // Assert
            _mockPostRepository.Verify(c => c.Delete(post), Times.Once);
        }

        [Fact]
        public async Task NaoDeveSerPossivelDeletarUmPostQuandoForInvalido() 
        {
            var post = _autoFixture.Create<Post>();
            
            var cancellationToken = new CancellationToken();

            var postService = BuildPostService();

            // Act
            Func<Task> action = () => postService.DeleteAsync(post.PostId, cancellationToken);

            // Assert
            await action.Should()
                .ThrowAsync<PostNotExistsException>()
                .WithMessage($"Usuário de ID {post.PostId} não existe!");

            _mockPostRepository.Verify(c => c.Delete(
                It.IsAny<Post>()), Times.Never);
        }

        [Fact]
        public void DeveSerPossivelObterTodosOsPosts()
        {
            // Arrange
            var posts = _autoFixture.CreateMany<Post>();
            var cancellationToken = new CancellationToken();

            _mockPostRepository
               .Setup(c => c.GetAll(cancellationToken))
               .Returns(posts);

            var postService = BuildPostService();

            // Act
            var result = postService.GetAll(cancellationToken);

            // Assert
            result.Should().BeEquivalentTo(posts);

            _mockPostRepository.Verify(c => c.GetAll(cancellationToken), Times.Once);

        }
    }
}

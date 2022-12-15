using TryitterSolution.WebAPI.Exceptions;
using TryitterSolution.WebAPI.Interfaces.Repositories;
using TryitterSolution.WebAPI.Interfaces.Services;
using TryitterSolution.WebAPI.Models;

namespace TryitterSolution.WebAPI.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task AddAsync(Post post, CancellationToken cancellationToken)
        {
            await _postRepository.AddAsync(post, cancellationToken);
        }

        public async Task ChangePostAsync(int postId, string text, string imagem, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(postId, cancellationToken);

            if (post == null)
            {
                throw new PostNotExistsException($"Post de ID {postId} não existe!");
            }
            _postRepository.ChangePost(post, text, imagem, cancellationToken);
        }
        public async Task DeleteAsync(int postId, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(postId, cancellationToken);

            if (post == null)
            {
                throw new PostNotExistsException($"Usuário de ID {postId} não existe!");
            }
            _postRepository.Delete(post);
        }

        public IEnumerable<Post> GetAll(CancellationToken cancellationToken)
        {
            return _postRepository.GetAll(cancellationToken);
        }
    }
}


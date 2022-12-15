using TryitterSolution.WebAPI.Models;

namespace TryitterSolution.WebAPI.Interfaces.Services
{
    public interface IPostService
    {
        Task AddAsync(Post post, CancellationToken CancellationToken);
        Task ChangePostAsync(int postId, string text, string imagem, CancellationToken cancellationToken);

        IEnumerable<Post> GetAll(CancellationToken cancellationToken);
        Task DeleteAsync(int postId, CancellationToken cancellationToken);
    }
}

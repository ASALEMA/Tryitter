using System.Threading.Tasks;
using TryitterSolution.WebAPI.Models;

namespace TryitterSolution.WebAPI.Interfaces.Repositories
{
    public interface IPostRepository
    {
        Task AddAsync(Post post, CancellationToken CancellationToken);
        void ChangePost(Post post, string text, string imagem, CancellationToken cancellationToken);
        Task<Post?> GetByIdAsync(int postId, CancellationToken cancellationToken);
        IEnumerable<Post> GetAll(CancellationToken cancellationToken);
        void Delete(Post post);
    }
}

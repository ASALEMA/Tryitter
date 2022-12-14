using Microsoft.EntityFrameworkCore;
using TryitterSolution.WebAPI.Interfaces.Repositories;
using TryitterSolution.WebAPI.Models;

namespace TryitterSolution.WebAPI.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly ITryitterContext _context;

        public PostRepository(ITryitterContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Post post, CancellationToken cancellationToken)
        {
            await _context.Posts.AddAsync(post, cancellationToken);

            _context.SaveChanges();

        }

        public void Delete(Post post)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        public Task<Post?> GetByIdAsync(int postId, CancellationToken cancellationToken)
        {
            return _context.Posts.FirstOrDefaultAsync(c => c.PostId == postId, cancellationToken);
        }

        public IEnumerable<Post> GetAll(CancellationToken cancellationToken)
        {
            return _context.Posts.ToList();
        }
        public void ChangePost(Post post, string text,string imagem, CancellationToken cancellationToken)
        {
            post.Text= text;
            post.Imagem = imagem;
            _context.SaveChanges();

        }




    }
}

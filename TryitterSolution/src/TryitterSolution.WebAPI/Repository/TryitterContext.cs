using Microsoft.EntityFrameworkCore;
using TryitterSolution.WebAPI.Models;

namespace TryitterSolution.WebAPI.Repository
{
    public class TryitterContext : DbContext, ITryitterContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public TryitterContext(DbContextOptions<TryitterContext> options) : base(options) { }

        public TryitterContext() { }
    }
}

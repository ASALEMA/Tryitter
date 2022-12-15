using Microsoft.EntityFrameworkCore;
using TryitterSolution.WebAPI.Models;

namespace TryitterSolution.WebAPI.Repository
{
    public interface ITryitterContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Post> Posts { get; set; }
        public int SaveChanges();

    }
}

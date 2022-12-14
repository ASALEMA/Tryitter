using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TryitterSolution.WebAPI.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; init; }

        [MaxLength(300)]
        public string? Text { get; set; }

        public string? Imagem { get; set; }

        [ForeignKey(("UserId"))]
        public int UserId { get; init; }
        public User User { get; init; }

    }
}


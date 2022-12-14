using System.ComponentModel.DataAnnotations;

namespace TryitterSolution.WebAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(200)]
        public required string Fullname { get; init; }

        [EmailAddress]
        public required string Email { get; init; }

        public string? Modulo { get; set; }

        public bool Status { get; set; } = true;

        [StringLength(maximumLength: 10, MinimumLength = 5)]
        public string? Password { get; set; }

        public IEnumerable<Post>? Posts { get; set; }
    }
}

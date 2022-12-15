using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TryitterSolution.WebAPI.ViewModels
{
    public class ChangePasswordViewModel
    {
        [SwaggerSchema("Id do usuário.")]
        [Required]
        [Range(1, int.MaxValue)]
        public required int UserId { get; set; }

        [SwaggerSchema("Senha de acesso.Deve possuir de 5 a 10 caracters.")]
        [StringLength(maximumLength: 10, MinimumLength = 5)]
        public required string NewPassword { get; set; }   
    }
}

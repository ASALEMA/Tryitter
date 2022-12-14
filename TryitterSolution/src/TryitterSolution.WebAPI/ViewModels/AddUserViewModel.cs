using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TryitterSolution.WebAPI.ViewModels
{
    public class AddUserViewModel
    {
        [SwaggerSchema("Nome completo do usuário.")]
        [Required(AllowEmptyStrings = false)]
        public required string FullName { get; init;}
        
        [SwaggerSchema("E-mail de contao do usuário. Obs.: utilizado no login.")]
        [EmailAddress]
        public required string Email { get; init; }

        [SwaggerSchema("Senha de acesso.Deve possuir de 5 a 10 caracters.")]
        [StringLength(maximumLength: 10, MinimumLength = 5)]
        public required string Password { get; init; }



    }
}

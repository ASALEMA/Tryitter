using Swashbuckle.AspNetCore.Annotations;

namespace TryitterSolution.WebAPI.ViewModels
{
    public class UserViewModel
    {
        [SwaggerSchema("ID do usuário cadastrado.")]
        public int UserId { get; set; }

        [SwaggerSchema("Nome completo do usuário.")]
        public required string FullName { get; set; }

        [SwaggerSchema("Email de acesso ao sistema.")]
        public required string Email { get; set; }
        [SwaggerSchema("Módulo de acesso ao sistema.")]
        public string? Modulo { get; set; }

        [SwaggerSchema("Indica se o usuário está ativo ou não no sistema.")]
        public bool Status { get; set; }
    }
}

using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace TryitterSolution.WebAPI.ViewModels
{
    public class ChangePostViewModel
    {
        [SwaggerSchema("ID do post cadastrado.")]
        public int PostId { get; set; }

        [SwaggerSchema("Informe a messagem do post.")]
        [MaxLength(300)]
        public string? Text { get; init; }


        [SwaggerSchema("Informe a url da imagem do post.")]
        public string? Imagem { get; init; }

        [SwaggerSchema("Id do usuário.")]
        public int UserId { get; init; }
    }
}

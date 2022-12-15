using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TryitterSolution.WebAPI.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace TryitterSolution.WebAPI.ViewModels
{
    public class AddPostViewModel
    {
        [SwaggerSchema("Informe a messagem do post.")]
        [MaxLength(300)]
        public string? Text { get; init; }


        [SwaggerSchema("Informe a url da imagem do post.")]
        public string? Imagem { get; init; }

        [SwaggerSchema("Id do usuário.")]
        public int UserId { get; init; }
      

    }
}

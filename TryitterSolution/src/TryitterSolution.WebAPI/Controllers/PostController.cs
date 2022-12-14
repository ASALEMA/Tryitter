using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TryitterSolution.WebAPI.Interfaces.Services;
using TryitterSolution.WebAPI.Models;
using TryitterSolution.WebAPI.Services;
using TryitterSolution.WebAPI.ViewModels;

namespace TryitterSolution.WebAPI.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController: ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo usuário")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromBody] AddPostViewModel viewModel, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                Text = viewModel.Text,
                Imagem = viewModel.Imagem,
                UserId = viewModel.UserId
            };
            await _postService.AddAsync(post, cancellationToken);
            return Ok();
        }

        [HttpPatch("change-post")]
        [SwaggerOperation(Summary = "Responsável pela atualização do post")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangePasswordAsync(ChangePostViewModel viewModel, CancellationToken cancellationToken)
        {

            await _postService.ChangePostAsync(viewModel.PostId, viewModel.Text, viewModel.Imagem, cancellationToken);
            return Ok();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Responsável por listar todos os posts do sistema")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll(CancellationToken cancellationToken)
        {

            var posts = _postService.GetAll(cancellationToken);

            if (User == null || !posts.Any())
            {
                return NoContent();
            }

            var viewModels = posts.Select(c => new PostViewModel
            {
                PostId = c.PostId,
                Text = c.Text,
                Imagem = c.Imagem,
                UserId = c.UserId
            });

            return Ok(viewModels);
        }


        [HttpDelete]
        [SwaggerOperation(Summary = "Responsável por deletar um post do sistema")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(int postId, CancellationToken cancellationToken)
        {

            await _postService.DeleteAsync(postId, cancellationToken);

            return Ok();
        }

    }
}

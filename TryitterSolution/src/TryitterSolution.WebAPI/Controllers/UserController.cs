using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TryitterSolution.WebAPI.Interfaces.Services;
using TryitterSolution.WebAPI.Models;
using TryitterSolution.WebAPI.ViewModels;

namespace TryitterSolution.WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria um novo usuário")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAsync([FromBody] AddUserViewModel viewModel, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Fullname = viewModel.FullName,
                Email = viewModel.Email,
                Password = viewModel.Password
            };
            await _userService.AddAsync(user, cancellationToken);
            return Ok();
        }

        [HttpPatch("change-password")]
        [SwaggerOperation(Summary = "Responsável pela atualização da senha")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordViewModel viewModel, CancellationToken cancellationToken)
        {

            await _userService.ChangePasswordAsync(viewModel.UserId, viewModel.NewPassword, cancellationToken);
            return Ok();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Responsável por listar todos os usuários do sistema")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll(CancellationToken cancellationToken)
        {

            var users = _userService.GetAll(cancellationToken);

            if (User == null || !users.Any())
            {
                return NoContent();
            }

            var viewModels = users.Select(c => new UserViewModel
            {
                UserId = c.UserId,
                FullName = c.Fullname,
                Email = c.Email,
                Status = c.Status,
                Modulo = c.Modulo
            });

            return Ok(viewModels);
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Responsável por deletar usuários do sistema")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(int userId, CancellationToken cancellationToken)
        {

            await _userService.DeleteAsync(userId, cancellationToken);

            return Ok();
        }
    }
}

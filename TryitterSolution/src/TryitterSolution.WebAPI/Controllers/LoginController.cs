using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TryitterSolution.WebAPI.Interfaces.Services;
using TryitterSolution.WebAPI.ViewModels;

namespace TryitterSolution.WebAPI.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public LoginController(IUserService userService, IAuthService authService, IConfiguration configuration)
        {
            _userService = userService;
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        [SwaggerOperation(Summary = "Realiza um login.")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel viewModel, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByEmailAndPasswordAsync(viewModel.Email, viewModel.Password, cancellationToken);

            var token = _authService.GenerateToken(
                _configuration!.GetValue<string>("JWT:Key"),
                _configuration!.GetValue<string>("JWT:Issuer"),
                _configuration!.GetValue<string>("JWT:Audience"),
                user);

            return Ok(token);
        }
    }
}

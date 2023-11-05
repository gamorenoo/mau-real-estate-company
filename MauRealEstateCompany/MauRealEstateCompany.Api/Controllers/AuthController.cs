using Application.Auth.Login;
using MauRealEstateCompany.Api.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MauRealEstateCompany.Api.Controllers
{
    public class AuthController : ApiControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly TokenService _tokenService;
        public AuthController(ILogger<AuthController> logger, TokenService tokenService)
        {
            _logger = logger;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Iniciar sesion
        /// </summary>
        /// <param name="user">Usuario con Coreo y clave validos</param>
        /// <remarks>
        ///    POST /login
        ///    {"email": "gustavoamoreno@outlook.com","password": "0123456789"}
        /// </remarks>
        /// <returns>Token de sesión</returns>
        /// <response code="200">Token de sesión</response>
        /// <response code="401">No autorizado</response>
        [HttpPost("login", Name = "login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Login([FromBody] UserDto user)
        {
            var userValid = await Mediator.Send(new LoginQuery { User = user });

            if (userValid)
            {
                var token = _tokenService.GetToken(user);
                return Ok(token);
            }
            else {
                return Unauthorized();
            }
        }
    }
}

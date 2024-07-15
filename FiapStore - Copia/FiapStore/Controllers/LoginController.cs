using FiapStore.DTO;
using FiapStore.Interface;
using FiapStore.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("auth")]
    public class LoginController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository;
        private readonly ITokenService _tokenService;

        public LoginController(IUsuarioRepository usuarioRepository,
            ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult AuthenticationAsync([FromBody] AuthDTO auth)
        {
            var user = _usuarioRepository.GetUserByNameAndPassword(auth.UserName, auth.Password);

            if (user == null)
            {
                return NotFound(new { msg = "Usuario ou senha inválidos" });
            }

            var token = _tokenService.GetToken(user);

            user.Senha = null;

            return Ok(new
            {
                User = user,
                Token = token
            });
        }

    }
}
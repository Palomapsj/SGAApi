using FiapStore.DTO;
using FiapStore.Entidade;
using FiapStore.Enums;
using FiapStore.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
        private readonly ILogger<UsuarioController> _logger;
        public UsuarioController(IUsuarioRepository usuarioRepository, ILogger<UsuarioController> logger)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        [Authorize]
        [HttpGet("Obter-usuario-porid/{id}")]
        [Authorize(Roles = $"{Permissions.Admin}")]
        public IActionResult ObtertPorUsuario(int id)
        {
            try
            {
                _logger.LogInformation("Buscando usuario");
                return Ok(_usuarioRepository.ObterPorId(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter usuário no banco de dados");
                return StatusCode(500, "Erro interno ao tentar obter usuário");
            }
        }

        [Authorize]
        [HttpGet("Obter-usuario")]
        [Authorize(Roles = $"{Permissions.Admin}")]
        public IActionResult ObtertUsuario()
        {
            try
            {
                _logger.LogInformation("Buscando usuarios");
                return Ok(_usuarioRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter usuário no banco de dados");
                return StatusCode(500, "Erro interno ao tentar obter usuário");
            }
        }

        [AllowAnonymous]
        [HttpPost("Cadastro-usuario")]
        public IActionResult CadastrarUsuario(AdicionarUsuarioDTO UsuarioDTO)
        {
            try
            {
                _logger.LogInformation("Tentando cadastrar usuario");
                _usuarioRepository.Cadastrar(new Usuario(UsuarioDTO));
                _logger.LogInformation("Usuario cadastrado com sucesso");

                return Ok("Usuario cadastrado com sucesso");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar cadastrar usuário no banco de dados");
                return StatusCode(500, "Erro interno ao tentar cadastrar usuário");
            }

        }

        [Authorize]
        [Authorize(Roles = $"{Permissions.Admin}")]
        [HttpPut("Alterar-usuario")]
        public IActionResult AlterarUsuario(AlterarUsarioDTO UsuarioDTO)
        {
            try
            {
                _logger.LogInformation("Tentando alterar o usuario no banco de dados");

                _usuarioRepository.Alterar(new Usuario(UsuarioDTO));

                _logger.LogInformation("Usuario alterado com sucesso");

                return Ok("Usuario alterado com sucesso");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar alterar usuário no banco de dados");
                return StatusCode(500, "Erro interno ao tentar alterar usuário");
            }
        }

        [Authorize]
        [Authorize(Roles = $"{Permissions.Admin}")]
        [HttpDelete("Deletar-usuario/{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);

                return Ok("Usuario deletado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar deletar usuário no banco de dados");
                return StatusCode(500, "Erro interno ao tentar alterar usuário");

            }
        }
    }
}

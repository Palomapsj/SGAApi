using FiapStore.DTO;
using FiapStore.Entidade;
using FiapStore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
   [ApiController]
   [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;
        private readonly ILogger <UsuarioController> _logger;
        public UsuarioController(IUsuarioRepository usuarioRepository, ILogger<UsuarioController> logger )
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        [HttpGet("Obter-usuario-porid/{id}")]
        public IActionResult ObtertPorUsuario(int id )
        {
            return Ok(_usuarioRepository.ObterPorId(id));
        }

        [HttpGet("Obter-usuario")]
        public IActionResult ObtertUsuario() {
            return Ok(_usuarioRepository.ObterTodos());



        }

        [HttpPost("Cadastro-usuario")]
        public IActionResult CadastrarUsuario(AdicionarUsuarioDTO UsuarioDTO) {

            _usuarioRepository.Cadastrar(new Usuario (UsuarioDTO));
            _logger.LogInformation("Executando");
            return Ok("Usuario cadastrado com sucesso");

        }

        [HttpPut("Alterar-usuario")]
        public IActionResult AlterarUsuario(AlterarUusarioDTO UsuarioDTO) {

            _usuarioRepository.Alterar(new Usuario(UsuarioDTO));

            return Ok("Usuario alterado com sucesso");
        }

        [HttpDelete("Deletar-usuario/{id}")]
        public IActionResult DeletarUsuario(int id) {            
            
            _usuarioRepository.Deletar(id);

            return Ok("Usuario deletado com sucesso");
        }
    }
}

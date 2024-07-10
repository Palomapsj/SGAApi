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

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {

            _usuarioRepository = usuarioRepository;

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



            return Ok("Usuario cadastrado com sucesso");
        }
        [HttpPut("Alterar-usuario")]
        public IActionResult AlterarUsuario(Usuario usuario) {

            _usuarioRepository.Alterar(usuario);

            return Ok("Usuario alterado com sucesso");
        }
        [HttpDelete("Deletar-usuario/{id}")]
        public IActionResult DeletarUsuario(int id) {            
            
            _usuarioRepository.Deletar(id);

            return Ok("Usuario deletado com sucesso");
        }
    }
}

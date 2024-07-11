using FiapStore.DTO;
using FiapStore.Entidade;
using FiapStore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
   [ApiController]
   [Route("Professores")]
    public class ProfessoresController : ControllerBase
    {
        private IProfessorRepository _professoresRepository;

        public ProfessoresController(IProfessorRepository professoresRepository)
        {

            _professoresRepository = professoresRepository;

        }

        [HttpGet("Obter-professor-porid/{id}")]
        public IActionResult ObtertPorUsuario(int id )
        {
            return Ok(_professoresRepository.ObterPorId(id));
        }

        [HttpGet("Obter-professor")]
        public IActionResult ObtertProfessor() {
            return Ok(_professoresRepository.ObterTodos());
        }

        [HttpPost("Cadastro-professor")]
        public IActionResult CadastrarProfessor(AdicionarProfessorDTO ProfessorDTO) {

            _professoresRepository.Cadastrar(new Professor (ProfessorDTO));
            return Ok("Professor cadastrado com sucesso");
        }

        [HttpPut("Alterar-professor")]
        public IActionResult AlterarProfessor(AlterarProfessorDTO ProfessorDTO) {

            _professoresRepository.Alterar(new Professor(ProfessorDTO));

            return Ok("Professor alterado com sucesso");
        }

        [HttpDelete("Deletar-usuario/{id}")]
        public IActionResult DeletarProfessor(int id) {

            _professoresRepository.Deletar(id);

            return Ok("Professor deletado com sucesso");
        }
    }
}

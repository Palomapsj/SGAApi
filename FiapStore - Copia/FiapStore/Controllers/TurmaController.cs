using FiapStore.DTO;
using FiapStore.Entidade;
using FiapStore.Interface;
using FiapStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("Turma")]
    public class TurmaController : ControllerBase
    {
        private ITurmaRepository _turmaRepository;

        public TurmaController(ITurmaRepository turmaRepository)
        {

            _turmaRepository = turmaRepository;

        }

        [HttpGet("Obter-turma-porid/{id}")]
        public IActionResult ObtertPorTurma(int id)
        {
            return Ok(_turmaRepository.ObterPorId(id));
        }

        [HttpGet("Obter-turma")]
        public IActionResult ObtertTurma()
        {
            return Ok(_turmaRepository.ObterTodos());
        }

        [HttpPost("Cadastro-turma")]
        public IActionResult CadastrarTurma(AdcionarTurmaDTO turmaDTO)
        {
            _turmaRepository.Cadastrar(new Turma(turmaDTO));
            return Ok("Turma cadastrado com sucesso");
        }

        [HttpPut("Alterar-turma")]
        public IActionResult AlterarTurma(AlterarTurmaDTO turmaDTO)
        {

            _turmaRepository.Alterar(new Turma(turmaDTO));

            return Ok("Turma alterada com sucesso");
        }

        [HttpDelete("Deletar-Turma/{id}")]
        public IActionResult DeletarTurma(int id)
        {
            _turmaRepository.Deletar(id);
            return Ok("Turma deletada com sucesso");
        }

    }
}

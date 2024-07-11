using FiapStore.DTO;
using FiapStore.Entidade;
using FiapStore.Interface;
using FiapStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("Curso")]
    public class CursoController : ControllerBase
    {
        private ICursoRepository _cursoRepository;

        public CursoController(ICursoRepository cursoRepository)
        {

            _cursoRepository = cursoRepository;

        }

        [HttpGet("Obter-curso-porid/{id}")]
        public IActionResult ObtertPorCurso(int id)
        {
            return Ok(_cursoRepository.ObterPorId(id));
        }

        [HttpGet("Obter-curso")]
        public IActionResult ObtertCurso()
        {
            return Ok(_cursoRepository.ObterTodos());
        }

        [HttpPost("Cadastro-curso")]
        public IActionResult CadastrarAluno(AdcionarCursoDTO cursoDTO)
        {
            _cursoRepository.Cadastrar(new Curso(cursoDTO));
            return Ok("Curso cadastrado com sucesso");
        }

        [HttpPut("Alterar-curso")]
        public IActionResult AlterarCurso(AlterarCursoDTO cursoDTO)
        {

            _cursoRepository.Alterar(new Curso(cursoDTO));

            return Ok("Curso alterado com sucesso");
        }

        [HttpDelete("Deletar-curso/{id}")]
        public IActionResult DeletarCurso(int id)
        {
            _cursoRepository.Deletar(id);
            return Ok("Curso deletado com sucesso");
        }

    }
}

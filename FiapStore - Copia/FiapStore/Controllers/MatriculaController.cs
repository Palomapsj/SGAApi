using FiapStore.DTO;
using FiapStore.Entidade;
using FiapStore.Interface;
using FiapStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("Matricula")]
    public class MatriculaController : ControllerBase
    {
        private IMatriculaRepository _matriculaRepository;

        public MatriculaController(IMatriculaRepository matriculaRepository)
        {

            _matriculaRepository = matriculaRepository;

        }

        [HttpGet("Obter-Matricula-porid/{id}")]
        public IActionResult ObtertPorTurma(int id)
        {
            return Ok(_matriculaRepository.ObterPorId(id));
        }

        [HttpGet("Obter-Matricula")]
        public IActionResult ObtertTurma()
        {
            return Ok(_matriculaRepository.ObterTodos());
        }

        [HttpPost("Cadastro-Matricula")]
        public IActionResult CadastrarTurma(AdicionarMatriculaDTO matriculaDTO)
        {
            _matriculaRepository.Cadastrar(new Matricula(matriculaDTO));
            return Ok("Matricula cadastrado com sucesso");
        }

        [HttpPut("Alterar-Matricula")]
        public IActionResult AlterarMatricula(AlterarMatriculaDTO matriculaDTO)
        {

            _matriculaRepository.Alterar(new Matricula(matriculaDTO));

            return Ok("Matricula alterada com sucesso");
        }

        [HttpDelete("Deletar-Matricula/{id}")]
        public IActionResult DeletarMatricula(int id)
        {
            _matriculaRepository.Deletar(id);
            return Ok("Matricula deletada com sucesso");
        }

    }
}

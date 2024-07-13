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
        private readonly ILogger<UsuarioController> _logger;

        public MatriculaController(IMatriculaRepository matriculaRepository, ILogger<UsuarioController> logger)
        {
                _matriculaRepository = matriculaRepository;
               _logger = logger;
        }

        [HttpGet("Obter-Matricula-porid/{id}")]
        public IActionResult ObtertPorTurma(int id)
        {
           try
           {
         
           _logger.LogInformation("Buscando matricula");
           return Ok(_matriculaRepository.ObterPorId(id));
           }
           catch (Exception ex)
           {
           _logger.LogError(ex, "Erro ao tentar obter matricula no banco de dados");
           return StatusCode(500, "Erro interno ao tentar obter matricula");
           }
        }

        [HttpGet("Obter-Matricula")]
        public IActionResult ObtertTurma()
        {
            try
            {
                _logger.LogInformation("Buscando Matricula");
                return Ok(_matriculaRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter matricula no banco de dados");
                return StatusCode(500, "Erro interno ao tentar obter matricula");
            }
                }

        [HttpPost("Cadastro-Matricula")]
        public IActionResult CadastrarTurma(AdicionarMatriculaDTO matriculaDTO)
        {
            try
            {

                _logger.LogInformation("cadastrando matricula");
                _matriculaRepository.Cadastrar(new Matricula(matriculaDTO));
                return Ok("Matricula cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar cadastrar matricula no banco de dados");
                return StatusCode(500, "Erro interno ao tentar cadastrar matricula");
            }
                    }

        [HttpPut("Alterar-Matricula")]
        public IActionResult AlterarMatricula(AlterarMatriculaDTO matriculaDTO)
        {
            try
            {

                _logger.LogInformation("alterando matricula");
                _matriculaRepository.Alterar(new Matricula(matriculaDTO));

                return Ok("Matricula alterada com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar alterar matricula no banco de dados");
                return StatusCode(500, "Erro interno ao tentar alterar matricula");
            }
                        }

        [HttpDelete("Deletar-Matricula/{id}")]
        public IActionResult DeletarMatricula(int id)
        {
            try
            {

                _logger.LogInformation("deletando matricula");
                _matriculaRepository.Deletar(id);
                return Ok("Matricula deletada com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar deletar matricula no banco de dados");
                return StatusCode(500, "Erro interno ao tentar deletar matricula");
            }
                            }

    }
}

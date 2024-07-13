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
        private readonly ILogger<UsuarioController> _logger;


        public CursoController(ICursoRepository cursoRepository, ILogger<UsuarioController> logger)
        {

            _cursoRepository = cursoRepository;
            _logger = logger;

        }

        [HttpGet("Obter-curso-porid/{id}")]
        public IActionResult ObtertPorCurso(int id)
        {
            try
            {

                _logger.LogInformation("Buscando Curso");

                return Ok(_cursoRepository.ObterPorId(id));
            }catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter curso no banco de dados");
                return StatusCode(500, "Erro interno ao tentar obter curso");


            }

        }

        [HttpGet("Obter-curso")]
        public IActionResult ObtertCurso()
        {
            try
            {
                return Ok(_cursoRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter curso no banco de dados");
                return StatusCode(500, "Erro interno ao tentar obter curso");


            }
        }

        [HttpPost("Cadastro-curso")]
        public IActionResult CadastrarAluno(AdcionarCursoDTO cursoDTO)
        {
            try
            {
                _cursoRepository.Cadastrar(new Curso(cursoDTO));
                return Ok("Curso cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar cadastrar curso no banco de dados");
                return StatusCode(500, "Erro interno ao tentar cadastrar curso");


            }
        }

        [HttpPut("Alterar-curso")]
        public IActionResult AlterarCurso(AlterarCursoDTO cursoDTO)
        {
            try
            {

                _cursoRepository.Alterar(new Curso(cursoDTO));

            return Ok("Curso alterado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar alterar curso no banco de dados");
                return StatusCode(500, "Erro interno ao tentar alterar curso");


            }
        }

        [HttpDelete("Deletar-curso/{id}")]
        public IActionResult DeletarCurso(int id)
        {
            try
            {
                _cursoRepository.Deletar(id);
                return Ok("Curso deletado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar deletar curso no banco de dados");
                return StatusCode(500, "Erro interno ao tentar deletar curso");


            }
        }

    }
}

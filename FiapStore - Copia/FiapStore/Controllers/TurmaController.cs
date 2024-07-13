using FiapStore.DTO;
using FiapStore.Entidade;
using FiapStore.Interface;
using FiapStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("Turma")]
    public class TurmaController : ControllerBase
    {
        private ITurmaRepository _turmaRepository;
        private readonly ILogger<UsuarioController> _logger;

        public TurmaController(ITurmaRepository turmaRepository, ILogger<UsuarioController> logger)
        {

            _turmaRepository = turmaRepository;
            _logger = logger;

        }

        [HttpGet("Obter-turma-porid/{id}")]
        public IActionResult ObtertPorTurma(int id)
        {
            try {
               
                _logger.LogInformation("Buscando Turma");

                return Ok(_turmaRepository.ObterPorId(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter turma no banco de dados");
                return StatusCode(500, "Erro interno ao tentar obter turma");
            }
        }

        [HttpGet("Obter-turma")]
        public IActionResult ObtertTurma()
        {
            try
            {
                _logger.LogInformation("Buscando Turmas");

                return Ok(_turmaRepository.ObterTodos());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter turmas no banco de dados");
                return StatusCode(500, "Erro interno ao tentar obter turmas");

            }
        }

        [HttpPost("Cadastro-turma")]
        public IActionResult CadastrarTurma(AdcionarTurmaDTO turmaDTO)
        {
            try
            {
                _logger.LogInformation("cadastro de turma");

                _turmaRepository.Cadastrar(new Turma(turmaDTO));
                return Ok("Turma cadastrada com sucesso");

        }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar cadastrar turma no banco de dados");
                return StatusCode(500, "Erro interno ao tentar cadastrar turma");

            }
        }

        [HttpPut("Alterar-turma")]
        public IActionResult AlterarTurma(AlterarTurmaDTO turmaDTO)
        {
            try
            {
                _logger.LogInformation("Alterar turma");

                _turmaRepository.Alterar(new Turma(turmaDTO));

                 return Ok("Turma alterada com sucesso");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar alterar turma no banco de dados");
                return StatusCode(500, "Erro interno ao tentar alterar turma");

            }
        }

        [HttpDelete("Deletar-Turma/{id}")]
        public IActionResult DeletarTurma(int id)
        {
            try
            {
                _logger.LogInformation("Deletando turma");

                _turmaRepository.Deletar(id);
            return Ok("Turma deletada com sucesso");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar deletar turma no banco de dados");
                return StatusCode(500, "Erro interno ao tentar deletar turma");

            }
        }

    }
}

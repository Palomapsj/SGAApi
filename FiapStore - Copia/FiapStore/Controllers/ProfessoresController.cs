using FiapStore.DTO;
using FiapStore.Entidade;
using FiapStore.Enums;
using FiapStore.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("Professores")]
    public class ProfessoresController : ControllerBase
    {
        private IProfessorRepository _professoresRepository;
        private readonly ILogger<UsuarioController> _logger;

        public ProfessoresController(IProfessorRepository professoresRepository, ILogger<UsuarioController> logger)
        {
            _professoresRepository = professoresRepository;
            _logger = logger;
        }

        [Authorize]
        [Authorize(Roles = $"{Permissions.Admin}")]
        [HttpGet("Obter-professor-porid/{id}")]
        public IActionResult ObtertPorUsuario(int id)
        {
            try
            {
                _logger.LogInformation("Buscando professore");
                return Ok(_professoresRepository.ObterPorId(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter professore no banco de dados");
                return StatusCode(500, "Erro interno ao tentar obter professor");
            }
        }

        [Authorize]
        [Authorize(Roles = $"{Permissions.Admin}")]
        [HttpGet("Obter-professores")]
        public IActionResult ObtertProfessor()
        {

            try
            {
                _logger.LogInformation("Buscando professores");

                return Ok(_professoresRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter professores no banco de dados");
                return StatusCode(500, "Erro interno ao tentar obter professores");
            }
        }

        [Authorize]
        [Authorize(Roles = $"{Permissions.Admin}")]
        [HttpPost("Cadastro-professor")]
        public IActionResult CadastrarProfessor(AdicionarProfessorDTO ProfessorDTO)
        {
            try
            {
                _logger.LogInformation("Cadastrando professor");
                _professoresRepository.Cadastrar(new Professor(ProfessorDTO));
                return Ok("Professor cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar cadastrar professor no banco de dados");
                return StatusCode(500, "Erro interno ao tentar cadastrar professor");
            }
        }

        [Authorize]
        [Authorize(Roles = $"{Permissions.Admin}")]
        [HttpPut("Alterar-professor")]
        public IActionResult AlterarProfessor(AlterarProfessorDTO ProfessorDTO)
        {
            try
            {
                _logger.LogInformation("Alterando professor");
                _professoresRepository.Alterar(new Professor(ProfessorDTO));

                return Ok("Professor alterado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar alterar professor no banco de dados");
                return StatusCode(500, "Erro interno ao tentar alterar professor");
            }
        }

        [HttpDelete("Deletar-professor/{id}")]
        [Authorize(Roles = $"{Permissions.Admin}")]
        public IActionResult DeletarProfessor(int id)
        {
            try
            {
                _logger.LogInformation("Deletando professor");
                _professoresRepository.Deletar(id);

                return Ok("Professor deletado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar deletar professor no banco de dados");
                return StatusCode(500, "Erro interno ao tentar deletar professor");
            }
        }
    }
}

using FiapStore.DTO;
using FiapStore.Entidade;
using FiapStore.Interface;
using FiapStore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("Aluno")]
    public class AlunosController : ControllerBase
    {
        private IAlunoRepository _alunosRepository;
        private readonly ILogger<AlunosController> _logger;

        public AlunosController(IAlunoRepository alunosRepository, ILogger<AlunosController> logger)
        {
            _alunosRepository = alunosRepository;
            _logger = logger;
        }

        [Authorize]
        [HttpGet("Obter-aluno-porid/{id}")]
        public IActionResult ObtertPorAluno(int id)
        {
            try
            {

                _logger.LogInformation("Buscando Auno");

                return Ok(_alunosRepository.ObterPorId(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter aluno no banco de dados");
                return StatusCode(500, "Erro interno ao tentar obter aluno");
            }
        }

        [Authorize]
        [HttpGet("Obter-aluno")]
        public IActionResult ObtertAluno()
        {
            try
            {
                return Ok(_alunosRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar obter aluno no banco de dados");
                return StatusCode(500, "Erro interno ao tentar obter aluno");
            }
        }

        [Authorize]
        [HttpPost("Cadastro-aluno")]
        public IActionResult CadastrarAluno(AdicionarAlunosDTO UsuarioDTO)
        {
            try
            {
                _alunosRepository.Cadastrar(new Aluno(UsuarioDTO));
                return Ok("Aluno cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar cadastrar aluno no banco de dados");
                return StatusCode(500, "Erro interno ao tentar cadastrar aluno");
            }
        }

        [Authorize]
        [HttpPut("Alterar-aluno")]
        public IActionResult AlterarAluno(AlterarAlunosDTO alunosDTO)
        {

            try
            {
                _alunosRepository.Alterar(new Aluno(alunosDTO));
                return Ok("Aluno alterado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar alterar aluno no banco de dados");
                return StatusCode(500, "Erro interno ao tentar alterar aluno");
            }
        }

        [Authorize]
        [HttpDelete("Deletar-aluno/{id}")]
        public IActionResult DeletarAluno(int id)
        {
            try
            {
            _alunosRepository.Deletar(id);
                return Ok("Curso deletado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao tentar deletar aluno no banco de dados");
                return StatusCode(500, "Erro interno ao tentar deletar aluno");
            }
        }

    }
}

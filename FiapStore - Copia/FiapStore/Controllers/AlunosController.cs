using FiapStore.DTO;
using FiapStore.Entidade;
using FiapStore.Interface;
using FiapStore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("Aluno")]
    public class AlunosController : ControllerBase
    {
        private IAlunoRepository _alunosRepository;

        public AlunosController(IAlunoRepository alunosRepository)
        {

            _alunosRepository = alunosRepository;

        }

        [HttpGet("Obter-aluno-porid/{id}")]
        public IActionResult ObtertPorAluno(int id)
        {
            return Ok(_alunosRepository.ObterPorId(id));
        }

        [HttpGet("Obter-aluno")]
        public IActionResult ObtertAluno()
        {
            return Ok(_alunosRepository.ObterTodos());
        }

        [HttpPost("Cadastro-aluno")]
        public IActionResult CadastrarAluno(AdicionarAlunosDTO UsuarioDTO)
        {
            _alunosRepository.Cadastrar(new Aluno(UsuarioDTO));
            return Ok("Aluno cadastrado com sucesso");
        }

        [HttpPut("Alterar-aluno")]
        public IActionResult AlterarAluno(AlterarAlunosDTO alunosDTO)
        {

            _alunosRepository.Alterar(new Aluno(alunosDTO));

            return Ok("Aluno alterado com sucesso");
        }

        [HttpDelete("Deletar-aluno/{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            _alunosRepository.Deletar(id);
            return Ok("Aluno deletado com sucesso");
        }

    }
}

using FiapStore.DTO;
using System.Xml.Linq;

namespace FiapStore.Entidade
{
    public class Aluno : Base
    {
        public int AlunoId { get; set; }    
        public string? Nome { get; set; }

        public DateTime? DataNascimento { get; set; }

        public string? Email { get; set; }

        public string? Telefone { get; set; }

        public string? Endereco { get; set; }

        public int UsuarioId { get; set; }

        public Aluno() { }

        public Aluno(AdicionarAlunosDTO adicionarAlunos)
        {

            Nome = adicionarAlunos.nome;
            DataNascimento = adicionarAlunos.dataNascimento;
            Email = adicionarAlunos.email;
            Telefone = adicionarAlunos.telefone;
            Endereco = adicionarAlunos.endereco;
            UsuarioId = adicionarAlunos.usuarioId;

        }

        public Aluno(AlterarAlunosDTO alterarAluno)
        {
            Email = alterarAluno.email;
            Endereco = alterarAluno.endereco;
            Telefone = alterarAluno.telefone;
            AlunoId = alterarAluno.alunoId;


        }
    }
}

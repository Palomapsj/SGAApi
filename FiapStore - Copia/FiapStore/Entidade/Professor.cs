using FiapStore.DTO;
using System.Xml.Linq;

namespace FiapStore.Entidade
{
    public class Professor : Base
    {
        public int ProfessorId { get; set; }    
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Telefone { get; set; }

        public string? Endereco { get; set; }

        public int UsuarioId { get; set; }

        public DateTime? DataContratacao { get; set; }

        public Professor() { }

        public Professor(AdicionarProfessorDTO adicionarProfessor)
        {

            Nome = adicionarProfessor.nome;
            DataContratacao = adicionarProfessor.dataContratacao;
            Email = adicionarProfessor.email;
            Telefone = adicionarProfessor.telefone;
            Endereco = adicionarProfessor.endereco;
            UsuarioId = adicionarProfessor.usuarioId;

        }

        public Professor(AlterarProfessorDTO alterarProfessor)
        {
            Email = alterarProfessor.email;
            Endereco = alterarProfessor.endereco;
            Telefone = alterarProfessor.telefone;

        }
    }
}

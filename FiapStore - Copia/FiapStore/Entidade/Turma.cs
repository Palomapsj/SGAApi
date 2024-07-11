using FiapStore.DTO;
using System.Xml.Linq;

namespace FiapStore.Entidade
{
    public class Turma : Base
    {
        public int TurmaId { get; set; }

        public int CursoId { get; set; }

        public string? Nome { get; set; }

        public TimeSpan? Horario { get; set; }

        public string? Local { get; set; }



        public Turma() { }

        public Turma(AdcionarTurmaDTO adcionarTurma)
        {

            CursoId = adcionarTurma.CursoId;
            Nome = adcionarTurma.nome;
            Horario = adcionarTurma.horario;
            Local = adcionarTurma.local;
         

        }

        public Turma(AlterarTurmaDTO alterarTurma)
        {
            Nome = alterarTurma.nome;
            Horario = alterarTurma.horario;
            Local = alterarTurma.local;


        }
    }
}

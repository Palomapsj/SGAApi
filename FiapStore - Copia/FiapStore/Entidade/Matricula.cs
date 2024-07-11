using FiapStore.DTO;
using System.Xml.Linq;

namespace FiapStore.Entidade
{
    public class Matricula : Base
    {
        public int MatriculaId { get; set; }    
        public int AlunoId { get; set; }

        public int TurmaId { get; set; }

        public DateTime? DataMatricula { get; set; }


        public Matricula() { }

        public Matricula(AdicionarMatriculaDTO adcionarMatricula)
        {

            AlunoId = adcionarMatricula.alunoId;
            TurmaId = adcionarMatricula.turmaId;
            DataMatricula = adcionarMatricula.dataMatricula;
         

        }

        public Matricula(AlterarMatriculaDTO alterarMatricula)
        {
            AlunoId = alterarMatricula.alunoId;
            TurmaId = alterarMatricula.turmaId;
            DataMatricula = alterarMatricula.dataMatricula;
          

        }
    }
}

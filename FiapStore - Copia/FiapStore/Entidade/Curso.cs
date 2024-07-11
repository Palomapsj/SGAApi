using FiapStore.DTO;
using System.Xml.Linq;

namespace FiapStore.Entidade
{
    public class Curso : Base
    {
        public int CursoId { get; set; }    
        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataFim { get; set; }


        public Curso() { }

        public Curso(AdcionarCursoDTO adcionarCurso)
        {

            Nome = adcionarCurso.nome;
            Descricao = adcionarCurso.descricao;
            DataInicio = adcionarCurso.dataInicio;
            DataFim = adcionarCurso.dataFim;
         

        }

        public Curso(AlterarCursoDTO alterarCurso)
        {
            Nome = alterarCurso.nome;
            Descricao = alterarCurso.descricao;
            DataInicio = alterarCurso.dataInicio;
            DataFim = alterarCurso.dataFim;
            CursoId = alterarCurso.cursoId;

        }
    }
}

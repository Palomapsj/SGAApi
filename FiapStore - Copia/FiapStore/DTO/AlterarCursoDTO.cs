namespace FiapStore.DTO
{
    public class AlterarCursoDTO
    {
        public int cursoId { get; set; }
        public string? nome { get; set; }

        public string? descricao { get; set; }

        public DateTime? dataInicio { get; set; }

        public DateTime? dataFim { get; set; }
    }
}

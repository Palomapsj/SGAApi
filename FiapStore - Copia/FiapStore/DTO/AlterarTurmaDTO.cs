namespace FiapStore.DTO
{
    public class AlterarTurmaDTO
    {
        public int cursoId { get; set; }

        public string? nome { get; set; }

        public TimeSpan? horario { get; set; }

        public string? local { get; set; }
    }
}

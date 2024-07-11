namespace FiapStore.DTO
{
    public class AdcionarTurmaDTO
    {
        public int CursoId { get; set; }

        public string? nome { get; set; }

        public TimeSpan? horario { get; set; }

        public string? local { get; set; }
    }
}

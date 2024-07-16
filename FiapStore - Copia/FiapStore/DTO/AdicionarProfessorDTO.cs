namespace FiapStore.DTO
{
    public class AdicionarProfessorDTO
    {
        public string? nome { get; set; }

        public string? email { get; set; }

        public string? telefone { get; set; }

        public string? endereco { get; set; }

        public int usuarioId { get; set; }

        public DateTime? dataContratacao { get; set; }

        public DateTime? dataNascimento { get; set; }
    }
}

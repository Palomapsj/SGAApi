namespace FiapStore.DTO
{
    public class AdicionarAlunosDTO
    {
        public string nome { get; set; }

        public DateTime? dataNascimento { get; set; }

        public string email { get; set; }

        public string telefone { get; set; }

        public string endereco { get; set; }    
        
        public int usuarioId { get; set; }

    }
}

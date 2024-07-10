using FiapStore.DTO;

namespace FiapStore.Entidade
{
    public class Usuario : Base
    {
        public string? Name { get; set; }

        public Usuario() { }

        public Usuario( AdicionarUsuarioDTO adicionarUsuarioDTO) {

            Name = adicionarUsuarioDTO.nome;



        }
    }
}

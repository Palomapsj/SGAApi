using FiapStore.DTO;
using FiapStore.Interface;

namespace FiapStore.Entidade
{
    public class Usuario : Base
    {
        public int UsuarioId { get; set; }
        public string? Name { get; set; }

        public string? UserName { get; set; }

        public string? Senha { get; set; }

        public int TipoUsuario { get; set; }

        public int Idreferente { get; set; }

        public Usuario() { }

        public Usuario( AdicionarUsuarioDTO adicionarUsuarioDTO) {

            Name = adicionarUsuarioDTO.name;
            UserName = adicionarUsuarioDTO.userName;
            Senha = adicionarUsuarioDTO.senha;
            TipoUsuario = adicionarUsuarioDTO.tipoUsuario;
            Idreferente = adicionarUsuarioDTO.idreferente;

        }

        public Usuario(AlterarUusarioDTO alterarUusarioDTO) {
            UsuarioId = alterarUusarioDTO.UsuarioId;
            UserName = alterarUusarioDTO.userName;

        }
    }
}

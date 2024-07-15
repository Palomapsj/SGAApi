using FiapStore.Enums;

namespace FiapStore.DTO
{
    public class AdicionarUsuarioDTO
    {
        public string? name { get; set; }

        public string? userName { get; set; }

        public string? senha { get; set; }

        public PermissionType tipoUsuario { get; set; }

        public int idreferente { get; set; }
    }
}

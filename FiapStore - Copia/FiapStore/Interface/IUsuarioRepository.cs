using FiapStore.Entidade;

namespace FiapStore.Interface
{
    public interface IUsuarioRepository : IRepostiry<Usuario>
    {
        Usuario GetUserByNameAndPassword(string userName, string password);
    }
}

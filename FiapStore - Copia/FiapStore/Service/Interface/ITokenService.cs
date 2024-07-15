using FiapStore.Entidade;

namespace FiapStore.Service.Interface
{
    public interface ITokenService
    {
        string GetToken(Usuario usuario);
    }
}

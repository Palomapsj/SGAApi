using FiapStore.Entidade;

namespace FiapStore.Interface
{
    public interface IRepostiry<T> where T: Base
    {
        IList<T> ObterTodos();

        T ObterPorId(int id);

        void Cadastrar(T entidade);

        void Alterar(T entidade);

        void Deletar(int id);


    }
}

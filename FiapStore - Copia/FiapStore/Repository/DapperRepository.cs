using FiapStore.Entidade;
using FiapStore.Interface;

namespace FiapStore.Repository
{
    public abstract class DapperRepository<T> : IRepostiry<T> where T : Base
    {

        private readonly string _connectionString;
        protected string ConnectionString => _connectionString;

        public DapperRepository(IConfiguration configuration) {

            _connectionString = configuration.GetValue<string>("ConnectionStrings:ConnectionString");
        }

        public abstract void Alterar(T entidade);

        public abstract void Cadastrar(T entidade);

        public abstract void Deletar(int id);

        public abstract T ObterPorId(int id);

        public abstract IList<T> ObterTodos();
        
    }
}

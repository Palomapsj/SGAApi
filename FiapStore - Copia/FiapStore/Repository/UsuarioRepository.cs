using Dapper;
using FiapStore.Entidade;
using FiapStore.Interface;
using System.Data.Common;
using System.Data.SqlClient;

namespace FiapStore.Repository
{
    public class UsuarioRepository : DapperRepository<Usuario>, IUsuarioRepository
    {
        private IList<Usuario> _usuario = new List<Usuario>();

        public UsuarioRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public override void Alterar(Usuario entidade)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
                var query = "UPDATE USUARIO SET NAME = @NAME WHERE ID = @Id ";
                dbConnection.Query(query, entidade);

        }

        public override void Cadastrar(Usuario entidade)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "INSERT INTO USUARIOO (NAME) VALUES (@NAME)  ";
            dbConnection.Execute(query, entidade);
        }

        public override void Deletar(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "DELETE FROM USUARIO where Id = @Id";
            dbConnection.Execute(query, new {Id =id });
        }

        public override Usuario ObterPorId(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM USUARIO where Id = @Id";
            return dbConnection.Query<Usuario>(query).FirstOrDefault();
        }

        public override IList<Usuario> ObterTodos()
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM USUARIO ";
            return dbConnection.Query<Usuario>(query).ToList();
        }
    }
}

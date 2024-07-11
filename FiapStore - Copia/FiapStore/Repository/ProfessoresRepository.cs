using Dapper;
using FiapStore.Entidade;
using FiapStore.Interface;
using System.Data.Common;
using System.Data.SqlClient;

namespace FiapStore.Repository
{
    public class ProfessoresRepository : DapperRepository<Professor>, IProfessorRepository
    {
        public ProfessoresRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public override void Alterar(Professor entidade)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "UPDATE Professoress SET ENDERECO = @Endereco, TELEFONE = @Telefone, EMAIL = @Email WHERE professor_id = @ProfessorId ";
            dbConnection.Query(query, entidade);
        }

        public override void Cadastrar(Professor entidade)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "INSERT INTO Professoress  VALUES (@Nome, @Email, @Telefone, @Endereco, @UsuarioId, @DataContratacao)";
            dbConnection.Execute(query, entidade);
        }

        public override void Deletar(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "DELETE FROM Professoress where professor_id = @Id";
            dbConnection.Execute(query, new { Id = id });
        }

        public override Professor ObterPorId(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Professoress where professor_id = @Id";
            return dbConnection.QueryFirstOrDefault<Professor>(query, new { Id = id });

        }

        public override IList<Professor> ObterTodos()
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Professoress ";
            return dbConnection.Query<Professor>(query).ToList();
        }
    }
}

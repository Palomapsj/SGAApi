using Dapper;
using FiapStore.Entidade;
using FiapStore.Interface;
using System.Data.Common;
using System.Data.SqlClient;

namespace FiapStore.Repository
{
    public class TurmaRepository : DapperRepository<Turma>, ITurmaRepository
    {
        public TurmaRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public override void Alterar(Turma entidade)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "UPDATE Turmas SET NOME = @Nome, Horario = @Horario, Local = @Local WHERE turma_id = @TurmaId ";
            dbConnection.Query(query, entidade);
        }

        public override void Cadastrar(Turma entidade)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "INSERT INTO Turmas  VALUES (@CursoId, @Nome, @Horario, @Local)";
            dbConnection.Execute(query, entidade);
        }

        public override void Deletar(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "DELETE FROM Turmas where turma_id = @Id";
            dbConnection.Execute(query, new { Id = id });
        }

        public override Turma ObterPorId(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Turmas where turma_id = @Id";
            return dbConnection.QueryFirstOrDefault<Turma>(query, new { Id = id });

        }

        public override IList<Turma> ObterTodos()
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Turmas ";
            return dbConnection.Query<Turma>(query).ToList();
        }
    }
}

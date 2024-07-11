using Dapper;
using FiapStore.Entidade;
using FiapStore.Interface;
using System.Data.Common;
using System.Data.SqlClient;

namespace FiapStore.Repository
{
    public class MatriculasRepository : DapperRepository<Matricula>, IMatriculaRepository
    {
        public MatriculasRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public override void Alterar(Matricula entidade)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "UPDATE Matriculas SET aluno_id = @AlunoId, turma_id = @TurmaId, data_matricula = @DataMatricula WHERE matricula_id = @MatriculaId ";
            dbConnection.Query(query, entidade);
        }

        public override void Cadastrar(Matricula entidade)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "INSERT INTO Matriculas  VALUES (@MatriculaId, @AlunoId, @TurmaId, @DataMatricula)";
            dbConnection.Execute(query, entidade);
        }

        public override void Deletar(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "DELETE FROM Matriculas where turma_id = @Id";
            dbConnection.Execute(query, new { Id = id });
        }

        public override Matricula ObterPorId(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Matriculas where matricula_id = @Id";
            return dbConnection.QueryFirstOrDefault<Matricula>(query, new { Id = id });

        }

        public override IList<Matricula> ObterTodos()
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Matriculas ";
            return dbConnection.Query<Matricula>(query).ToList();
        }
    }
}

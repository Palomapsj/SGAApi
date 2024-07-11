using Dapper;
using FiapStore.Entidade;
using FiapStore.Interface;
using System.Data.Common;
using System.Data.SqlClient;

namespace FiapStore.Repository
{
    public class CursosRepository : DapperRepository<Curso>, ICursoRepository
    {
        public CursosRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public override void Alterar(Curso entidade)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "UPDATE Cursos SET DESCRICAO = @Descricao, Data_inicio = @DataInicio, Data_fim = @DataFim, NOME = @Nome WHERE aluno_id = @AlunoId ";
            dbConnection.Query(query, entidade);
        }

        public override void Cadastrar(Curso entidade)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "INSERT INTO Cursos  VALUES (@Nome, @Descricao, @DataInicio, @DataFim)";
            dbConnection.Execute(query, entidade);
        }

        public override void Deletar(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "DELETE FROM Cursos where curso_id = @Id";
            dbConnection.Execute(query, new { Id = id });
        }

        public override Curso ObterPorId(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Cursos where curso_id = @Id";
            return dbConnection.QueryFirstOrDefault<Curso>(query, new { Id = id });

        }

        public override IList<Curso> ObterTodos()
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Cursos ";
            return dbConnection.Query<Curso>(query).ToList();
        }
    }
}

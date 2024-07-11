using Dapper;
using FiapStore.Entidade;
using FiapStore.Interface;
using System.Data.Common;
using System.Data.SqlClient;

namespace FiapStore.Repository
{
    public class AlunoRepository : DapperRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public override void Alterar(Aluno entidade)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "UPDATE Alunoss SET ENDERECO = @Endereco, TELEFONE = @Telefone, EMAIL = @Email WHERE aluno_id = @AlunoId ";
            dbConnection.Query(query, entidade);
        }

        public override void Cadastrar(Aluno entidade)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "INSERT INTO Alunoss  VALUES (@Nome, @DataNascimento, @Email, @Telefone, @Endereco, @UsuarioId)";
            dbConnection.Execute(query, entidade);
        }

        public override void Deletar(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "DELETE FROM Alunoss where Aluno_id = @Id";
            dbConnection.Execute(query, new { Id = id });
        }

        public override Aluno ObterPorId(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Alunoss where Aluno_id = @Id";
            return dbConnection.QueryFirstOrDefault<Aluno>(query, new { Id = id });

        }

        public override IList<Aluno> ObterTodos()
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM Alunoss ";
            return dbConnection.Query<Aluno>(query).ToList();
        }
    }
}

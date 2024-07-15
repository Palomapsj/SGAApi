using Dapper;
using FiapStore.Entidade;
using FiapStore.Interface;
using RabbitMQ.Client;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;

namespace FiapStore.Repository
{
    public class AlunoRepository : DapperRepository<Aluno>, IAlunoRepository
    {
        private readonly ConnectionFactory _factory;

        public AlunoRepository(IConfiguration configuration) : base(configuration)
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public override void Alterar(Aluno entidade)
        {
            PublishToQueue("queue-aluno-update", entidade);
        }

        public override void Cadastrar(Aluno entidade)
        {
            PublishToQueue("queue-aluno-save", entidade);
        }

        public override void Deletar(int id)
        {
            Aluno entidade = new Aluno();
            entidade.Id = id;

            PublishToQueue("queue-aluno-delete", entidade);
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

        private void PublishToQueue(string queueName, Aluno entidade)
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = JsonSerializer.SerializeToUtf8Bytes(entidade);
                channel.BasicPublish(exchange: "",
                                     routingKey: queueName,
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}

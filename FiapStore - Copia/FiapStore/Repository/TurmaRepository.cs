using Dapper;
using FiapStore.Entidade;
using FiapStore.Interface;
using RabbitMQ.Client;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;

namespace FiapStore.Repository
{
    public class TurmaRepository : DapperRepository<Turma>, ITurmaRepository
    {
        private readonly ConnectionFactory _factory;
        public TurmaRepository(IConfiguration configuration) : base(configuration)
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }
        public override void Alterar(Turma entidade)
        {
            PublishToQueue("queue-turma-update", entidade);
        }

        public override void Cadastrar(Turma entidade)
        {
            PublishToQueue("queue-turma-save", entidade);
        }

        public override void Deletar(int id)
        {
            Turma entidade = new Turma();
            entidade.Id = id;

            PublishToQueue("queue-turma-delete", entidade);
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

        private void PublishToQueue(string queueName, Turma entidade)
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

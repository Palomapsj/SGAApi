using Dapper;
using FiapStore.Entidade;
using FiapStore.Interface;
using RabbitMQ.Client;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;

namespace FiapStore.Repository
{
    public class MatriculasRepository : DapperRepository<Matricula>, IMatriculaRepository
    {
        private readonly ConnectionFactory _factory;
        public MatriculasRepository(IConfiguration configuration) : base(configuration)
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public override void Alterar(Matricula entidade)
        {
            PublishToQueue("queue-matricula-update", entidade);
        }

        public override void Cadastrar(Matricula entidade)
        {
            PublishToQueue("queue-matricula-save", entidade);
        }

        public override void Deletar(int id)
        {
            Matricula entidade = new Matricula();
            entidade.Id = id;

            PublishToQueue("queue-curso-delete", entidade);
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

        private void PublishToQueue(string queueName, Matricula entidade)
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

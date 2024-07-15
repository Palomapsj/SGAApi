using Dapper;
using FiapStore.Entidade;
using FiapStore.Interface;
using System.Data.Common;
using System.Data.SqlClient;
using RabbitMQ.Client;
using System.Text.Json;

namespace FiapStore.Repository
{
    public class CursosRepository : DapperRepository<Curso>, ICursoRepository
    {
        private readonly ConnectionFactory _factory;

        public CursosRepository(IConfiguration configuration) : base(configuration)
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public override void Alterar(Curso entidade)
        {
            PublishToQueue("queue-curso-update", entidade);
        }

        public override void Cadastrar(Curso entidade)
        {
            PublishToQueue("queue-curso-save", entidade);
        }

        public override void Deletar(int id)
        {
            Curso entidade = new Curso();
            entidade.Id = id;

            PublishToQueue("queue-curso-delete", entidade);
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

        private void PublishToQueue(string queueName, Curso entidade)
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

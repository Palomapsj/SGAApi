using Dapper;
using FiapStore.Entidade;
using FiapStore.Interface;
using RabbitMQ.Client;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;

namespace FiapStore.Repository
{
    public class ProfessoresRepository : DapperRepository<Professor>, IProfessorRepository
    {
        private readonly ConnectionFactory _factory;
        public ProfessoresRepository(IConfiguration configuration) : base(configuration)
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public override void Alterar(Professor entidade)
        {
            PublishToQueue("queue-professor-save", entidade);
        }

        public override void Cadastrar(Professor entidade)
        {
            PublishToQueue("queue-professor-update", entidade);
        }

        public override void Deletar(int id)
        {
            Professor entidade = new Professor();
            entidade.Id = id;

            PublishToQueue("queue-professor-delete", entidade);
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

        private void PublishToQueue(string queueName, Professor entidade)
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

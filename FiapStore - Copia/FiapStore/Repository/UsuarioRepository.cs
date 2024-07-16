using Dapper;
using FiapStore.Entidade;
using FiapStore.Interface;
using RabbitMQ.Client;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text.Json;

namespace FiapStore.Repository
{
    public class UsuarioRepository : DapperRepository<Usuario>, IUsuarioRepository
    {
        private readonly ConnectionFactory _factory;
        private IList<Usuario> _usuario = new List<Usuario>();

        public UsuarioRepository(IConfiguration configuration) : base(configuration)
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };
        }

        public override void Alterar(Usuario entidade)
        {
            PublishToQueue("queue-usuario-update", entidade);
        }

        public override void Cadastrar(Usuario entidade)
        {
            PublishToQueue("queue-usuario-save", entidade);
        }

        public override void Deletar(int id)
        {
            Usuario entidade = new Usuario();
            entidade.Id = id;

            PublishToQueue("queue-usuario-delete", entidade);
        }

        public override Usuario ObterPorId(int id)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM USUARIO where id = @Id";

            return dbConnection.QueryFirstOrDefault<Usuario>(query, new { Id = id });

        }

        public override IList<Usuario> ObterTodos()
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM USUARIO";
            return dbConnection.Query<Usuario>(query).ToList();
        }

        private void PublishToQueue(string queueName, Usuario entidade)
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
        public Usuario GetUserByNameAndPassword(string userName, string password)
        {
            using var dbConnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM USUARIO where username = @userName and senha = @password";

            return dbConnection.QueryFirstOrDefault<Usuario>(query, new { userName, password });
        }
    }
}

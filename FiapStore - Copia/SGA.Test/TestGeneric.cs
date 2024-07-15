
using FiapStore.Entidade;
using FiapStore.Interface;
using Moq;

namespace SGA.Test
{
    public class TestGeneric
    {
        [Fact]
        public void TestValidateLogin_ValidCredentials_ReturnsUser()
        {
            // Arrange
            var mockRepository = new Mock<IUsuarioRepository>();
            mockRepository.Setup(repo => repo.GetUserByNameAndPassword("paloma.jesus", "12345"))
                          .Returns(new Usuario { Name = "paloma.jesus" });

            // Assert e Act ao mesmo tempo
            Assert.NotNull(mockRepository.Object.GetUserByNameAndPassword("paloma.jesus", "12345"));
        }

        [Fact]
        public void ValidateUserName_Should_Return_Max()
        {
            // Arrange
            var mockRepository = new Mock<IUsuarioRepository>();

            Usuario user = new Usuario
            {
                Name = "Raphael Arena",
                Senha = "4343434343677676667676",
                UserName = "raphaelarenagelonezi20101996raphaelarena_@hotmail.com.br",
            };

            mockRepository.Setup(repo => repo.Cadastrar(It.IsAny<Usuario>()))
                 .Callback<Usuario>((newUser) => user = newUser);

            // Act
            mockRepository.Object.Cadastrar(user);

            // Assert
            Assert.True(user.UserName.Length <= 50);
        }

        [Fact]
        public void ValidarCadastroAluno()
        {
            // Arrange
            var mockRepository = new Mock<IAlunoRepository>();

            Aluno aluno = new Aluno
            {
               
            Nome = "Aluno Gustavo",
            DataNascimento = DateTime.Now,
            Email = "Gustavo.coimbra@gmail.com",
            Telefone = "11953020830",
            Endereco = "Estrada kizaemon takeuti",
            UsuarioId = 1,



        };

            mockRepository.Setup(repo => repo.Cadastrar(It.IsAny<Aluno>()))
                 .Callback<Aluno>((newAluno) => aluno = newAluno);

            // Act
            mockRepository.Object.Cadastrar(aluno);

            // Assert
        }

        [Fact]
        public void ValidarCadastroCurso()
        {
            // Arrange
            var mockRepository = new Mock<ICursoRepository>();

            Curso curso = new Curso
            {

            Nome = "Jogos digitais",
            Descricao = "Curso voltado para estudantes de programação",
            DataInicio = DateTime.Now,
            DataFim = DateTime.Now,



            };

            mockRepository.Setup(repo => repo.Cadastrar(It.IsAny<Curso>()))
                 .Callback<Curso>((newCurso) => curso = newCurso);

            // Act
            mockRepository.Object.Cadastrar(curso);

            // Assert
        }
    }
}
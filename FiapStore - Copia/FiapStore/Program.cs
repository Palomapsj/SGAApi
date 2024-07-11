using FiapStore.Interface;
using FiapStore.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddSingleton<IAlunoRepository, AlunoRepository>();
builder.Services.AddSingleton<IProfessorRepository, ProfessoresRepository>();
builder.Services.AddSingleton<ICursoRepository, CursosRepository>();
builder.Services.AddSingleton<ITurmaRepository, TurmaRepository>();
builder.Services.AddSingleton<IMatriculaRepository, MatriculasRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

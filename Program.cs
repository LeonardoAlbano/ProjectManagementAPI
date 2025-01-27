using System.Data;
using Npgsql;
using ProjectManagementAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configura��o de CORS
var corsPolicyName = "AllowFrontend";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy.WithOrigins("http://localhost:3000") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Registra a conex�o com o banco de dados
builder.Services.AddScoped<IDbConnection>(sp =>
    new NpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra o reposit�rio ProjectRepository
builder.Services.AddScoped<ProjectRepository>();

// Adiciona os servi�os necess�rios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure o pipeline de requisi��es HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Ativa o CORS antes dos middlewares de roteamento
app.UseCors(corsPolicyName);

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

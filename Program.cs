using System.Data;
using Npgsql;
using ProjectManagementAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuração de CORS
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

// Registra a conexão com o banco de dados
builder.Services.AddScoped<IDbConnection>(sp =>
    new NpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra o repositório ProjectRepository
builder.Services.AddScoped<ProjectRepository>();

// Adiciona os serviços necessários
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure o pipeline de requisições HTTP
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

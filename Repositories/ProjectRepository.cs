using Dapper;
using ProjectManagementAPI.Models;
using System.Data;

namespace ProjectManagementAPI.Repositories
{
    public class ProjectRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProjectRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            string query = "SELECT * FROM Projects";
            return await _dbConnection.QueryAsync<Project>(query);
        }

        public async Task<int> AddProjectAsync(Project project)
        {
            string query = @"
                 INSERT INTO Projects (Title, Description, ProjectLink, LanguagesUsed, Category, SubCategory, TechnicalDetails, Statistics, Documentation)
                 VALUES (@Title, @Description, @ProjectLink, @LanguagesUsed, @Category, @SubCategory, @TechnicalDetails, @Statistics, @Documentation)";

            // Usando a variável 'query' para executar a query com os parâmetros do projeto
            return await _dbConnection.ExecuteAsync(query, project);
        }

    }
}


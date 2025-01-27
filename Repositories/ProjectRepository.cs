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
            string query = "SELECT * FROM projects";
            return await _dbConnection.QueryAsync<Project>(query);
        }

        public async Task<bool> UpdateProjectAsync(Project project)
        {
            string query = @"
                UPDATE projects 
                SET title = @Title, 
                description = @Description, 
                projectUrl = @ProjectUrl, 
                language = @Language, 
                category = @Category, 
                images = @Images, 
                technicalDetails = @TechnicalDetails, 
                statistics = @Statistics, 
                documentation = @Documentation
                WHERE id = @Id";

            var result = await _dbConnection.ExecuteAsync(query, project);
            return result > 0; 
        }


        public async Task<bool> DeleteProjectAsync(int id)
        {
            string query = "DELETE FROM projects WHERE id = @Id";
            var result = await _dbConnection.ExecuteAsync(query, new { Id = id });
            return result > 0;
        }

        public async Task<int> AddProjectAsync(Project project)
        {
            string query = @"
                INSERT INTO projects (title, description, projectUrl, language, category, images, technicalDetails, statistics, documentation)
                VALUES (@Title, @Description, @ProjectUrl, @Language, @Category, @Images, @TechnicalDetails, @Statistics, @Documentation)
                RETURNING id";

   
            return await _dbConnection.ExecuteAsync(query, project);
        }

    }
}


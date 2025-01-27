using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.Models;
using ProjectManagementAPI.Repositories;

namespace ProjectManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectRepository _repository;

        public ProjectController(ProjectRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjects()
        {
            var projects = await _repository.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] Project project)
        {
            await _repository.AddProjectAsync(project);
            return Ok(new { message = "Project added successfully!" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] Project project)
        {
            if (id != project.Id)
            {
                return BadRequest(new { message = "O ID fornecido não corresponde ao ID do projeto." });
            }

            var success = await _repository.UpdateProjectAsync(project);
            if (!success)
            {
                return NotFound(new { message = "Projeto não encontrado" });
            }

            return Ok(new { message = "Projeto atualizado com sucesso!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var success = await _repository.DeleteProjectAsync(id);
            if (!success)
            {
                return NotFound(new { message = "Projeto não encontrado" });
            }
            return Ok(new { message = "Projeto excluído com sucesso" });
        }

    }
}

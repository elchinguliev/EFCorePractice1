using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Models;

namespace PracticeProject.Controllers
{
    public class ProjectController : Controller
    {
        private readonly EmployerProjectDbContext employerProjectDbContext;

        public ProjectController(EmployerProjectDbContext employerProjectDbContext)
        {
            this.employerProjectDbContext=employerProjectDbContext;
        }

        [HttpGet("projects")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await employerProjectDbContext.Projects.ToListAsync();
        }

        [HttpGet("projects/{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await employerProjectDbContext.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        [HttpPost("projects")]
        public async Task<ActionResult<Project>> CreateProject([FromBody] Project project)
        {
            employerProjectDbContext.Projects.Add(project);
            await employerProjectDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        [HttpPut("projects/{id}")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            employerProjectDbContext.Entry(project).State = EntityState.Modified;

            try
            {
                await employerProjectDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("projects/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await employerProjectDbContext.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            employerProjectDbContext.Projects.Remove(project);
            await employerProjectDbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
            return employerProjectDbContext.Projects.Any(e => e.Id == id);
        }
    }
}

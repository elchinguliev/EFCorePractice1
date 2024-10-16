using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Models;

namespace PracticeProject.Controllers
{
    public class EmployerProjectController : Controller
    {
        private readonly EmployerProjectDbContext employerProjectDbContext;

        public EmployerProjectController(EmployerProjectDbContext employerProjectDbContext)
        {
            this.employerProjectDbContext=employerProjectDbContext;
        }
        [HttpPost("assign-project-to-employer")]
        public async Task<ActionResult> AssignProjectToEmployer(int employerId, int projectId)
        {
            var employer = await employerProjectDbContext.Employers.FindAsync(employerId);
            var project = await employerProjectDbContext.Projects.FindAsync(projectId);

            if (employer == null || project == null)
            {
                return NotFound("Employer or Project not found");
            }

            var employerProject = new EmployerProject
            {
                EmployerId = employerId,
                ProjectId = projectId
            };

            employerProjectDbContext.EmployerProjects.Add(employerProject);
            await employerProjectDbContext.SaveChangesAsync();

            return Ok("Project assigned to employer successfully");
        }

        [HttpDelete("remove-project-from-employer")]
        public async Task<ActionResult> RemoveProjectFromEmployer(int employerId, int projectId)
        {
            var employerProject = await employerProjectDbContext.EmployerProjects
                .FirstOrDefaultAsync(ep => ep.EmployerId == employerId && ep.ProjectId == projectId);

            if (employerProject == null)
            {
                return NotFound("The specified project is not assigned to the employer");
            }

            employerProjectDbContext.EmployerProjects.Remove(employerProject);
            await employerProjectDbContext.SaveChangesAsync();

            return Ok("Project removed from employer successfully");
        }
    }
}

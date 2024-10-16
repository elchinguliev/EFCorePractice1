using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticeProject.Models;
using System.Collections;

namespace PracticeProject.Controllers
{
    public class EmployerController : Controller
    {

        private readonly EmployerProjectDbContext employerProjectDbContext;

        public EmployerController(EmployerProjectDbContext employerProjectDbContext)
        {
            this.employerProjectDbContext=employerProjectDbContext;
        }

        [HttpGet("employers")]
        public async Task<ActionResult<IEnumerable<Employer>>> GetEmployers()
        {
            return await employerProjectDbContext.Employers.ToListAsync();
        }

        [HttpGet("employers/{id}")]
        public async Task<ActionResult<Employer>> GetEmployer(int id)
        {
            var employer = await employerProjectDbContext.Employers.FindAsync(id);

            if (employer == null)
            {
                return NotFound();
            }

            return employer;
        }
        [HttpPost("employers")]
        public async Task<ActionResult<Employer>> CreateEmployer([FromBody] Employer employer)
        {
            employerProjectDbContext.Employers.Add(employer);
            await employerProjectDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployer), new { id = employer.Id }, employer);
        }

        [HttpPut("employers/{id}")]
        public async Task<IActionResult> UpdateEmployer(int id, [FromBody] Employer employer)
        {
            if (id != employer.Id)
            {
                return BadRequest();
            }

            employerProjectDbContext.Entry(employer).State = EntityState.Modified;

            try
            {
                await employerProjectDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerExists(id))
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

        [HttpDelete("employers/{id}")]
        public async Task<IActionResult> DeleteEmployer(int id)
        {
            var employer = await employerProjectDbContext.Employers.FindAsync(id);
            if (employer == null)
            {
                return NotFound();
            }

            employerProjectDbContext.Employers.Remove(employer);
            await employerProjectDbContext.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployerExists(int id)
        {
            return employerProjectDbContext.Employers.Any(e => e.Id == id);
        }

    
    }
}

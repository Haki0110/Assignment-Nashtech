using EntityFrameworkAssignment1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkAssignment1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectEmployeesController : ControllerBase
    {
        private readonly MyDbContext myContext;

        public ProjectEmployeesController(MyDbContext context)
        {
            myContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectEmployee>>> GetProjectEmployees()
        {
            return await myContext.ProjectEmployees.ToListAsync();
        }

        [HttpGet("{projectId}/{employeeId}")]
        public async Task<ActionResult<ProjectEmployee>> GetProjectEmployee(int projectId, int employeeId)
        {
            var projectEmployee = await myContext.ProjectEmployees
                .FirstOrDefaultAsync(pe => pe.ProjectId == projectId && pe.EmployeeId == employeeId);

            if (projectEmployee == null)
            {
                return NotFound();
            }

            return projectEmployee;
        }

        [HttpPost]
        public async Task<ActionResult<ProjectEmployee>> PostProjectEmployee(ProjectEmployee projectEmployee)
        {
            myContext.ProjectEmployees.Add(projectEmployee);
            await myContext.SaveChangesAsync();

            return CreatedAtAction("GetProjectEmployee", new { projectId = projectEmployee.ProjectId, employeeId = projectEmployee.EmployeeId }, projectEmployee);
        }

        [HttpPut("{projectId}/{employeeId}")]
        public async Task<IActionResult> PutProjectEmployee(int projectId, int employeeId, ProjectEmployee projectEmployee)
        {
            if (projectId != projectEmployee.ProjectId || employeeId != projectEmployee.EmployeeId)
            {
                return BadRequest();
            }

            myContext.Entry(projectEmployee).State = EntityState.Modified;

            try
            {
                await myContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectEmployeeExists(projectId, employeeId))
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

        [HttpDelete("{projectId}/{employeeId}")]
        public async Task<IActionResult> DeleteProjectEmployee(int projectId, int employeeId)
        {
            var projectEmployee = await myContext.ProjectEmployees
                .FirstOrDefaultAsync(pe => pe.ProjectId == projectId && pe.EmployeeId == employeeId);
            if (projectEmployee == null)
            {
                return NotFound();
            }

            myContext.ProjectEmployees.Remove(projectEmployee);
            await myContext.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectEmployeeExists(int projectId, int employeeId)
        {
            return myContext.ProjectEmployees.Any(pe => pe.ProjectId == projectId && pe.EmployeeId == employeeId);
        }
    }
}

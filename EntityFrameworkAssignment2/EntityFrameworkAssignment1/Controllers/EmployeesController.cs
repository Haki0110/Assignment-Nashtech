using EntityFrameworkAssignment1.DTOs;
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
    public class EmployeesController : ControllerBase
    {
        private readonly MyDbContext myContext;

        public EmployeesController(MyDbContext context)
        {
            myContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employees = await myContext.Employees
                .Include(e => e.Department)
                .Include(e => e.Salary)
                .Include(e => e.ProjectEmployees)
                    .ThenInclude(pe => pe.Project)
                .ToListAsync();
            //dùng automapper
            var employeeDTOs = employees.Select(e => new EmployeeDTO
            {
                Id = e.Id,
                Name = e.Name,
                DepartmentId = e.DepartmentId,
                JoinedDate = e.JoinedDate,
                Department = e.Department != null ? new DepartmentDTO
                {
                    Id = e.Department.Id,
                    Name = e.Department.Name
                } : null,
                Salary = e.Salary != null ? new SalaryDTO
                {
                    Id = e.Salary.Id,
                    Amount = e.Salary.Amount,
                    EmployeeId = e.Salary.EmployeeId
                } : null,
                ProjectEmployees = e.ProjectEmployees?.Select(pe => new ProjectEmployeeDTO
                {
                    EmployeeId = pe.EmployeeId,
                    ProjectId = pe.ProjectId,
                    Enabled = pe.Enabled,
                    Project = pe.Project != null ? new ProjectDTO
                    {
                        Id = pe.Project.Id,
                        Name = pe.Project.Name
                    } : null
                }).ToList()
            }).ToList();

            return Ok(employeeDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            var employee = await myContext.Employees
                .Include(e => e.Department)
                .Include(e => e.Salary)
                .Include(e => e.ProjectEmployees)
                    .ThenInclude(pe => pe.Project)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok((EmployeeDTO)employee);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> PostEmployee(EmployeeDTO employeeDTO)
        {
            var employee = (Employee)employeeDTO;
            myContext.Employees.Add(employee);
            await myContext.SaveChangesAsync();

            var createdEmployeeDTO = (EmployeeDTO)employee;
            return CreatedAtAction("GetEmployee", new { id = employee.Id }, createdEmployeeDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeeDTO employeeDTO)
        {
            if (id != employeeDTO.Id)
            {
                return BadRequest();
            }

            var employee = (Employee)employeeDTO;
            myContext.Entry(employee).State = EntityState.Modified;

            try
            {
                await myContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await myContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            myContext.Employees.Remove(employee);
            await myContext.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return myContext.Employees.Any(e => e.Id == id);
        }

        [HttpGet("EmpWithDepartment")]
        public async Task<ActionResult<IEnumerable<object>>> GetEmployeeWithDepartment()
        {
            var employees = await myContext.Employees
                .Include(e => e.Department)
                .ToListAsync();

            var result = employees.Select(e => new
            {
                e.Id,
                e.Name,
                DepartmentName = e.Department.Name,
            });

            return Ok(result);
        }

        [HttpGet("GetEmpWithPrj")]
        public async Task<ActionResult<IEnumerable<object>>> GetEmployeeWithPrj()
        {
            var task = from employee in myContext.Employees
                       join empprj in myContext.ProjectEmployees on employee.Id equals empprj.EmployeeId into ee
                       from empp in ee.DefaultIfEmpty()
                       select new
                       {
                           EmployeeID = employee.Id,
                           Employeename = employee.Name,
                           EmployeeProject = empp.Project != null ? new { empp.Project.Id, empp.Project.Name } : null
                       };

            return Ok(await task.ToListAsync());
        }

        [HttpGet("FilterSalaryAndDate")]
        public async Task<ActionResult<IEnumerable<object>>> GetEmployeeFilter()
        {
            var result = await myContext.Employees
                .Where(emp => emp.Salary.Amount >= 100 && emp.JoinedDate >= new DateTime(2024, 1, 1))
                .Select(e => new
                {
                    e.Id,
                    e.Name,
                    Salary = e.Salary.Amount,
                    e.JoinedDate
                })
                .ToListAsync();

            return Ok(result);
        }

        [HttpGet("RawSQL")]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesWithSalaryAndJoinedDateRawSQL()
        {
            var employees = await myContext.Employees
                .FromSqlRaw("SELECT * FROM Employees WHERE Salary_Amount > 100 AND JoinedDate >= '2024-01-01'")
                .ToListAsync();

            var employeeDTOs = employees.Select(e => (EmployeeDTO)e).ToList();
            return Ok(employeeDTOs);
        }

        // Apply transaction
        [HttpPost("Transaction")]
        public async Task<ActionResult<EmployeeDTO>> PostEmployeeWithTransaction(EmployeeDTO employeeDTO)
        {
            using (var transaction = myContext.Database.BeginTransaction())
            {
                try
                {
                    var employee = (Employee)employeeDTO;
                    myContext.Employees.Add(employee);
                    await myContext.SaveChangesAsync();

                    transaction.Commit();

                    var createdEmployeeDTO = (EmployeeDTO)employee;
                    return CreatedAtAction("GetEmployee", new { id = employee.Id }, createdEmployeeDTO);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return StatusCode(500, "An error occurred while saving the employee.");
                }
            }
        }
    }
}

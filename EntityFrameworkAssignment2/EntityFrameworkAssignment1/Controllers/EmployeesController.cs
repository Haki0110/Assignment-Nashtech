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
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await myContext.Employees.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await myContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            myContext.Employees.Add(employee);
            await myContext.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

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
        public async Task<ActionResult<IEnumerable<Object>>> GetEmployeeWithDepartment()
        {
            return await myContext.Employees.Select(e => new
            {
                e.Id,
                e.Name,
                DepartmentName = e.Department.Name,
            }).ToListAsync();
        }

        [HttpGet("GetEmpWithPrj")]
        public async Task<ActionResult<IEnumerable<Object>>> GetEmployeeWithPrj()
        {
            var task = from employee in myContext.Employees
                       join empprj in myContext.ProjectEmployees on employee.Id equals empprj.EmployeeId into ee
                       from empp in ee.DefaultIfEmpty()
                       select new
                       {
                           EmployeeID = employee.Id,
                           Employeename = employee.Name,
                           EmployeeProject = empp.Project
                       };
            return await task.ToListAsync();
        }


        [HttpGet("FilterSalaryAndDAte")]
        public async Task<ActionResult<IEnumerable<Object>>> GetEmployeeFilter()
        {
            return await myContext.Employees
                .Where(emp => emp.Salary.Amount >= 100 && emp.JoinedDate >= new DateTime(2024, 1, 1))
                .Select(e => new
                {
                    e.Id,
                    e.Name,
                    Salary = e.Salary.Amount,
                    e.JoinedDate
                })
                .ToListAsync();
        }

        [HttpGet("RawSQL")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesWithSalaryAndJoinedDateRawSQL()
        {
            return await myContext.Employees
                .FromSqlRaw("SELECT * FROM Employees WHERE Salary_Amount > 100 AND JoinedDate >= '2024-01-01'")
                .ToListAsync();
        }

        // Apply transaction
        [HttpPost("Transaction")]
        public async Task<ActionResult<Employee>> PostEmployeeWithTransaction(Employee employee)
        {
            using (var transaction = myContext.Database.BeginTransaction())
            {
                try
                {
                    myContext.Employees.Add(employee);
                    await myContext.SaveChangesAsync();

                    transaction.Commit();

                    return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
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

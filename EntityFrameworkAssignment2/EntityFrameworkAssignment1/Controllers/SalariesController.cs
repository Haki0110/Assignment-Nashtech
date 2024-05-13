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
    public class SalariesController : ControllerBase
    {
        private readonly MyDbContext myContext;

        public SalariesController(MyDbContext context)
        {
            myContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salary>>> GetSalaries()
        {
            return await myContext.Salaries.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Salary>> GetSalary(int id)
        {
            var salary = await myContext.Salaries.FindAsync(id);

            if (salary == null)
            {
                return NotFound();
            }

            return salary;
        }

        [HttpPost]
        public async Task<ActionResult<Salary>> PostSalary(Salary salary)
        {
            myContext.Salaries.Add(salary);
            await myContext.SaveChangesAsync();

            return CreatedAtAction("GetSalary", new { id = salary.Id }, salary);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalary(int id, Salary salary)
        {
            if (id != salary.Id)
            {
                return BadRequest();
            }

            myContext.Entry(salary).State = EntityState.Modified;

            try
            {
                await myContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaryExists(id))
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
        public async Task<IActionResult> DeleteSalary(int id)
        {
            var salary = await myContext.Salaries.FindAsync(id);
            if (salary == null)
            {
                return NotFound();
            }

            myContext.Salaries.Remove(salary);
            await myContext.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaryExists(int id)
        {
            return myContext.Salaries.Any(s => s.Id == id);
        }
    }
}

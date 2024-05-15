using System.ComponentModel.DataAnnotations;
using EntityFrameworkAssignment1.DTOs;

namespace EntityFrameworkAssignment1.Model
{
    public class Salary
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Salary amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary amount must be non-negative")]
        public int Amount { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public static implicit operator Salary(SalaryDTO dto)
        {
            return new Salary
            {
                Id = dto.Id,
                Amount = dto.Amount,
                EmployeeId = dto.EmployeeId,
                Employee = dto.Employee
            };
        }

        public static implicit operator SalaryDTO(Salary model)
        {
            return new SalaryDTO
            {
                Id = model.Id,
                Amount = model.Amount,
                EmployeeId = model.EmployeeId,
                Employee = model.Employee
            };
        }
    }
}

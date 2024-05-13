using System.ComponentModel.DataAnnotations;

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
    }
}

using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkAssignment1.Model
{
    public class Employee
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public DateTime JoinedDate { get; set; }
        public Department Department { get; set; }
        public Salary Salary { get; set; }
        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}

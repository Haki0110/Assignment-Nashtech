using System.ComponentModel.DataAnnotations;
using EntityFrameworkAssignment1.DTOs;

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

        public static implicit operator Employee(EmployeeDTO dto)
        {
            return new Employee
            {
                Id = dto.Id,
                Name = dto.Name,
                DepartmentId = dto.DepartmentId,
                JoinedDate = dto.JoinedDate,
                Department = dto.Department,
                Salary = dto.Salary,
                ProjectEmployees = dto.ProjectEmployees?.Select(pe => (ProjectEmployee)pe).ToList()
            };
        }

        public static implicit operator EmployeeDTO(Employee model)
        {
            return new EmployeeDTO
            {
                Id = model.Id,
                Name = model.Name,
                DepartmentId = model.DepartmentId,
                JoinedDate = model.JoinedDate,
                Department = model.Department,
                Salary = model.Salary,
                ProjectEmployees = model.ProjectEmployees?.Select(pe => (ProjectEmployeeDTO)pe).ToList()
            };
        }
    }
}

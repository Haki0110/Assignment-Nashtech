using EntityFrameworkAssignment1.DTOs;

namespace EntityFrameworkAssignment1.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public static implicit operator Department(DepartmentDTO dto)
        {
            return new Department
            {
                Id = dto.Id,
                Name = dto.Name,
                Employees = dto.Employees?.Select(e => (Employee)e).ToList()
            };
        }

        public static implicit operator DepartmentDTO(Department model)
        {
            return new DepartmentDTO
            {
                Id = model.Id,
                Name = model.Name,
                Employees = model.Employees?.Select(e => (EmployeeDTO)e).ToList()
            };
        }
    }
}

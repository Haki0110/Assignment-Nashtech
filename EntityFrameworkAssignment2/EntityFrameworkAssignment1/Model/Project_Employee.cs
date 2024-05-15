using EntityFrameworkAssignment1.DTOs;

namespace EntityFrameworkAssignment1.Model
{
    public class ProjectEmployee
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public bool Enabled { get; set; }
        public Project Project { get; set; }
        public Employee Employee { get; set; }

        public static implicit operator ProjectEmployee(ProjectEmployeeDTO dto)
        {
            return new ProjectEmployee
            {
                ProjectId = dto.ProjectId,
                EmployeeId = dto.EmployeeId,
                Enabled = dto.Enabled,
                Project = dto.Project,
                Employee = dto.Employee
            };
        }

        public static implicit operator ProjectEmployeeDTO(ProjectEmployee model)
        {
            return new ProjectEmployeeDTO
            {
                ProjectId = model.ProjectId,
                EmployeeId = model.EmployeeId,
                Enabled = model.Enabled,
                Project = model.Project,
                Employee = model.Employee
            };
        }
    }
}

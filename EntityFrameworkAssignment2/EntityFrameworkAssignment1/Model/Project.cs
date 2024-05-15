using EntityFrameworkAssignment1.DTOs;

namespace EntityFrameworkAssignment1.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }

        public static implicit operator Project(ProjectDTO dto)
        {
            return new Project
            {
                Id = dto.Id,
                Name = dto.Name,
                ProjectEmployees = dto.ProjectEmployees?.Select(pe => (ProjectEmployee)pe).ToList()
            };
        }

        public static implicit operator ProjectDTO(Project model)
        {
            return new ProjectDTO
            {
                Id = model.Id,
                Name = model.Name,
                ProjectEmployees = model.ProjectEmployees?.Select(pe => (ProjectEmployeeDTO)pe).ToList()
            };
        }
    }
}

namespace EntityFrameworkAssignment1.DTOs
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProjectEmployeeDTO> ProjectEmployees { get; set; }
    }
}

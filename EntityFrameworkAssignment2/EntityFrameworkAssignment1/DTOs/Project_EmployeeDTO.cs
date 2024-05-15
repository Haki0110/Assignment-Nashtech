namespace EntityFrameworkAssignment1.DTOs
{
    public class ProjectEmployeeDTO
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public bool Enabled { get; set; }
        public ProjectDTO Project { get; set; }
        public EmployeeDTO Employee { get; set; }
    }
}

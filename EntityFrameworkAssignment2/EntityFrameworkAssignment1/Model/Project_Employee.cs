namespace EntityFrameworkAssignment1.Model
{
    public class ProjectEmployee
    {
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }
        public bool Enabled { get; set; }
        public Project Project { get; set; }
        public Employee Employee { get; set; }
    }
}

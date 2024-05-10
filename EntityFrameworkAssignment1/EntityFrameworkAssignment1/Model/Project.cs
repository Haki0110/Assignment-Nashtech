namespace EntityFrameworkAssignment1.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}

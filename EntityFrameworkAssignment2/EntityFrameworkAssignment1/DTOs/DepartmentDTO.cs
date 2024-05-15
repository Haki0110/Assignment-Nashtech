namespace EntityFrameworkAssignment1.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeDTO> Employees { get; set; }
    }
}

namespace EntityFrameworkAssignment1.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public DateTime JoinedDate { get; set; }
        public DepartmentDTO Department { get; set; }
        public SalaryDTO Salary { get; set; }
        public ICollection<ProjectEmployeeDTO> ProjectEmployees { get; set; }
    }
}

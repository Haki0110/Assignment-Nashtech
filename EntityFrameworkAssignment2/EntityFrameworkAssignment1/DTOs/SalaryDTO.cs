namespace EntityFrameworkAssignment1.DTOs
{
    public class SalaryDTO
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDTO Employee { get; set; }
    }
}

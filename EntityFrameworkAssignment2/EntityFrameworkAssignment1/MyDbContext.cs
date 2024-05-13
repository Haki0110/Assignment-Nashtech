using EntityFrameworkAssignment1.Model;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkAssignment1
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<Salary> Salaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationships
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Salary)
                .WithOne(s => s.Employee)
                .HasForeignKey<Salary>(s => s.EmployeeId);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<ProjectEmployee>()
                .HasKey(pe => new { pe.ProjectId, pe.EmployeeId });

            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(pe => pe.Project)
                .WithMany(p => p.ProjectEmployees)
                .HasForeignKey(pe => pe.ProjectId);

            modelBuilder.Entity<ProjectEmployee>()
                .HasOne(pe => pe.Employee)
                .WithMany(e => e.ProjectEmployees)
                .HasForeignKey(pe => pe.EmployeeId);

            // Constraints using Fluent API
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            // 5.Constraints using Data Annotations
            modelBuilder.Entity<Department>()
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Software Development" },
                new Department { Id = 2, Name = "Finance" },
                new Department { Id = 3, Name = "Accountant" },
                new Department { Id = 4, Name = "HR" }
            );

            // Seed Projects
            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Name = "Project 1" },
                new Project { Id = 2, Name = "Project 2" },
                new Project { Id = 3, Name = "Project 3" },
                new Project { Id = 4, Name = "Project 4" },
                new Project { Id = 5, Name = "Project 5" }
            );

            // Seed Employees with DepartmentId
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "John Doe", DepartmentId = 1, JoinedDate = DateTime.Now },
                new Employee { Id = 2, Name = "Jane Smith", DepartmentId = 2, JoinedDate = DateTime.Now },
                new Employee { Id = 3, Name = "Michael Johnson", DepartmentId = 1, JoinedDate = DateTime.Now },
                new Employee { Id = 4, Name = "Emily Brown", DepartmentId = 3, JoinedDate = DateTime.Now },
                new Employee { Id = 5, Name = "David Wilson", DepartmentId = 2, JoinedDate = DateTime.Now },
                new Employee { Id = 6, Name = "Jessica Lee", DepartmentId = 1, JoinedDate = DateTime.Now },
                new Employee { Id = 7, Name = "Christopher Davis", DepartmentId = 4, JoinedDate = DateTime.Now },
                new Employee { Id = 8, Name = "Ashley Martinez", DepartmentId = 3, JoinedDate = DateTime.Now },
                new Employee { Id = 9, Name = "Matthew Taylor", DepartmentId = 2, JoinedDate = DateTime.Now },
                new Employee { Id = 10, Name = "Amanda Harris", DepartmentId = 4, JoinedDate = DateTime.Now }
            );

            // Seed ProjectEmployees with ProjectId and EmployeeId
            modelBuilder.Entity<ProjectEmployee>().HasData(
                new ProjectEmployee { EmployeeId = 1, ProjectId = 1, Enabled = true },
                new ProjectEmployee { EmployeeId = 2, ProjectId = 2, Enabled = true },
                new ProjectEmployee { EmployeeId = 3, ProjectId = 1, Enabled = true },
                new ProjectEmployee { EmployeeId = 4, ProjectId = 3, Enabled = true },
                new ProjectEmployee { EmployeeId = 5, ProjectId = 2, Enabled = true },
                new ProjectEmployee { EmployeeId = 6, ProjectId = 1, Enabled = true },
                new ProjectEmployee { EmployeeId = 7, ProjectId = 4, Enabled = true },
                new ProjectEmployee { EmployeeId = 8, ProjectId = 3, Enabled = true },
                new ProjectEmployee { EmployeeId = 9, ProjectId = 2, Enabled = true },
                new ProjectEmployee { EmployeeId = 10, ProjectId = 4, Enabled = true }


            );
            modelBuilder.Entity<Salary>().HasData(
    new Salary { Id = 1, EmployeeId = 1, Amount = 50000 },
    new Salary { Id = 2, EmployeeId = 2, Amount = 55000 },
    new Salary { Id = 3, EmployeeId = 3, Amount = 60000 },
    new Salary { Id = 4, EmployeeId = 4, Amount = 48000 },
    new Salary { Id = 5, EmployeeId = 5, Amount = 52000 },
    new Salary { Id = 6, EmployeeId = 6, Amount = 53000 },
    new Salary { Id = 7, EmployeeId = 7, Amount = 56000 },
    new Salary { Id = 8, EmployeeId = 8, Amount = 49000 },
    new Salary { Id = 9, EmployeeId = 9, Amount = 51000 },
    new Salary { Id = 10, EmployeeId = 10, Amount = 54000 });
        }
    }
}

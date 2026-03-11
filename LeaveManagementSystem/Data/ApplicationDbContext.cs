using Microsoft.EntityFrameworkCore;
using LeaveManagementSystem.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<LeaveRequest> LeaveRequests { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

      

        modelBuilder.Entity<User>().HasData(

            new User
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@example.com",
                Password = "admin123",
                Role = "Admin"
            },

            new User
            {
                Id = 2,
                Name = "Employee",
                Email = "employee@example.com",
                Password = "emp123",
                Role = "Employee"
            }

        );


    

        modelBuilder.Entity<Employee>().HasData(

            new Employee { Id = 1, Name = "Rahul Patil", Email = "rahul@test.com", Department = "IT", IsActive = true },

            new Employee { Id = 2, Name = "Sneha Sharma", Email = "sneha@test.com", Department = "HR", IsActive = true },

            new Employee { Id = 3, Name = "Amit Kulkarni", Email = "amit@test.com", Department = "Finance", IsActive = true },

            new Employee { Id = 4, Name = "Priya Deshmukh", Email = "priya@test.com", Department = "IT", IsActive = true },

            new Employee { Id = 5, Name = "Rohit Singh", Email = "rohit@test.com", Department = "Sales", IsActive = true },

            new Employee { Id = 6, Name = "Neha Joshi", Email = "neha@test.com", Department = "HR", IsActive = true },

            new Employee { Id = 7, Name = "Karan Mehta", Email = "karan@test.com", Department = "Marketing", IsActive = true },

            new Employee { Id = 8, Name = "Pooja Verma", Email = "pooja@test.com", Department = "Support", IsActive = true },

            new Employee { Id = 9, Name = "Aditya Patil", Email = "aditya@test.com", Department = "IT", IsActive = true },

            new Employee { Id = 10, Name = "Simran Kaur", Email = "simran@test.com", Department = "Finance", IsActive = true }

        );


      

        modelBuilder.Entity<LeaveRequest>().HasData(

            new LeaveRequest
            {
                Id = 1,
                EmployeeId = 1,
                FromDate = new DateTime(2026, 3, 10),
                ToDate = new DateTime(2026, 3, 12),
                Reason = "Personal Work",
                Status = "Approved"
            },

            new LeaveRequest
            {
                Id = 2,
                EmployeeId = 2,
                FromDate = new DateTime(2026, 3, 14),
                ToDate = new DateTime(2026, 3, 15),
                Reason = "Medical Leave",
                Status = "Pending"
            },

            new LeaveRequest
            {
                Id = 3,
                EmployeeId = 3,
                FromDate = new DateTime(2026, 3, 20),
                ToDate = new DateTime(2026, 3, 22),
                Reason = "Family Function",
                Status = "Approved"
            }

        );
    }
}
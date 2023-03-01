using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PracticeDB.Models;

namespace PracticeDB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<EmployeeRole> employeeRoles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<VisitLog> visitLogs { get; set; }
        public DbSet<Visitor> visitors { get; set; }
    }
}
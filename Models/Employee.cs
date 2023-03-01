using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeDB.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        [ForeignKey("EmployeeRoleId")]
        public int EmployeeRoleId { get; set; }
        public virtual EmployeeRole? Role { get; set; } = null;
    }
}

namespace PracticeDB.Models
{
    public class EmployeeRole
    {
        public int EmployeeRoleId { get; set; }
        public string EmployeeRoleName { get; set; }
        public int RoleRate { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}

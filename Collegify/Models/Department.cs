namespace Collegify.Models
{
    public class Department
    {
        public int Id { get; set; } // Primary Key
        public string DepartmentName { get; set; }
        public string ManagerName { get; set; }

        // Relationships
        public ICollection<Student> Students { get; set; }
        public ICollection<Professor> Professors { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}

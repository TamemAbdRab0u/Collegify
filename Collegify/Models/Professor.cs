namespace Collegify.Models
{
    public class Professor : IUser
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? HireDate { get; set; }

        // Foreign Key
        public int DepartmentID { get; set; }
        public Department Department { get; set; } 

        // Relationships
        public ICollection<Course> Courses { get; set; }

        public void GetUserDetails()
        {
            Console.WriteLine($"Professor Name: {Name}, ID: {Id}");
        }
    }
}


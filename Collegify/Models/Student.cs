namespace Collegify.Models
{
    public class Student : IUser
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? EnrollmentDate { get; set; }
        public string? Year { get; set; }

        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        // Relationships
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Fee> Fees { get; set; }

        public void GetUserDetails()
        {
            Console.WriteLine($"Student Name: {Name}, ID: {Id}");
        }
    }
}

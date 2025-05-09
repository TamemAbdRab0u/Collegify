namespace Collegify.Models
{
    public class Enrollment
    {
        public int Id { get; set; } // Primary Key (auto-incremented)

        // Foreign Keys
        public int StudentID { get; set; }
        public Student Student { get; set; } // Navigation property

        public int CourseID { get; set; }
        public Course Course { get; set; } // Navigation property

        public DateTime EnrollmentDate { get; set; }
        public string Semester { get; set; }

        // Relationships
        public ICollection<Grade> Grades { get; set; }
    }
}

namespace Collegify.Models
{
        public class Course
        {
            public int Id { get; set; } // Primary Key
            public string CourseName { get; set; }
            public string Credits { get; set; }

            // Foreign Keys
            public int DepartmentID { get; set; }
            public Department Department { get; set; } // Navigation property

            public int ProfessorID { get; set; }
            public Professor Professor { get; set; } // Navigation property

        // Relationships
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}

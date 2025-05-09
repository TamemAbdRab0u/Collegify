namespace Collegify.Models
{
    public class Grade
    {
        public int Id { get; set; } // Primary Key (auto-incremented)
        public string GradeValue { get; set; }
        public string? ExamDate { get; set; }

        // Foreign Key
        public int EnrollmentID { get; set; }
        public Enrollment Enrollment { get; set; } // Navigation property


    }
}

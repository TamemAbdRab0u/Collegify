namespace Collegify.Models
{
    public class Grade
    {
        public int Id { get; set; } // Primary Key (auto-incremented)
        public string StudentName { get; set; }
        public string Year { get; set; }
        public string GradeValue { get; set; }
        public string Degree {  get; set; }
        public string? ExamDate { get; set; }

        // Foreign Key
        public int? EnrollmentID { get; set; }
        public Enrollment? Enrollment { get; set; } // Navigation property


    }
}

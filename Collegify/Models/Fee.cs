namespace Collegify.Models
{
    public class Fee
    {
        public int Id { get; set; } // Primary Key (auto-incremented)

        // Foreign Key
        public int StudentID { get; set; }
        public Student Student { get; set; } // Navigation property

        public decimal Amount { get; set; }
        public string? PaymentDate { get; set; }
        public string Status { get; set; } // e.g., "Paid", "Pending"
    }
}

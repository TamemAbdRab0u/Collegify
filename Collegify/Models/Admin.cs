namespace Collegify.Models
{
    public class Admin : IUser
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public void GetUserDetails()
        {
            Console.WriteLine($"Admin Name: {Name}, ID: {Id}");
        }
    }
}

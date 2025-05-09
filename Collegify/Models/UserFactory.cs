using Collegify.Models;

public class UserFactory
{
    public IUser CreateUser(string role)
    {
        switch (role.ToLower())
        {
            case "student":
                return new Student();
            case "professor":
                return new Professor();
            case "admin":
                return new Admin();
            default:
                throw new ArgumentException("Invalid role");
        }
    }
}


using System.Collections.Generic;
using System.Linq;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}

public class AuthService
{
    private static List<User> _users = new List<User>
    {
        new User { Username = "admin", Password = "admin123", Role = "HR" },
        new User { Username = "program-coordinator", Password = "pc123", Role = "Program Coordinator" },
        new User { Username = "academic-manager", Password = "am123", Role = "Academic Manager" }
    };

    public static User Authenticate(string username, string password)
    {
        return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }

    public static bool IsAuthorized(User user, string requiredRole)
    {
        return user?.Role == requiredRole;
    }
}

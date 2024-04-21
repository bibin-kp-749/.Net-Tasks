using System.Security.Claims;

namespace JWT_Based_Authentication.Model
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}

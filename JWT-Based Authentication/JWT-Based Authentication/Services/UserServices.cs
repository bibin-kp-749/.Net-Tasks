using JWT_Based_Authentication.Model;

namespace JWT_Based_Authentication.Services
{
    public class UserServices:IUserServices
    {
        public static List<User> users = new List<User>
        {
            new User{UserId=1,UserName="Bibin",Password="12345",Role=Role.Admin},
            new User{UserId=2,UserName="Vipin",Password="12345",Role=Role.User},
        };
        public IEnumerable<User>Register(User user)
        {
            users.Add(new User { UserId = users.Count + 1, UserName = user.UserName, Password = user.Password, Role = user.Role });
            return users;
        }
        public IEnumerable<User> GetUser()
        {
            return users;
        }
    }
}

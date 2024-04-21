using JWT_Based_Authentication.Model;

namespace JWT_Based_Authentication.Services
{
    public interface IUserServices
    {
        public IEnumerable<User> Register(User user);
        public IEnumerable<User> GetUser();
    }
}

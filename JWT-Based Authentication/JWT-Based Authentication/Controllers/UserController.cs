using JWT_Based_Authentication.Model;
using JWT_Based_Authentication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_Based_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            this._userServices = userServices;
        }
        [HttpPost("Register")]
        public IEnumerable<User> Register(User user)
        {
            return _userServices.Register(user);
        }
    }
}

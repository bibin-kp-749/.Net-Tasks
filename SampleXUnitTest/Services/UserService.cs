using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleXUnitTest.Services
{
    public class UserService
    {
        public bool CreateUser(string username, string password)
        {
            if (username.Length > 5 && password.Length > 5)
            {
               if(!string.IsNullOrWhiteSpace(AddUserToDb(username, password)))
                {
                    return true;
                }
            }
            return false;
        }
        public virtual string AddUserToDb(string username,string password)
        {
            return "Added";
        }
        public bool LoginUser(string username, string password)
        {
            if (LoginUser(username,password))
            {
                return true;
            }
            return false;
        }
        public virtual bool LoginUserDb(string username, string password)
        {
            return true;
        }
    }
}

namespace Sample_Authentication_UsingJWT.Model
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public User(string UserName, string Password)
        {
            this.UserName=UserName;
            this.Password = Password;
        }
    }
}

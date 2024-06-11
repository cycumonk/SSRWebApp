namespace SSRWebApp.Models
{
    public class UserModel
    {
        public string Account { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"Account: {Account}\nEmail: {Email}\nPassword: {Password}";
        }
    }
}

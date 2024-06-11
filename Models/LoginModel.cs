namespace SSRWebApp.Models
{
    public class LoginModel
    {
        public string Account { get; set; }

        public string Password { get; set; }

        public override string ToString()
        {
            return $"Account: {Account}\n";
        }
    }
}

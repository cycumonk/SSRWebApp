using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SSRWebApp.Pages
{
    public class SuccessModel : PageModel
    {
        public string Account { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void OnGet(string account, string email, string password)
        {
            Account = account;
            Email = email;
            Password = password;
        }
    }
}

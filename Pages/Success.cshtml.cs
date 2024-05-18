using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SSRWebApp.Pages
{
    public class SuccessModel : PageModel
    {
        [BindProperty]
        public string? Account { get; set; }
        [BindProperty]
        public string? Email { get; set; }
        [BindProperty]
        public string? Password { get; set; }

        public void OnPost(string account, string email, string password)
        {
            Account = account;
            Email = email;
            Password = password;
        }
    }
}

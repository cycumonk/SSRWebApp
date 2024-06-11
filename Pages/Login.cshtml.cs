using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SSRWebApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Account { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            // 處理登錄邏輯
            return Page();
        }
    }
}

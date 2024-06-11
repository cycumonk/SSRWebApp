using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SSRWebApp.Models;

namespace SSRWebApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public UserModel User { get; set; }

        public void OnGet()
        {
        }
    }

}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string? Account { get; set; }

    [BindProperty]
    public string? Email { get; set; }

    [BindProperty]
    public string? Password { get; set; }

    public void OnGet()
    {
        // 在此處初始化屬性等操作
    }

    public IActionResult OnPost()
    {
        // 在此處處理表單提交
        return RedirectToPage("/Success", new { account = Account, email = Email, password = Password });
    }
}

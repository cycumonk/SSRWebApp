using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SSRWebApp.Models;

namespace SSRWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private string storedPassword;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] UserModel data)
        {
            if (data == null || string.IsNullOrEmpty(data.Account))
            {
                return BadRequest("Account is required");
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{data.Account.ToLower()}.txt");
            var files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.txt");

            foreach (var file in files)
            {
                string existingData = await System.IO.File.ReadAllTextAsync(file);
                if (existingData.Contains(data.Email))
                {
                    TempData["ErrorMessage"] = "This email is already registered.";
                    return RedirectToPage("/Index");
                }
            }

            await System.IO.File.WriteAllTextAsync(filePath, data.ToString());
            return RedirectToPage("/Success", new { account = data.Account, email = data.Email, password = data.Password });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginModel data)
        {
            if (data == null || string.IsNullOrEmpty(data.Account) || string.IsNullOrEmpty(data.Password))
            {
                return BadRequest("Account and Password are required");
            }

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{data.Account.ToLower()}.txt");

            if (System.IO.File.Exists(filePath))
            {
                string[] lines = await System.IO.File.ReadAllLinesAsync(filePath);
                string storedPassword = lines.Length > 2 ? lines[2].Split(": ")[1] : string.Empty;

                if (storedPassword == data.Password)
                {
                    return RedirectToPage("/LoginSuccess", new { account = data.Account });
                }
            }

            if (storedPassword == data.Password)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, data.Account)
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties
                    {
                        IsPersistent = true
                    });
                return RedirectToPage("/Index");
            }

            TempData["ErrorMessage"] = "帳號或密碼錯誤";
            return RedirectToPage("/Login");
        }
    }
}

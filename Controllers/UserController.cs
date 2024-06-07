using Microsoft.AspNetCore.Mvc;


namespace SSRWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserModel data)
        {
            if (data == null || string.IsNullOrEmpty(data.Account))
            {
                return BadRequest("Name is required");
            }

            // 創造文件路徑
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), $"{data.Account.ToLower()}.txt");

            // 寫入文件
            await System.IO.File.WriteAllTextAsync(filePath, data.ToString());

            return Ok($"File {data.Account.ToLower()}.txt created successfully");
        }
    }

    public class UserModel
    {
        public string Account { get; set; }
    }
}

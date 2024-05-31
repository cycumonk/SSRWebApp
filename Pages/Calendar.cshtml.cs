using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


public class CalendarModel : PageModel
{
    public string? JsonData { get; set; }

    public void OnGet()
    {
        var person = new
        {
            name = "Mary",
            age = 20
        };
        JsonData = JsonConvert.SerializeObject(person, Formatting.Indented);
    }
}

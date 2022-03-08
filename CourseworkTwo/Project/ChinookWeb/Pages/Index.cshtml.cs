using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinookWeb.Pages
{
    public class Index : PageModel
    {
        public IActionResult OnGet()
        {
            return RedirectToPage("./Albums/List");
        }
    }
}
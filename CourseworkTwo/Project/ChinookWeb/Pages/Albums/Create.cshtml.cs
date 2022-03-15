using ChinookEntities;
using ChinookEntities.BindingModels;
using ChinookService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinookWeb.Pages.Albums
{
    public class Create : PageModel
    {
        [BindProperty] public AlbumBindingModel NewAlbum { get; set; }

        public void OnGet()
        {
            ViewData["PageTitle"] = "New Album";
         
        } 

        public IActionResult OnPost()
        {
            return null;
        }
    }
}
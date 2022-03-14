using System.Collections;
using System.Collections.Generic;
using ChinookEntities;
using ChinookService.ArtistService;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinookWeb.Pages.Artists
{
    public class List : PageModel
    {
        private IArtistService _artistService;
        public IEnumerable<Artist> Artists { get; set; }

        public List(IArtistService artistService)
        {
            _artistService = artistService;
        }

        public void OnGet()
        {
            ViewData["PageTitle"] = "Artists";
            Artists = _artistService.GetArtists();
        }
    }
}
using System.Collections.Generic;
using ChinookEntities;
using ChinookEntities.BindingModels;
using ChinookService;
using ChinookService.AlbumService;
using ChinookService.ArtistService;
using ChinookService.TrackService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinookWeb.Pages.Albums
{
    public class CreateAlbumViewModel : PageModel
    {
        private readonly IAlbumService _albumService;
        private readonly ITrackService _trackService;
        private readonly IArtistService _artistService;

        [BindProperty]
        public AlbumBindingModel NewAlbum { get; set; }

        public IList<TrackBindingModel> Tracks { get; set; }

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
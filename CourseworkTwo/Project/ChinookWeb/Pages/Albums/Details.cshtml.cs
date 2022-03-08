using System.Linq;
using ChinookContext;
using ChinookEntities;
using ChinookService.AlbumService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinookWeb.Pages.Albums
{
    public class Details : PageModel
    {
        private IAlbumService _albumService;

        public Details(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [BindProperty(SupportsGet = true)]
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        
        public void OnGet()
        {
            Album = _albumService.GetAlbum(AlbumId);
        }
    }
}
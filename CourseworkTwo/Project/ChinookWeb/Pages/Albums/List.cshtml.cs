using System.Collections.Generic;
using ChinookEntities;
using ChinookService.AlbumService;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ChinookWeb.Pages.Albums
{
    public class AlbumsListViewModel : PageModel
    {
        private IAlbumService _albumService;
        public IList<Album> Albums { get; set; }
        private readonly ILogger<AlbumsListViewModel> _logger;

        public AlbumsListViewModel(IAlbumService albumService, ILogger<AlbumsListViewModel> logger)
        {
            _albumService = albumService;
            _logger = logger;
        }

        public void OnGet()
        {
            Albums = _albumService.GetAlbums();
        }
    }
}
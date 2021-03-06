using System;
using System.Collections.Generic;
using System.Linq;
using ChinookEntities;
using ChinookService.AlbumService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ChinookWeb.Pages.Albums
{
    public class AlbumsListViewModel : PageModel
    {
        private IAlbumService _albumService;
        public IList<Album> Albums { get; set; }
        private readonly ILogger<AlbumsListViewModel> _logger;

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }

        public int Count { get; set; }
        public int PageSize { get; set; } = 10;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public bool ShowFirst => CurrentPage != 1;
        public bool ShowLast => CurrentPage != TotalPages;

        public AlbumsListViewModel(IAlbumService albumService, ILogger<AlbumsListViewModel> logger)
        {
            _albumService = albumService;
            _logger = logger;
        }

        public void OnGet()
        {
            Albums = _albumService.GetPaginatedAlbums(CurrentPage, PageSize, SortBy);
            Count = _albumService.GetCount();
        }

        public void OnPostAlbumSearch(string searchString)
        {
            Albums = _albumService.GetAlbums();
            if (!string.IsNullOrEmpty(searchString))
            {
                Albums = _albumService.SearchAlbums(searchString);
            }
        }

        public IActionResult OnPostDeleteAlbum(int albumId)
        {
            _albumService.DeleteAlbum(albumId);
            return RedirectToPage();
        }
    }
}
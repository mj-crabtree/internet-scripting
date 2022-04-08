using System;
using System.Collections.Generic;
using System.Linq;
using ChinookEntities;
using ChinookService.AlbumService;
using ChinookService.ArtistService;
using ChinookService.TrackService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinookWeb.Pages.Artists
{
    public class ArtistsListViewModel : PageModel
    {
        private readonly IArtistService _artistService;
        private readonly IAlbumService _albumService;
        private readonly ITrackService _trackService;
        public IList<Artist> Artists { get; set; }

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

        public ArtistsListViewModel(IArtistService artistService, IAlbumService albumService, ITrackService trackService)
        {
            _artistService = artistService;
            _albumService = albumService;
            _trackService = trackService;
        }

        public void OnGet()
        {
            Artists = _artistService.GetPaginatedArtists(CurrentPage, PageSize, SortBy);
            Count = _artistService.GetCount();
        }

        public void OnPostArtistSearch(string searchString)
        {
            Artists = _artistService.GetArtists();
            if (!String.IsNullOrEmpty(searchString))
            {
                Artists = _artistService.SearchArtists(searchString);
            }
        }

        public IActionResult OnPostDeleteArtist(int artistId)
        {
            _albumService.DeleteAlbums(artistId);
            _artistService.DeleteArtist(artistId);
            return RedirectToPage();
        }
        
        public IActionResult OnPostEditArtistName(int artistId, string newName)
        {
            _artistService.EditExistingArtistName(artistId, newName);
            return RedirectToPage();
        }

        public IActionResult OnPostMakeNewArtist(string newArtistName)
        {
            _artistService.CreateNewArtist(newArtistName);
            return RedirectToPage();
        }
    }
}
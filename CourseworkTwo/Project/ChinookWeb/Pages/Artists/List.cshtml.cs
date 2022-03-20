using System;
using System.Collections;
using System.Collections.Generic;
using ChinookEntities;
using ChinookService.ArtistService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinookWeb.Pages.Artists
{
    public class List : PageModel
    {
        private IArtistService _artistService;
        public IEnumerable<Artist> Artists { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }

        public int Count { get; set; }
        public int PageSize { get; set; } = 10;

        public int TotalPages => (int) Math.Ceiling(decimal.Divide(Count, PageSize));
        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public bool ShowFirst => CurrentPage != 1;
        public bool ShowLast => CurrentPage != TotalPages;
        
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
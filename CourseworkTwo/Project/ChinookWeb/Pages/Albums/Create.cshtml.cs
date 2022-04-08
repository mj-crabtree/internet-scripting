using System;
using System.Collections.Generic;
using ChinookEntities;
using ChinookEntities.BindingModels;
using ChinookService.AlbumService;
using ChinookService.ArtistService;
using ChinookService.TrackService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace ChinookWeb.Pages.Albums
{
    public class CreateAlbumViewModel : PageModel
    {
        private IArtistService _artistService;
        private ITrackService _trackService;
        private IAlbumService _albumService;
        public IList<Artist> Artists { get; set; }
        
        [BindProperty]
        public AlbumBindingModel NewAlbum { get; set; }

        public CreateAlbumViewModel(IArtistService artistService, ITrackService trackService, IAlbumService albumService)
        {
            _artistService = artistService;
            _trackService = trackService;
            _albumService = albumService;
            Artists = _artistService.GetArtists();
        }

        public void OnGet()
        {
            ViewData["PageTitle"] = "New Album";
        }
        
        public IActionResult OnPostMakeNewAlbum(string[] trackList)
        {
            // non-functional: tried working on a solution for a while but couldn't quite get there.
            // see Track and Album Service implementations for some insight into my approach
            
            // var list = _trackService.AddNewAlbumFromTrackArrayStrings(trackList);
            // NewAlbum.TrackList = list;
            // _albumService.BuildNewAlbum(NewAlbum);
            return RedirectToPage();
        }
    }
}
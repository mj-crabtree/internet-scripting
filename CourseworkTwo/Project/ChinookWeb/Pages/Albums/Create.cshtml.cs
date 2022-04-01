using System;
using System.Collections.Generic;
using ChinookEntities;
using ChinookEntities.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ChinookWeb.Pages.Albums
{
    public class CreateAlbumViewModel : PageModel
    {
        public static List<TrackBindingModel> tracks = new List<TrackBindingModel> { new TrackBindingModel { } };
        public static Playlist Playlist = new Playlist {Tracks = tracks};
        
        public void OnGet()
        {
            ViewData["PageTitle"] = "New Album";
            ViewData["Playlist"] = Playlist.Tracks;
        }


        [BindProperty]
        public AlbumBindingModel NewAlbum { get; set; }
        public IActionResult OnPost()
        {
            var x = NewAlbum;
            Console.WriteLine();
            return RedirectToPage();
        }
        
        public IActionResult Add(List<TrackBindingModel> newTrackList)
        {
            ViewData["Playlist"] = Playlist.Tracks;
            tracks = newTrackList;
            tracks.Add( new TrackBindingModel { });
            Playlist.Tracks = tracks;
            return RedirectToPage();
        }
    }

    public class Playlist
    {
        public List<TrackBindingModel> Tracks { get; set; }

        public Playlist()
        {
            Tracks = new List<TrackBindingModel>();
        }
    }
}
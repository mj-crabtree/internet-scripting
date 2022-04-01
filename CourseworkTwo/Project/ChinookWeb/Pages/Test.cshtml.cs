using System;
using System.Collections.Generic;
using ChinookEntities;
using ChinookEntities.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinookWeb.Pages
{
    public class Test : PageModel
    {
        public List<TrackBindingModel> Tracks { get; set; }

        public void OnGet()
        {
            Tracks = new List<TrackBindingModel>();
            ViewData["PageTitle"] = "New Album";
            Tracks.Add( new TrackBindingModel() );
        }
        
        public IActionResult OnPostAddField(TrackBindingModel newTrack)
        {
            Tracks.Add(newTrack);
            return RedirectToPage();
        }
    }
}
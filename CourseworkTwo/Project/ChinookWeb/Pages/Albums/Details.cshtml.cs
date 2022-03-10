using System;
using System.Collections.Generic;
using System.Linq;
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
    public String AlbumGenre { get; set; }
    
    public void OnGet()
    {
        Album = _albumService.GetAlbum(AlbumId);
        AlbumGenre = _albumService.GetAlbumGenre(AlbumId);
    }
}
}
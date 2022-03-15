using System;
using System.Collections.Generic;
using ChinookEntities;
using ChinookEntities.BindingModels;
using ChinookService.AlbumService;
using ChinookService.ArtistService;
using ChinookService.GenreService;
using ChinookService.MediaTypeService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChinookWeb.Pages.Albums
{
    public class Details : PageModel
    {
        private readonly IAlbumService _albumService;
        private readonly IGenreService _genreService;
        private readonly IArtistService _artistService;
        private readonly IMediaTypeService _mediaTypeService;

        public Details(IAlbumService albumService, IGenreService genreService, IArtistService artistService,
            IMediaTypeService mediaTypeService)
        {
            _albumService = albumService;
            _genreService = genreService;
            _artistService = artistService;
            _mediaTypeService = mediaTypeService;
        }

        [BindProperty(SupportsGet = true)] public int AlbumId { get; set; }
        public Album Album { get; set; }
        public String AlbumGenre { get; set; }
        public IList<Genre> Genres { get; set; }
        public IList<Artist> Artists { get; set; }
        public IList<MediaType> MediaTypes { get; set; }

        public void OnGet()
        {
            // todo: convert all this into a single container?
            
            Album = _albumService.GetAlbum(AlbumId);
            AlbumGenre = _albumService.GetAlbumGenre(AlbumId);
            Genres = _genreService.GetGenres();
            Artists = _artistService.GetArtists();
            MediaTypes = _mediaTypeService.GetMediaTypes();
        }
        
        public void OnPost(TrackBindingModel Track)
        {
            
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChinookContext;
using ChinookEntities.CompositeModel;
using ChinookService.AlbumService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace ChinookWeb.Pages
{
    public class IndexModel : PageModel
    {
        private IAlbumService _albumService;
        public IEnumerable<CompositeAlbum> Albums { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IAlbumService albumService, ILogger<IndexModel> logger)
        {
            _albumService = albumService;
            _logger = logger;
        }

        public void OnGet()
        {
            Albums = _albumService.GetCompositeAlbums();
        }
    }
}
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Pages
{
    public class AlbumsModel : PageModel
    {
        public string Heading { get; set; }
        public IList<QueryResult> QueryResult { get; set; }

        public void OnGet()
        {
            var db = new Music();

            QueryResult = db.Albums.Join(
                db.Artists,
                album => album.AlbumId,
                artist => artist.ArtistId,
                (album, artist) => new QueryResult()
                {
                    AlbumId = album.AlbumId,
                    ArtistName = artist.ArtistName,
                    AlbumTitle = album.AlbumTitle
                }).ToList();

            Heading = "Albums";
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using ChinookContext;
using ChinookEntities.CompositeModel;

namespace ChinookService.AlbumService
{
    public static class AlbumBuilder
    {
        public static IEnumerable<CompositeAlbum> GetCompositeAlbums(ApplicationContext context)
        {
            List<CompositeAlbum> albums;

            using (context)
            {
                albums = context.Albums.Join(
                    inner: context.Artists,
                    outerKeySelector: album => album.ArtistId,
                    innerKeySelector: artist => artist.ArtistId,
                    resultSelector: (album, artist) => new CompositeAlbum(
                        album.Title, artist.Name)).ToList();
            }

            return albums;
        }
    }
}
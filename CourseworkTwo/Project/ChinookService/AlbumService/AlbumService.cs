using System.Collections.Generic;
using System.Linq;
using ChinookContext;
using ChinookEntities.CompositeModel;

namespace ChinookService.AlbumService
{
    public class AlbumService : IAlbumService
    {
        private readonly ApplicationContext _applicationContext;

        public AlbumService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<CompositeAlbum> GetCompositeAlbums()
        {
            using (_applicationContext)
            {
                return _applicationContext.Albums.Join(
                    inner: _applicationContext.Artists,
                    outerKeySelector: album => album.ArtistId,
                    innerKeySelector: artist => artist.ArtistId,
                    resultSelector: (album, artist) => new CompositeAlbum(
                        album.Title, artist.Name)).ToList();
            }
        }
    }
}
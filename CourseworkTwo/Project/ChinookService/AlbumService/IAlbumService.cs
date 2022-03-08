using System.Collections.Generic;
using System.Linq;
using ChinookContext;
using ChinookEntities;

namespace ChinookService.AlbumService
{
    public interface IAlbumService
    {
        public IList<Album> GetAlbums();
        public Album GetAlbum(int id);
    }
}
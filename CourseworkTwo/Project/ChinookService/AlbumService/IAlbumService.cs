using System.Collections.Generic;
using ChinookContext;
using ChinookEntities.CompositeModel;

namespace ChinookService.AlbumService
{
    public interface IAlbumService
    {
        public abstract IEnumerable<CompositeAlbum> GetCompositeAlbums();
    }
}
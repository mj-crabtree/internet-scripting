using System.Collections.Generic;
using ChinookEntities;
using ChinookEntities.BindingModels;

namespace ChinookService.AlbumService
{
    public interface IAlbumService
    {
        public IList<Album> GetAlbums();
        // public IList<Album> GetPaginatedAlbums(int currentPage, int pageSize = 10);
        public IList<Album> GetPaginatedAlbums(int currentPage, int pageSize, string sortBy);
        public int GetCount();
        public Album GetAlbum(int id);
        public string GetAlbumGenre(int id);
        public void Save(AlbumBindingModel albumBindingModel);
        public void EditAlbum(AlbumBindingModel newAlbumData, int albumId);
        public Album BuildNewAlbum(AlbumBindingModel albumBindingModel);
        void DeleteAlbum(int albumId);
    }
}
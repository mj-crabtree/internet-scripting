using System;
using System.Collections.Generic;
using System.Linq;
using ChinookContext;
using ChinookEntities;
using ChinookEntities.BindingModels;
using ChinookService.ArtistService;

namespace ChinookService.AlbumService
{
    public interface IAlbumService
    {
        public IList<Album> GetAlbums();
        public Album GetAlbum(int id);
        public string GetAlbumGenre(int id);
        public void Save(AlbumBindingModel albumBindingModel);
        public void EditAlbum(AlbumBindingModel newAlbumData, int albumId);
        public Album BuildNewAlbum(AlbumBindingModel albumBindingModel);
        void DeleteAlbum(int albumId);
    }
}
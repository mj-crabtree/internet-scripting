using System;
using System.Collections.Generic;
using System.Linq;
using ChinookContext;
using ChinookEntities;
using ChinookEntities.BindingModels;
using ChinookService.ArtistService;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ChinookService.AlbumService
{
    public class AlbumService : IAlbumService
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IArtistService _artistService;

        public AlbumService(ApplicationContext applicationContext, IArtistService artistService)
        {
            _applicationContext = applicationContext;
            _artistService = artistService;
        }

        public IList<Album> GetAlbums()
        {
            return _applicationContext.Albums
                .Include(a => a.Artist)
                .Include(a => a.Tracks)
                .ToList();
        }

        public IList<Album> GetPaginatedAlbums(int currentPage, int pageSize = 10)
        {
            var albums = GetAlbums();
            return albums.OrderBy(a => a.AlbumId)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int GetCount()
        {
            var data = GetAlbums();
            return GetAlbums().Count;
        }

        public Album GetAlbum(int id)
        {
            return _applicationContext.Albums
                .Include(a => a.Tracks)
                .Include(a => a.Artist)
                .First(a => a.AlbumId == id);
        }

        public string GetAlbumGenre(int id)
        {
            try
            {
                var genreId = GetAlbum(id).Tracks.First().GenreId;
                return _applicationContext.Genres.First(f => f.GenreId == genreId).Name;
            }
            catch (Exception e)
            {
                return "N/A";
            }
        }

        public void Save(AlbumBindingModel albumBindingModel)
        {
            _applicationContext.Albums.Add(BuildNewAlbum(albumBindingModel));
            _applicationContext.SaveChanges();
        }

        public void EditAlbum(AlbumBindingModel newAlbumData, int albumId)
        {
            var pulled = GetAlbum(albumId);
            pulled.ArtistId = newAlbumData.ArtistId;
            pulled.Title = newAlbumData.Title;
            _applicationContext.SaveChanges();
        }

        public Album BuildNewAlbum(AlbumBindingModel albumBindingModel)
        {
            var newAlbum = ChinookEntityFactory.Album();
            newAlbum.Artist = _artistService.GetArtist(albumBindingModel.ArtistId);
            newAlbum.Title = albumBindingModel.Title;
            newAlbum.Tracks = albumBindingModel.Tracks;
            return newAlbum;
        }

        public void DeleteAlbum(int albumId)
        {
            var album = GetAlbum(albumId);
            _applicationContext.Albums.Remove(album);
            _applicationContext.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using ChinookContext;
using ChinookEntities;
using ChinookEntities.BindingModels;
using ChinookService.ArtistService;
using ChinookService.TrackService;
using Microsoft.EntityFrameworkCore;

namespace ChinookService.AlbumService
{
    public class AlbumService : IAlbumService
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IArtistService _artistService;
        private readonly ITrackService _trackService;

        public AlbumService(ApplicationContext applicationContext, IArtistService artistService, ITrackService trackService)
        {
            _applicationContext = applicationContext;
            _artistService = artistService;
            _trackService = trackService;
        }

        public IList<Album> GetAlbums()
        {
            return _applicationContext.Albums
                .Include(a => a.Artist)
                .Include(a => a.Tracks)
                .ToList();
        }

        public IList<Album> GetPaginatedAlbums(int currentPage, int pageSize, string sortBy)
        {
            var albums = GetAlbums();
            return albums.AsQueryable()
                .OrderBy(sortBy)
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
            catch (Exception)
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
            newAlbum.Title = albumBindingModel.Title;
            newAlbum.Artist = _artistService.GetArtist(albumBindingModel.ArtistId);
            newAlbum.Tracks = _trackService.BuildNewTrackList(albumBindingModel.TrackList);
            return newAlbum;
        }

        public void DeleteAlbum(int albumId)
        {
            var album = GetAlbum(albumId);
            _applicationContext.Albums.Remove(album);
            _applicationContext.SaveChanges();
        }

        public void DeleteAlbums(int artistId)
        {
            var albums = GetAlbumsByArtistId(artistId);
            foreach (var album in albums)
            {
                DeleteAlbum((int)album.AlbumId);
            }
        }

        public IList<Album> SearchAlbums(string searchString)
        {
            return _applicationContext.Albums.Where(a => a.Title.ToLower()
                .Contains(searchString.ToLower()))
                .ToList();
        }

        private IQueryable<Album> GetAlbumsByArtistId(int artistId)
        {
            return _applicationContext.Albums.Where(a => a.ArtistId.Equals(artistId));
        }
    }
}
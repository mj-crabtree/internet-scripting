using System;
using System.Collections.Generic;
using System.Linq;
using ChinookContext;
using ChinookEntities;
using Microsoft.EntityFrameworkCore;

namespace ChinookService.AlbumService
{
    public class AlbumService : IAlbumService
    {
        private readonly ApplicationContext _applicationContext;

        public AlbumService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IList<Album> GetAlbums()
        {
            return _applicationContext.Albums
                .Include(a => a.Artist)
                .Include(a => a.Tracks)
                .ToList();
        }

        public Album GetAlbum(int id)
        {
            return _applicationContext.Albums
                .Include(a => a.Tracks)
                .Include(a => a.Artist)
                .First(a => a.AlbumId == id);
        }
    }
}
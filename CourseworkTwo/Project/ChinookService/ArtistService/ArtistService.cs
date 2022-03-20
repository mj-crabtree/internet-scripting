using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using ChinookContext;
using ChinookEntities;
using ChinookService.AlbumService;

namespace ChinookService.ArtistService
{
    public class ArtistService : IArtistService
    {
        private readonly ApplicationContext _applicationContext;

        public ArtistService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            // _albumService = albumService;
        }

        public IList<Artist> GetArtists()
        {
            return _applicationContext.Artists
                .OrderBy(a => a.ArtistId)
                .ToList();
        }

        public Artist GetArtist(long artistId)
        {
            return _applicationContext.Artists.First(a => a.ArtistId == artistId);
        }

        public IList<Artist> GetPaginatedArtists(int currentPage, int pageSize, string sortBy)
        {
            var artists = GetArtists();
            return artists.AsQueryable()
                .OrderBy(sortBy)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int GetCount()
        {
            var artists = GetArtists();
            return artists.Count;
        }

        public void DeleteArtist(int artistId)
        {
            var artist = GetArtist(artistId);
            _applicationContext.Artists.Remove(artist);
            _applicationContext.SaveChanges();
        }
    }
}
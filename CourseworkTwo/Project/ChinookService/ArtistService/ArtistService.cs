using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using ChinookContext;
using ChinookEntities;

namespace ChinookService.ArtistService
{
    public class ArtistService : IArtistService
    {
        private readonly ApplicationContext _applicationContext;

        public ArtistService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
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

        public IList<Artist> SearchArtists(string searchString)
        {
            return _applicationContext.Artists.Where(a => a.Name.ToLower()
                    .Contains(searchString.ToLower()))
                .ToList();
        }

        public void EditExistingArtistName(int artistId, string newName)
        {
            var pulledArtist = GetArtist(artistId);
            pulledArtist.Name = newName;
            _applicationContext.SaveChanges();
        }

        public void CreateNewArtist(string artistName)
        {
            throw new System.NotImplementedException();
        }
    }
}
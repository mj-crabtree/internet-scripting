using System.Collections.Generic;
using System.Linq;
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
    }
}
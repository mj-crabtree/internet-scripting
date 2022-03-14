using System.Collections.Generic;
using ChinookEntities;

namespace ChinookService.ArtistService
{
    public interface IArtistService
    {
        public IList<Artist> GetArtists();
        public Artist GetArtist(long artistId);
    }
}
using System.Collections.Generic;
using ChinookEntities;

namespace ChinookService.ArtistService
{
    public interface IArtistService
    {
        public IList<Artist> GetArtists();
        public Artist GetArtist(long artistId);
        public IList<Artist> GetPaginatedArtists(int currentPage, int pageSize, string sortBy);
        public int GetCount();
        void DeleteArtist(int artistId);
        IList<Artist> SearchArtists(string searchString);
        void EditExistingArtistName(int artistId, string newName);
        void CreateNewArtist(string artistName);

    }
}
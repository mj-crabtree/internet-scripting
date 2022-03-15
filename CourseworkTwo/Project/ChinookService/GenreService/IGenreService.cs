using System.Collections.Generic;
using ChinookEntities;

namespace ChinookService.GenreService
{
    public interface IGenreService
    {
        public IList<Genre> GetGenres();
        public Genre GetGenre(int genreId);
    }
}
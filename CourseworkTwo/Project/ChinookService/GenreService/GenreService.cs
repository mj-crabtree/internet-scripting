using System.Collections.Generic;
using System.Linq;
using ChinookContext;
using ChinookEntities;

namespace ChinookService.GenreService
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationContext _applicationContext;

        public GenreService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IList<Genre> GetGenres()
        {
            return _applicationContext.Genres.ToList();
        }

        public Genre GetGenre(int genreId)
        {
            throw new System.NotImplementedException();
        }
    }
}
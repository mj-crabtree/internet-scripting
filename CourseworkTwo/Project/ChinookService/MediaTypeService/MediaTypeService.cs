using System.Collections.Generic;
using System.Linq;
using ChinookContext;
using ChinookEntities;

namespace ChinookService.MediaTypeService
{
    public class MediaTypeService : IMediaTypeService
    {
        private readonly ApplicationContext _applicationContext;

        public MediaTypeService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IList<MediaType> GetMediaTypes()
        {
            return _applicationContext.MediaTypes.ToList();
        }

        public MediaType GetMediaType(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
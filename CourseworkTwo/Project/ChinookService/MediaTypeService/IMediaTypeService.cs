using System.Collections.Generic;
using ChinookEntities;

namespace ChinookService.MediaTypeService
{
    public interface IMediaTypeService
    {
        public IList<MediaType> GetMediaTypes();
        public MediaType GetMediaType(int id);
    }
}
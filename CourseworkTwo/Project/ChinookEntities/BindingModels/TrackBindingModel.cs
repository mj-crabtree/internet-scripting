using System;

namespace ChinookEntities.BindingModels
{
    public class TrackBindingModel
    {
        public String TrackName { get; set; }
        public String TrackComposer { get; set; }
        public decimal Price { get; set; }
        public int GenreId { get; set; }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int LengthMinutes { get; set; }
        public int LengthSeconds { get; set; }
        public int SizeInMegabytes { get; set; }

        public TrackBindingModel()
        {
        }
    }
}
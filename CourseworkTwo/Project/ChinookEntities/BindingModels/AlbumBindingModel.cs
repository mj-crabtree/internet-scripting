using System;
using System.Collections.Generic;

namespace ChinookEntities.BindingModels
{
    public class AlbumBindingModel
    {
        public String Title { get; set; }
        public long ArtistId { get; set; }
        public ICollection<Track> Tracks { get; set; }

        public AlbumBindingModel()
        {
        }

        public AlbumBindingModel(string title, long artistId, ICollection<Track> tracks)
        {
            Title = title;
            ArtistId = artistId;
            Tracks = tracks;
        }
    }
}
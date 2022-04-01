using System;
using System.Collections.Generic;

namespace ChinookEntities.BindingModels
{
    public class AlbumBindingModel
    {
        public String Title { get; set; }
        public long ArtistId { get; set; }
        public TrackBindingModel[] TrackList { get; set; }

        public AlbumBindingModel()
        {
        }

        public AlbumBindingModel(string title, long artistId, TrackBindingModel[] trackList)
        {
            Title = title;
            ArtistId = artistId;
            TrackList = trackList;
        }
    }
}